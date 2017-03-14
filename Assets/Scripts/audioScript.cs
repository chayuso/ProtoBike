using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour {
	public GameObject PlayerMovement;
	public GameObject PowerManager;

	private PlayerMovementController pMovement;
	private PowerManager pManager;

	public bool playAccel = false;
	public bool notPlayAccel = false;

	public bool playBackUp = false;
	public bool notPlayBackUp = false;

	private AudioSource accelerate;
	private AudioSource boost;
	private AudioSource brake;
	private AudioSource hookshotSet;
	private AudioSource hookshotClang;
	private AudioSource hookshotFire;
	private AudioSource hookshotHit;
	private AudioSource projectileShot;
	private AudioSource spinHit1;
	private AudioSource spinHit2;
	private AudioSource spinOut;
	private AudioSource trapSpawn;
	private AudioSource backingUp;

	// Use this for initialization
	void Start () {
		pMovement = PlayerMovement.GetComponent<PlayerMovementController> ();

		AudioSource[] audioSources = GetComponents<AudioSource>();

		accelerate = audioSources [0];
		boost = audioSources [1];
		brake = audioSources [2];
		hookshotSet = audioSources [3];
		hookshotClang = audioSources [4];
		hookshotFire = audioSources [5];
		hookshotHit = audioSources [6];
		projectileShot = audioSources [7];
		spinHit1 = audioSources [8];
		spinHit2 = audioSources [9];
		spinOut = audioSources [10];
		trapSpawn = audioSources [11];
		backingUp = audioSources [12];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (playAccel) {
			accelerate.Play ();
			playAccel = false;
		}
		if (notPlayAccel) {
			accelerate.Stop ();
			brake.Play ();
			notPlayAccel = false;
		}

		if (playBackUp) {
			backingUp.Play ();
			playBackUp = false;
		}
		if (notPlayBackUp) {
			backingUp.Stop ();
			notPlayBackUp = false;
		}
	}
}
