using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
    public GameObject GState;
    public Camera MenuCamera;
    public Camera PauseCamera;
    public Camera Player1Camera;
    public Camera Player2Camera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseDown()
    {
        GState.GetComponent<GameState>().ResetVariables();
        GState.GetComponent<GameState>().StartGame = true;
        Player1Camera.enabled = true;
        Player2Camera.enabled = true;
        PauseCamera.enabled = false;
        MenuCamera.enabled = false;
    }
}
