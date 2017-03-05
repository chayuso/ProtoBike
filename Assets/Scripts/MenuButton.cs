using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {
    public GameObject GState;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public void OnMouseDown()
    {
        GState.GetComponent<GameState>().ResetVariables();
    }
}
