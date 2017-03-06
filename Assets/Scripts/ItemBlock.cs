using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.name == Player1.name)
        {
            pManager.boostP1 = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (Player.gameObject.name == Player2.name)
        {
            pManager.boostP2 = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    /*void FixedUpdate(){
		if (Vector3.Distance (transform.position, Player1.transform.position) <= .7) {
			pManager.boostP1 = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
		if (Vector3.Distance (transform.position, Player2.transform.position) <= .7) {
			pManager.boostP2 = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }	
	}*/
}
