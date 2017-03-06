using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Test commit

public class ItemBlock : MonoBehaviour {
	public GameObject GState;
	public GameObject Player1;
	public GameObject Player2;
	public GameObject PowerManager;

	private PowerManager pManager;

	// Use this for initialization
	void Start () {
		pManager = PowerManager.GetComponent<PowerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(15, 30, 45) * Time.deltaTime);
	}

	void FixedUpdate(){
		if (Vector3.Distance (transform.position, Player1.transform.position) <= .7) {
			pManager.boostP1 = true;
			Destroy (gameObject);
		}
		if (Vector3.Distance (transform.position, Player2.transform.position) <= .7) {
			pManager.boostP2 = true;
			Destroy (gameObject);
		}	
	}
}
