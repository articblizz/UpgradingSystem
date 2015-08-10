using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(UpgradeButton))]
public class UpgradeEditor : Editor {

    public override void OnInspectorGUI()
    {
        UpgradeButton myButton = (UpgradeButton)target;

        myButton.Target = EditorGUILayout.ObjectField("Target script", myButton.Target, typeof(Upgradeable)) as Upgradeable;
        myButton.Cost = EditorGUILayout.FloatField("Upgrade Cost", myButton.Cost);
        myButton.Uses = EditorGUILayout.IntField("Uses", myButton.Uses);
        myButton.TargetIndex = EditorGUILayout.IntField("Target Index", myButton.TargetIndex);
        myButton.targetType = (TargetType)EditorGUILayout.EnumPopup("Target Datatype", myButton.targetType);

        switch (myButton.targetType)
        {
            case TargetType.Bool:
                myButton.Toggle = EditorGUILayout.Toggle("Toggle", myButton.Toggle);

                if (!myButton.Toggle)
                    myButton.ChangeBoolValue = EditorGUILayout.Toggle("True/False", myButton.ChangeBoolValue);
                break;
            case TargetType.Float:

                myButton.HardSet = EditorGUILayout.Toggle("Hard set", myButton.HardSet);
                if(myButton.HardSet)
                    myButton.ChangeFloatValue = EditorGUILayout.FloatField("Change value to", myButton.ChangeFloatValue);
                else
                    myButton.ChangeFloatValue = EditorGUILayout.FloatField("Change value", myButton.ChangeFloatValue);
                break;

        }
    }
}
