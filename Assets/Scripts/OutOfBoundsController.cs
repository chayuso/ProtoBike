using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour {
	List<GameObject> spawnList = new List<GameObject>();

	public GameObject Spawn1;
	public GameObject Spawn2;

	public GameObject Player1;
	public GameObject Player2;

	void OnTriggerEnter(Collider col){
		print (col.gameObject.name);
		if (col.gameObject.name == "Player1") {
			print ("Player 1 is out of bounds");
			Vector3 closestSpawnPosition = new Vector3 ();
			float closestSpawnDist = float.MaxValue;

			foreach (GameObject spawn in spawnList) {
				float spawnDist = Vector3.Distance (spawn.transform.position, Player1.transform.position);
				if (spawnDist < closestSpawnDist) {
					closestSpawnDist = spawnDist;
					closestSpawnPosition = spawn.transform.position;
				}
			}
		}
		if (col.gameObject.name == "Player2") {
			print ("Player 2 is out of bounds");
			Vector3 closestSpawnPosition = new Vector3 ();
			float closestSpawnDist = float.MaxValue;

			foreach (GameObject spawn in spawnList) {
				float spawnDist = Vector3.Distance (spawn.transform.position, Player2.transform.position);
				if (spawnDist < closestSpawnDist) {
					closestSpawnDist = spawnDist;
					closestSpawnPosition = spawn.transform.position;
				}
			}

		}	
	}
	// Use this for initialization
	void Start () {
		spawnList.Add(Spawn1);
		spawnList.Add(Spawn2);
	}
}
