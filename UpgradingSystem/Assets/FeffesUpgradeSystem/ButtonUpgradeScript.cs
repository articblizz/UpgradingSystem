using UnityEngine;
using System.Collections;

public class ButtonUpgradeScript : MonoBehaviour {


	public UpgradeScript Target;

	public float FloatChange = 0;
	public bool SetToFloat;

	public bool UseToggle;
	public bool SetToBool;

	public int TargetIndex = 0;

	public float Cost;
	public int Usages = 999999;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
