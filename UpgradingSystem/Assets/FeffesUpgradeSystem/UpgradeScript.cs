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
