using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {
	public GameObject PlayerMovement;
	public bool boostP1 = false;
	public bool boostP2 = false;

	public float boostTimeP1 = 2.5f;
	public float boostTimeP2 = 2.5f;

	private float defaultAccel;

	private PlayerMovementController pMovement;
	// Use this for initialization
	void Start () {
		pMovement = PlayerMovement.GetComponent<PlayerMovementController> ();
		defaultAccel = pMovement.Player1Accel;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (boostP1 && boostTimeP1 > 0) {
			boostTimeP1 -= Time.deltaTime;
			pMovement.Player1Accel = defaultAccel + 0.5f;
		} else {
			boostP1 = false;
			boostTimeP1 = 2.5f;
			pMovement.Player1Accel = defaultAccel;
		}
		
		if (boostP2 && boostTimeP2 > 0) {
			boostTimeP2 -= Time.deltaTime;
			pMovement.Player2Accel = defaultAccel + 0.5f;
		} else {
			boostP2 = false;
			boostTimeP2 = 2.5f;
			pMovement.Player2Accel = defaultAccel;
		}
	}
}
