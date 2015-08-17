using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayVariableTextScript : MonoBehaviour {

	public UpgradeScript upgradeScript;
	public string TextToDisplay = "Variable: %0%";
	Text textComponent;

	/*
		Use %[index]% to display any variable, for an example:

		"Variable index 0: %0%."

		Use %$n% to display the name of the currency if a CurrencySystemScript is attached to
		the UpgradeScript.

		Use %$a% to display the amount of 'money' left if there is a CurrencySystemScript
		attached to the UpgradeScript.
	*/

	void Start () {

		textComponent = GetComponent<Text>();

		if (upgradeScript == null)
			Debug.LogWarning("No UpgradeScript attached!");
	
	}
	
	void Update () {

		string text = TextToDisplay;

		var textArray = text.Split('%');

		for (int i = 0; i < textArray.Length; i++)
		{
			try
			{
				var variable = upgradeScript.myVariables[int.Parse(textArray[i])];
				if (variable.Type == Variable.DataType.Float)
				{
					textArray[i] = variable.FloatValue.ToString();
				}
				else
				{
					textArray[i] = variable.BoolValue.ToString();
				}
			}
			catch { }

			if (textArray[i] == "$n")
				textArray[i] = upgradeScript.currencySystem.CurrencyName;
			else if (textArray[i] == "$a")
				textArray[i] = upgradeScript.currencySystem.Moneys.ToString();
		}

		text = string.Join("", textArray);

		textComponent.text = text;
	
	}
}
