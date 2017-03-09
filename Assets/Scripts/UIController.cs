using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public GameObject PowerManager;
	public GameObject GameState;
	public Text p1Power;
	public Text p2Power;

	private GameState gState;
	private PowerManager pManager;
	// Use this for initialization
	void Start () {
		pManager = PowerManager.GetComponent<PowerManager> ();
		gState = GameState.GetComponent<GameState> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!gState.StartGame || gState.PauseGame) {
			p1Power.gameObject.SetActive (false);
			p2Power.gameObject.SetActive (false);
		} else {
			p1Power.gameObject.SetActive (true);
			p2Power.gameObject.SetActive (true);
		}

		p1Power.text = pManager.p1CurrentPower;
		p2Power.text = pManager.p2CurrentPower;
	}
}
