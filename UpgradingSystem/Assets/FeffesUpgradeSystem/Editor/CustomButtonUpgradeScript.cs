using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(ButtonUpgradeScript))]
public class CustomButtonUpgradeScript : Editor {

    //int selected = 0;
    ButtonUpgradeScript script;


    int truFalSel = 0;
    string[] trueFalse = new string[]
    {
        "True",
        "False"
    };


    void OnEnable()
    {
        script = (ButtonUpgradeScript)target;
    }

    public override void OnInspectorGUI()
    {


        script.Target = EditorGUILayout.ObjectField("Target Script", script.Target, typeof(UpgradeScript), true) as UpgradeScript;



        if (script.Target != null)
        {
            var list = script.Target.myVariables;

            if (list.Count == 0)
                return;
            string[] listNames = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                listNames[i] = list[i].VariableName;
            }
            script.TargetIndex = EditorGUILayout.Popup("Variable", script.TargetIndex, listNames);


            var selectedVariable = list[script.TargetIndex];

            switch (selectedVariable.Type)
            {
                case Variable.DataType.Float:
                    EditorGUILayout.HelpBox("Value: " + selectedVariable.FloatValue, MessageType.Info);

                    script.SetToFloat = EditorGUILayout.Toggle("Hard-set value", script.SetToFloat);
                    script.FloatChange = EditorGUILayout.FloatField("Value change", script.FloatChange);
                    break;

                case Variable.DataType.Bool:

                    EditorGUILayout.HelpBox("Value: " + selectedVariable.BoolValue, MessageType.Info);
                    script.UseToggle = EditorGUILayout.Toggle("Toggle bool value", script.UseToggle);
                    if(!script.UseToggle)
                    {
                        truFalSel = EditorGUILayout.Popup("Set bool", truFalSel, trueFalse);
                        if (truFalSel == 0)
                            script.SetToBool = true;
                        else
                            script.SetToBool = false;
                        //script.SetToBool = EditorGUILayout.Toggle("Set bool to", script.SetToBool);
                    }

                    break;
            }
        }

        script.Usages = EditorGUILayout.IntField("Usages", script.Usages);


        if (script.Target.currencySystem != null)
        {
            script.Cost = EditorGUILayout.FloatField("Cost", script.Cost);
        }
        

    }

    


}
