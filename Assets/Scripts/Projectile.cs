using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public GameObject PlayerMovement;

	private PlayerMovementController pMovement;

	void Start(){
		pMovement = PlayerMovement.GetComponent<PlayerMovementController> ();
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "projectile(Clone)" && gameObject.name == "Player1") {
			pMovement.lockP1Movement = true;
			StartCoroutine (lockPlayer1());
			Destroy (col.gameObject);
		}
		if (col.gameObject.name == "projectile(Clone)" && gameObject.name == "Player2") {
			pMovement.lockP2Movement = true;
			StartCoroutine (lockPlayer2());
			Destroy (col.gameObject);
		}
	}

	private IEnumerator lockPlayer1(){
		yield return new WaitForSeconds (2.0f);
		pMovement.lockP1Movement = false;
	}

	private IEnumerator lockPlayer2(){
		yield return new WaitForSeconds (2.0f);
		pMovement.lockP2Movement = false;
	}
}
