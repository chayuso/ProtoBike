using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour {
	public Vector3 spawnPositionP1;
	public Quaternion spawnRotationP1;

	public Vector3 spawnPositionP2;
	public Quaternion spawnRotationP2;

	public GameObject Player1;
	public GameObject Player2;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Player1") {
			Player1.transform.position = spawnPositionP1;
			Player1.transform.rotation = spawnRotationP1;
		}

		if (col.gameObject.name == "Player2") {
			Player2.transform.position = spawnPositionP2;
			Player2.transform.rotation = spawnRotationP2;
		}	
	}
}
