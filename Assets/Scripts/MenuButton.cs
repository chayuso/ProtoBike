using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {
    public GameObject GState;

    // Update is called once per frame
    public void OnMouseDown()
    {
        GState.GetComponent<GameState>().ResetVariables();
    }
}
