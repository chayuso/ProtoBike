using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectWinner : MonoBehaviour {
    public GameObject GState; //GameState
	public Text winText1;
	public Text winText2;
	public GameObject Player1;
	public GameObject Player2;

	private GameState gameState;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Player1" && !gameState.TimedOut && !gameState.BlueWinner)
        {
			gameState.RedWinner = true;
        }

		if (col.gameObject.name == "Player2" && !gameState.TimedOut && !gameState.RedWinner)
        {
			gameState.BlueWinner = true;
        }
        gameState.GameWon = true;
	}

	// Use this for initialization
	void Start () {
		winText1.enabled = false;
		winText2.enabled = false;

		gameState = GState.GetComponent<GameState> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameState.Player1GoalDist = Vector3.Distance (transform.position, Player1.transform.position);
		gameState.Player2GoalDist = Vector3.Distance (transform.position, Player2.transform.position);
	}
}
