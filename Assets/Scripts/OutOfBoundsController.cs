using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour {
	private List<GameObject> spawnList = new List<GameObject>();

	public GameObject Spawn1;
	public GameObject Spawn2;
	public GameObject Spawn3;
	public GameObject Spawn4;
	public GameObject Spawn5;


	public GameObject Player1;
	public GameObject Player2;

	void OnTriggerEnter(Collider col){
		print (col.gameObject.name);
		if (col.gameObject.name == "Player1") {
			Vector3 closestSpawnPosition = new Vector3 ();
			float closestSpawnDist = float.MaxValue;

			foreach (GameObject spawn in spawnList) {
				float spawnDist = Vector3.Distance (spawn.transform.position, Player1.transform.position);
				if (spawnDist < closestSpawnDist) {
					closestSpawnDist = spawnDist;
					closestSpawnPosition = spawn.transform.position;
				}
			}

			Player1.transform.position = closestSpawnPosition;
			Player1.transform.rotation = Quaternion.identity;
		}
		if (col.gameObject.name == "Player2") {
			Vector3 closestSpawnPosition = new Vector3 ();
			float closestSpawnDist = float.MaxValue;

			foreach (GameObject spawn in spawnList) {
				float spawnDist = Vector3.Distance (spawn.transform.position, Player2.transform.position);
				if (spawnDist < closestSpawnDist) {
					closestSpawnDist = spawnDist;
					closestSpawnPosition = spawn.transform.position;
				}
			}
			Player2.transform.position = closestSpawnPosition;
			Player2.transform.rotation = Quaternion.identity;
		}	
	}
	// Use this for initialization
	void Start () {
		spawnList.Add(Spawn1);
		spawnList.Add(Spawn2);
		spawnList.Add(Spawn3);
		spawnList.Add(Spawn4);
		spawnList.Add(Spawn5);

	}
}
