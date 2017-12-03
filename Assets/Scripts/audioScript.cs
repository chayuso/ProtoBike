using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour {
	public GameObject PlayerMovement;
	public GameObject PowerManager;
	public GameObject SpinController;

	public AudioSource accelerate;
	public AudioSource boost;
	public AudioSource brake;
	public AudioSource hookshotSet;
	public AudioSource hookshotClang;
	public AudioSource hookshotFire;
	public AudioSource hookshotHit;
	public AudioSource projectileShot;
	public AudioSource[] spinHit = new AudioSource[2];
	public AudioSource spinOut;
	public AudioSource trapSpawn;
	public AudioSource backingUp;

	public bool playAccel = false;
	public bool notPlayAccel = false;

	public bool playBackUp = false;
	public bool notPlayBackUp = false;

	public bool playBoost = false;
	public bool playHookshotFire = false;
	public bool playProjectile = false;
	public bool playSpin = false;
	public bool playSpinOut = false;
	public bool playTrap = false;

	private PlayerMovementController pMovement;
	private PowerManager pManager;

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
		spinHit[0] = audioSources [8];
		spinHit[1] = audioSources [9];
		spinOut = audioSources [10];
		trapSpawn = audioSources [11];
		backingUp = audioSources [12];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Acceleration sounds
		if (playAccel) {
			accelerate.Play ();
			playAccel = false;
		}
		if (notPlayAccel) {
			accelerate.Stop ();
			notPlayAccel = false;
		}

		//Backing up sounds
		if (playBackUp) {
			brake.Play ();
			backingUp.Play ();
			playBackUp = false;
		}
		if (notPlayBackUp) {
			backingUp.Stop ();
			notPlayBackUp = false;
		}

		//Boost sound
		if(playBoost){
			boost.Play ();
			playBoost = false;
		}

		//Hookshot sounds
		if(playHookshotFire){
			hookshotFire.Play ();
			playHookshotFire = false;
		}

		//Projectile sound
		if(playProjectile){
			projectileShot.Play ();
			playProjectile = false;
		}

		//Spin sound
		if(playSpin){
			int index = Random.Range (0, 1);
			spinHit [index].Play ();
			playSpin = false;
		}

		//Spin out sound played in the SpinAnimation script

		//Trap sound
		if(playTrap){
			trapSpawn.Play ();
			playTrap = false;
		}
	}
}
