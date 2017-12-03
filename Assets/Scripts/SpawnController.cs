using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
	public GameObject OutOfBounds;
	private OutOfBoundsController OOB;

	// Use this for initialization
	void Start () {
		OOB = OutOfBounds.GetComponent<OutOfBoundsController> ();
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Player1") {
			OOB.spawnPositionP1 = transform.position;
			OOB.spawnRotationP1 = transform.rotation;
		}

		if (col.gameObject.name == "Player2") {
			OOB.spawnPositionP2 = transform.position;
			OOB.spawnRotationP2 = transform.rotation;
		}
	}
}
