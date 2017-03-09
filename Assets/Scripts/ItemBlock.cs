using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Test commit

public class ItemBlock : MonoBehaviour {
	public GameObject Player1;
	public GameObject Player2;
	public GameObject PowerManager;

	private List<string> powerList = new List<string>();
	private PowerManager pManager;

	// Use this for initialization
	void Start () {
		pManager = PowerManager.GetComponent<PowerManager> ();
		powerList.Add ("None");
		powerList.Add ("Boost");
		powerList.Add ("Hookshot");
		powerList.Add ("Trap");
		powerList.Add ("Projectile");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(15, 30, 45) * Time.deltaTime);
	}

    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.name == Player1.name)
        {
			pManager.p1CurrentPower = powerList [UnityEngine.Random.Range (1, 5)];

			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (Player.gameObject.name == Player2.name)
        {
			pManager.p2CurrentPower = powerList [UnityEngine.Random.Range (1, 5)];

			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
