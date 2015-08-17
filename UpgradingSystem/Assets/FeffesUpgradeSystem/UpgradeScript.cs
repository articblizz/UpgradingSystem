using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Variable
{
    public enum DataType
    {
        Float = 0,
        Bool = 1
    }

    public string VariableName;

    public DataType Type = DataType.Float;
    public float FloatValue;
    public bool BoolValue;
}

public class UpgradeScript : MonoBehaviour {


    public List<Variable> myVariables = new List<Variable>();

    public CurrencySystemScript currencySystem;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }


    public float GetFloat(string name)
    {
        for (int i = 0; i < myVariables.Count; i++)
        {
            if (myVariables[i].VariableName == name)
                return myVariables[i].FloatValue;
        }

        throw new System.Exception("No variable with that name");
    }
    public float GetFloat(int index)
    {
        return myVariables[index].FloatValue;
    }


    public bool GetBool(string name)
    {
        for (int i = 0; i < myVariables.Count; i++)
        {
            if (myVariables[i].VariableName == name)
                return myVariables[i].BoolValue;
        }

        throw new System.Exception("No variable with that name");
    }

    public bool GetBool(int index)
    {
        return myVariables[index].BoolValue;
    }

    public void ButtonClick(ButtonUpgradeScript script)
    {

        if (currencySystem != null)
        {
            if (!currencySystem.Buy(script.Cost))
                return;
        }

        print("Changing item " + script.TargetIndex);
        var theItem = myVariables[script.TargetIndex];
        switch (theItem.Type)
        {
            case Variable.DataType.Float:
                if (script.SetToFloat)
                {
                    theItem.FloatValue = script.FloatChange;
                }
                else
                {
                    theItem.FloatValue += script.FloatChange;
                }
                break;
            case Variable.DataType.Bool:

                if(script.UseToggle)
                {
                    theItem.BoolValue = !theItem.BoolValue;
                }
                else
                {
                    theItem.BoolValue = script.SetToBool;
                }

                break;
        }
        script.Usages--;
        if (script.Usages <= 0)
            script.GetComponent<Button>().interactable = false;
    }
}
