using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CurrencySystemScript))]
public class CustomCurrencySystemScript : Editor {

    CurrencySystemScript script;


    public override void OnInspectorGUI()
    {

        script.CurrencyName = EditorGUILayout.TextField("Currency Name", script.CurrencyName);
        script.Moneys = EditorGUILayout.FloatField("Quantity of " + script.CurrencyName, script.Moneys);
    }


    void OnEnable()
    {
        script = (CurrencySystemScript)target; 
    }
}
