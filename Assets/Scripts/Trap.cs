using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	private PlayerMovementController pMovement;

	void Start(){
		pMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovementController> ();
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Player1") {
			pMovement.lockP1Movement = true;
			Destroy (gameObject);
		}
		if (col.gameObject.name == "Player2") {
			pMovement.lockP2Movement = true;
			Destroy (gameObject);
		}
	}
}