﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private PlayerMovementController pMovement;

	void Start(){
		pMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovementController> ();
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Player1") {
			pMovement.lockP1Movement = true;
		}
		if (col.gameObject.name == "Player2") {
			pMovement.lockP2Movement = true;
		}
	}
}
