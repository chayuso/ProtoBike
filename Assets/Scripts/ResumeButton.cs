using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour {
    public GameObject GState;
    public Camera PauseCamera;
    public GameObject Controls;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseDown()
    {
        GState.GetComponent<GameState>().Player1.GetComponent<Rigidbody>().velocity = GState.GetComponent<GameState>().lastPlayer1Velocity;
        GState.GetComponent<GameState>().Player2.GetComponent<Rigidbody>().velocity = GState.GetComponent<GameState>().lastPlayer2Velocity;
        GState.GetComponent<GameState>().PauseGame = false;
        Controls.GetComponent<PlayerMovementController>().right1 = false;
        Controls.GetComponent<PlayerMovementController>().right2 = false;
        Controls.GetComponent<PlayerMovementController>().left1 = false;
        Controls.GetComponent<PlayerMovementController>().left2 = false;
        PauseCamera.enabled = false;
    }


}
