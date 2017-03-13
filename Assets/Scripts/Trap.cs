using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
    private SpinAnimation SpinOut;
    private GameState GameState;
	//private PlayerMovementController pMovement;

	void Start(){
        SpinOut = GameObject.Find("SpinOutController").GetComponent<SpinAnimation>();
        GameState = GameObject.Find("GameState").GetComponent<GameState> ();
        //pMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovementController> ();
	}
    void FixedUpdate()
    {
        if (GameState.GetComponent<GameState>().reset)
        {
            Destroy(gameObject);
        }
    }
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Player1") {
            SpinOut.SpinPlayer1();
			Destroy (gameObject);
		}
		if (col.gameObject.name == "Player2") {
            SpinOut.SpinPlayer2();
            Destroy (gameObject);
		}
	}
}