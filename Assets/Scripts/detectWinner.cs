using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectWinner : MonoBehaviour {
    public GameObject GState; //GameState

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Player1" && !GState.GetComponent<GameState>().TimedOut && !GState.GetComponent<GameState>().BlueWinner)
         {
             GState.GetComponent<GameState>().RedWinner = true;
         }
         if (col.gameObject.name == "Player2" && !GState.GetComponent<GameState>().TimedOut && !GState.GetComponent<GameState>().RedWinner)
         {
             GState.GetComponent<GameState>().BlueWinner = true;
         }
         GState.GetComponent<GameState>().GameWon = true;
	}
}
