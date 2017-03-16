using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {
    public GameObject GState;
    public GameObject StartButton;

    public void OnMouseDown()
    {
        GState.GetComponent<GameState>().ResetVariables();
        StartButton.GetComponent<StartButton>().OnMouseDown();
    }
}
