using UnityEngine;
using System.Collections;

public class CurrencySystemScript : MonoBehaviour {


    public string CurrencyName = "Money";
    public float Moneys = 0;

    public bool Buy(float cost)
    {
        print("Attempting to buy, " + Moneys + " - " + cost);
        if (Moneys >= cost)
        {
            Moneys -= cost;
            return true;
        }

        return false;
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
