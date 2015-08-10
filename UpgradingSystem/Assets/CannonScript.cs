using UnityEngine;
using System.Collections;

public class CannonScript : Upgradeable {

    public Transform cannonBase;
    public Transform cannonEdge;
    public GameObject CannonBall;

    //public float Force = 100;

    // note to self:
    // index 0 = Cannon force
    // index 1 = rate of fire!

    float rotSpeed = 0.5f;

    bool canShoot = true;
    float rofTimer = 0;


    //float RateOfFire = 1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!canShoot)
        {
            rofTimer += Time.deltaTime;
            if (rofTimer >= FloatValues[1])
            {
                canShoot = true;
                rofTimer = 0;
            }
        }
        var dir = Input.GetAxis("Horizontal");

        cannonBase.Rotate(0, 0, -dir * rotSpeed);

        if (Input.GetKey(KeyCode.Space) && canShoot)
        {
            canShoot = false;


            var cb = (GameObject)Instantiate(CannonBall, cannonEdge.position, cannonBase.rotation);
            cb.GetComponent<Rigidbody2D>().AddForce(cb.transform.right * FloatValues[0]);
            Destroy(cb, 15);
        }
	}
}
