using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {
	public GameObject PlayerMovement;

	public bool boostP1 = false;
	public bool startBoostP1 = false;
	public bool hookshotP1 = false;
	public bool trapP1 = false;
	public bool spinP1 = false;
	public bool projectileP1 = false;

	public bool boostP2 = false;
	public bool startBoostP2 = false;
	public bool hookshotP2 = false;
	public bool trapP2 = false;
	public bool spinP2 = false;
	public bool projectileP2 = false;

	public float boostTimeP1 = 2.5f;
	public float boostTimeP2 = 2.5f;

	public string p1CurrentPower = "None";
	public string p2CurrentPower = "None";

	private float defaultAccel; 

    private PlayerMovementController pMovement;

	void Start () {
        pMovement = PlayerMovement.GetComponent<PlayerMovementController> ();
		defaultAccel = pMovement.Player1Accel;
	}

    void FixedUpdate () {
        p1CurrentPower = "Spin";
        //Boost Controller P1
        if (p1CurrentPower == "Boost")
        {
            boostP1 = true;
        }

        if (startBoostP1 && boostTimeP1 > 0)
        {
            boostTimeP1 -= Time.deltaTime;
            pMovement.Player1Accel = defaultAccel + 0.25f;
        }
        else
        {
            startBoostP1 = false;
            boostTimeP1 = 2.5f;
            pMovement.Player1Accel = defaultAccel;
        }

		//Hookshot Controller P1
		if (p1CurrentPower == "Hookshot")
			hookshotP1 = true;

		//Trap Controller P1
		if (p1CurrentPower == "Trap")
			trapP1 = true;
		
		//Spin Controller P1
		if (p1CurrentPower == "Spin")
			spinP1 = true;

		//Projectile Controller P1
		if (p1CurrentPower == "Projectile")
			projectileP1 = true;

/***************************************************************/

		//Boost Controller P2
		if (p2CurrentPower == "Boost") {
			boostP2 = true;
		}
			
		if (startBoostP2 && boostTimeP2 > 0) {
			boostTimeP2 -= Time.deltaTime;
			pMovement.Player2Accel = defaultAccel + 0.25f;
		} else {
			startBoostP2 = false;
			boostTimeP2 = 2.5f;
			pMovement.Player2Accel = defaultAccel;
		}

		//Hookshot Controller P2
		if (p2CurrentPower == "Hookshot")
			hookshotP2 = true;

		//Trap Controller P2
		if (p2CurrentPower == "Trap")
			trapP2 = true;

		//Spin Controller P2
		if (p2CurrentPower == "Spin")
			spinP2 = true;

		//Projectile Controller P1
		if (p2CurrentPower == "Projectile")
			projectileP2 = true;

	}
}
