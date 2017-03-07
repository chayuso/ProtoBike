using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectWinner : MonoBehaviour {
    public GameObject GState; //GameState
	public Text winText1;
	public Text winText2;
	public GameObject Player2;


	void OnCollisionEnter(Collision col){
		if (Vector3.Distance (gameObject.transform.position, col.gameObject.transform.position) <= 2) {
			if (col.gameObject.name == "Player1" && !GState.GetComponent<GameState> ().TimedOut && !GState.GetComponent<GameState> ().BlueWinner) {
				GState.GetComponent<GameState> ().RedWinner = true;
			}
			if (col.gameObject.name == "Player2" && !GState.GetComponent<GameState> ().TimedOut && !GState.GetComponent<GameState> ().RedWinner) {
				GState.GetComponent<GameState> ().BlueWinner = true;
			}
			GState.GetComponent<GameState> ().GameWon = true;
		}
	}

	// Use this for initialization
	void Start () {
		winText1.enabled = false;
		winText2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
