using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.IO;

[Serializable]
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

    public string GameName;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
    
    }

    public void SaveList(bool saveCurrencySystem = false)
    {
        string sFile = GameName + "_Data\\save.bin";
        //File.Create(sFile);

        using (Stream stream = File.Create(sFile))
        {
            var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bFormatter.Serialize(stream, myVariables);
        }

        if (saveCurrencySystem)
        {
            PlayerPrefs.SetString("MoneyName", currencySystem.CurrencyName);
            PlayerPrefs.SetFloat("MoneyQuantity", currencySystem.Moneys);
        }

    }


    /// <summary>
    /// Will overwrite the current list
    /// </summary>
    public void LoadList(bool loadCurrencySystem = false)
    {
        string sFile = GameName + "_Data\\save.bin";

        using (Stream stream = File.Open(sFile, FileMode.Open))
        {
            var bFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            myVariables = (List<Variable>)bFormatter.Deserialize(stream);
        }


        if (loadCurrencySystem)
        {
            currencySystem.Moneys = PlayerPrefs.GetFloat("MoneyQuantity");
            currencySystem.CurrencyName = PlayerPrefs.GetString("MoneyName");
        }
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
