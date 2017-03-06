using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {
	public GameObject PlayerMovement;
	public bool boostP1 = false;
	public bool boostP2 = false;

	public float boostTimeP1 = 2.5f;
	public float boostTimeP2 = 2.5f;

	private PlayerMovementController pMovement;
	// Use this for initialization
	void Start () {
		pMovement = PlayerMovement.GetComponent<PlayerMovementController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (boostP1 && boostTimeP1 > 0) {
			boostTimeP1 -= Time.deltaTime;
			pMovement.Player1Accel = 1.0f;
		} else {
			boostP1 = false;
			boostTimeP1 = 2.5f;
			pMovement.Player1Accel = 0.5f;
		}
		
		if (boostP2 && boostTimeP2 > 0) {
			boostTimeP2 -= Time.deltaTime;
			pMovement.Player2Accel = 1.0f;
		} else {
			boostP2 = false;
			boostTimeP2 = 2.5f;
			pMovement.Player2Accel = 0.5f;
		}
	}
}
