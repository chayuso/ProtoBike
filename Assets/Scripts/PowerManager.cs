using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {
	public GameObject PlayerMovement;
	public bool boostP1 = false;
	public bool boostP2 = false;

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
		//Probably shold use a switch for the powers because
		if (p1CurrentPower == "Boost") {
			boostP1 = true;
		}

		if (p2CurrentPower == "Boost") {
			boostP2 = true;
		}

		if (boostP1 && boostTimeP1 > 0) {
			boostTimeP1 -= Time.deltaTime;
			pMovement.Player1Accel = defaultAccel + 0.25f;
		} else {
			boostP1 = false;
			boostTimeP1 = 2.5f;
			pMovement.Player1Accel = defaultAccel;
		}
		
		if (boostP2 && boostTimeP2 > 0) {
			boostTimeP2 -= Time.deltaTime;
			pMovement.Player2Accel = defaultAccel + 0.25f;
		} else {
			boostP2 = false;
			boostTimeP2 = 2.5f;
			pMovement.Player2Accel = defaultAccel;
		}
	}
}
