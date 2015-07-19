using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour {

    public Text text;
    public string CurrencyName = "Fefferinos";

    public float Gold
    {
        get
        {
            return _gold;
        }
        set
        {
            if(text != null) // gold display
                text.text = value + " " + CurrencyName;
            _gold = value;
        }
    }
    private float _gold;


	// Use this for initialization
	void Start () {

        Gold = 5000;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void PressedUpgrade(UpgradeButton button)
    {
    }


    void Upgrade(float value)
    {
        value += 1;
    }


    void Upgrade(bool value)
    {
        value = !value;
    }
}
