using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour {

	public Text CurrencyDisplayText;
	public string CurrencyName = "Fefferinos";

	public float Currency
	{
		get
		{
			return _currency;
		}
		set
		{
			if(CurrencyDisplayText != null) // gold display
				CurrencyDisplayText.text = value + " " + CurrencyName;
			_currency = value;
		}
	}
	private float _currency;

    public float SetCurrency = 5000;


	// Use this for initialization
	void Start () {

		Currency = SetCurrency;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void PressedUpgrade(UpgradeButton button)
	{
        if (Currency >= button.Cost)
            Currency -= button.Cost;
        else
            return;
        button.Uses--;
        
        var target = button.Target;
        var i = button.TargetIndex;
        switch (button.targetType)
        {
            case TargetType.Bool:
                if (button.Toggle)
                {
                    target.BoolValues[i] = !target.BoolValues[i];
                }
                else
                {
                    target.BoolValues[i] = button.ChangeBoolValue;
                }
                if (target.TextBoolValueDisplay[i] != null)
                    target.TextBoolValueDisplay[i].text = target.BoolValues[i].ToString();
                break;
            case TargetType.Float:

                if (button.HardSet)
                {
                    target.FloatValues[i] = button.ChangeFloatValue;
                }
                else
                {
                    target.FloatValues[i] += button.ChangeFloatValue;
                }
                if (target.TextFloatValueDisplay[i] != null)
                    target.TextFloatValueDisplay[i].text = target.FloatValues[i].ToString();

                break;
        }

        if (button.Uses <= 0)
        {
            button.GetComponent<Button>().interactable = false;
        }
	}
}
