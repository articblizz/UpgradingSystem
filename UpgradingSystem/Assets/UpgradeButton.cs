using UnityEngine;
using System.Collections;

public enum TargetType
{
	Float,
	Bool
}

public class UpgradeButton : MonoBehaviour {

	public int TargetIndex;

    public float Cost = 0;

    public int Uses = 1;

	public TargetType targetType;

    public Upgradeable Target;

	public bool HardSet = false;

	public float ChangeFloatValue;
	public bool ChangeBoolValue;
	public bool Toggle = true;




    // use this for scaling costs and so on
    public void OnUpgradeSuccess()
    {
    }
}
