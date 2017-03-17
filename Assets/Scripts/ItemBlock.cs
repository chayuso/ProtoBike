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
    private GameState GameState;

	// Use this for initialization
	void Start () {
        GameState = GameObject.Find("GameState").GetComponent<GameState>();
        pManager = PowerManager.GetComponent<PowerManager> ();
		powerList.Add ("None");
		powerList.Add ("Boost");
		powerList.Add ("Hookshot");
		powerList.Add ("Trap");
		powerList.Add ("Projectile");
		powerList.Add ("Spin");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3(15, 30, 45) * Time.deltaTime);
        if (GameState.GetComponent<GameState>().reset)
        {
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider Player)
    {
        
        if (Player.gameObject.name == Player1.name || (Player.gameObject.name == "Motorcycle" && Player.gameObject.transform.parent.gameObject.name == "Player1Bike"))
        {
            pManager.boostP1 = false;
            pManager.hookshotP1 = false;
            pManager.trapP1 = false;
            pManager.spinP1 = false;
            pManager.projectileP1 = false;

            pManager.p1CurrentPower = powerList [UnityEngine.Random.Range (1, 6)];


            gameObject.GetComponent<MeshRenderer> ().enabled = false;
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (Player.gameObject.name == Player2.name || (Player.gameObject.name == "Motorcycle" && Player.gameObject.transform.parent.gameObject.name == "Player2Bike"))
        {
            pManager.boostP2 = false;
            pManager.hookshotP2 = false;
            pManager.trapP2 = false;
            pManager.spinP2 = false;
            pManager.projectileP2 = false;

            pManager.p2CurrentPower = powerList [UnityEngine.Random.Range (1, 6)];

			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
