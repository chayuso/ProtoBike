using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {
    public GameObject GState;
    public GameObject StartButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseDown()
    {
        GState.GetComponent<GameState>().ResetVariables();
        StartButton.GetComponent<StartButton>().OnMouseDown();
    }
}
