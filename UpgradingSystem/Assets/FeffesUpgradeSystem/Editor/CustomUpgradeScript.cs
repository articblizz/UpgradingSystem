using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(UpgradeScript))]
public class ExtendEditor : Editor {

    UpgradeScript script;
    SerializedObject GetTarget;
    SerializedProperty ThisList;
    int listSize;


    public override void OnInspectorGUI()
    {

        script.currencySystem = EditorGUILayout.ObjectField("Currency System", script.currencySystem, typeof(CurrencySystemScript), true) as CurrencySystemScript;


        GetTarget.Update();

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //EditorGUILayout.LabelField("Add a new item");

        if (GUILayout.Button("Add New Variable"))
        {
            script.myVariables.Add(new Variable());
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        //Display our list to the inspector window

        for (int i = 0; i < ThisList.arraySize; i++)
        {
            SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);

            SerializedProperty MyFloat = MyListRef.FindPropertyRelative("FloatValue");
            SerializedProperty MyBool = MyListRef.FindPropertyRelative("BoolValue");
            SerializedProperty MyDatatype = MyListRef.FindPropertyRelative("Type");
            SerializedProperty MyName = MyListRef.FindPropertyRelative("VariableName");


            if(MyName.stringValue == "")
                MyName.stringValue = "Variable " + i;

            MyName.stringValue = EditorGUILayout.TextField("Name", MyName.stringValue);
            EditorGUILayout.PropertyField(MyDatatype);
            if (MyDatatype.enumValueIndex == 0)
            {
                MyFloat.floatValue = EditorGUILayout.FloatField("Float value", MyFloat.floatValue);
            }
            else
                MyBool.boolValue = EditorGUILayout.Toggle("Bool value", MyBool.boolValue);

            //EditorGUILayout.LabelField("Customizable Field With GUI");



            EditorGUILayout.Space();

            //Remove this index from the List
            //EditorGUILayout.LabelField("Remove an index from the List<> with a button");
            if (GUILayout.Button("Remove This Index (" + i.ToString() + ")"))
            {
                ThisList.DeleteArrayElementAtIndex(i);
            }
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();

        }

        //Apply the changes to our list
        GetTarget.ApplyModifiedProperties();
    }

    void OnEnable()
    {
        script = (UpgradeScript)target;
        GetTarget = new SerializedObject(script);
        ThisList = GetTarget.FindProperty("myVariables");
    }



}
