using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour {
	public GameObject PlayerMovement;

	public bool boostP1 = false;
	public bool startBoostP1 = false;
	public bool hookshotP1 = false;
	public bool trapP1 = false;
	public bool spawnTrapP1 = false;
	public bool spinP1 = false;
	public bool projectileP1 = false;
	public bool shootProjectileP1 = false;

	public bool boostP2 = false;
	public bool startBoostP2 = false;
	public bool hookshotP2 = false;
	public bool trapP2 = false;
	public bool spawnTrapP2 = false;
	public bool spinP2 = false;
	public bool projectileP2 = false;
	public bool shootProjectileP2 = false;

	public float boostTimeP1 = 2.5f;
	public float boostTimeP2 = 2.5f;

	public string p1CurrentPower = "None";
	public string p2CurrentPower = "None";

	public GameObject projectilePrefab;
	public GameObject projectileSpawn1P1;
	public GameObject projectileSpawn2P1;
	public GameObject projectileSpawn1P2;
	public GameObject projectileSpawn2P2;

	public GameObject trapPrefab;
	public GameObject trapSpawnP1;
	public GameObject trapSpawnP2;

	public GameObject P1PowerIcon;
	public GameObject P2PowerIcon;

	public Sprite hookshotImage;
	public Sprite projectileImage;
	public Sprite boostImage;
	public Sprite trapImage;
	public Sprite spinImage;


	private Sprite P1Default;
	private Sprite P2Default;
	private Image P1Image;
	private Image P2Image;

	private float defaultAccel;

    private PlayerMovementController pMovement;

	void Start () {
        pMovement = PlayerMovement.GetComponent<PlayerMovementController> ();
		defaultAccel = pMovement.Player1Accel;

		P1Image = P1PowerIcon.GetComponent<Image> ();
		P1Image.color = new Color (1, 1, 1, 0f);
		P1Default = P1Image.sprite;

		P2Image = P2PowerIcon.GetComponent<Image> ();
		P2Image.color = new Color (1, 1, 1, 0f);
		P2Default = P2Image.sprite;
	}

    void FixedUpdate () {
		if (p1CurrentPower == "None") {
			P1Image.sprite = P1Default;
			P1Image.color = new Color (1, 1, 1, 0f);
		} else {
			P1Image.color = new Color (1, 1, 1, 1f);
		}

        //Boost Controller P1
		if (p1CurrentPower == "Boost") {
			boostP1 = true;
			P1PowerIcon.GetComponent<Image> ().sprite = boostImage;
		}

        if (startBoostP1 && boostTimeP1 > 0)
        {
            boostTimeP1 -= Time.deltaTime;
			pMovement.Player1Accel = defaultAccel + (defaultAccel/2);
        }
        else
        {
            startBoostP1 = false;
            boostTimeP1 = 2.5f;
            pMovement.Player1Accel = defaultAccel;
        }

		//Hookshot Controller P1
		if (p1CurrentPower == "Hookshot") {
			hookshotP1 = true;
			P1PowerIcon.GetComponent<Image> ().sprite = hookshotImage;
		}

		//Trap Controller P1
		if (p1CurrentPower == "Trap") {
			trapP1 = true;
			P1PowerIcon.GetComponent<Image> ().sprite = trapImage;
		}
		
		if (spawnTrapP1 == true) {
			spawnTrap (trapSpawnP1);
			spawnTrapP1 = false;
		}
		
		//Spin Controller P1
		if (p1CurrentPower == "Spin") {
			spinP1 = true;
			P1PowerIcon.GetComponent<Image> ().sprite = spinImage;
		}

		//Projectile Controller P1
		if (p1CurrentPower == "Projectile") {
			projectileP1 = true;
			P1PowerIcon.GetComponent<Image> ().sprite = projectileImage;
		}

		if (shootProjectileP1) {
			shootProjectile(projectileSpawn1P1, projectileSpawn2P1);
			shootProjectileP1 = false;
		}

/***************************************************************/
		if (p2CurrentPower == "None") {
			P2Image.sprite = P2Default;
			P2Image.color = new Color (1, 1, 1, 0f);
		}  else {
			P2Image.color = new Color (1, 1, 1, 1f);
		}
		
		//Boost Controller P2
		if (p2CurrentPower == "Boost") {
			boostP2 = true;
			P2PowerIcon.GetComponent<Image> ().sprite = boostImage;
		}
			
		if (startBoostP2 && boostTimeP2 > 0) {
			boostTimeP2 -= Time.deltaTime;
			pMovement.Player2Accel = defaultAccel + 0.25f;
		} else {
			startBoostP2 = false;
			boostTimeP2 = 2.5f;
			pMovement.Player2Accel = defaultAccel;
		}

		//Hookshot Controller P2
		if (p2CurrentPower == "Hookshot") {
			hookshotP2 = true;
			P2PowerIcon.GetComponent<Image> ().sprite = hookshotImage;
		}

		//Trap Controller P2
		if (p2CurrentPower == "Trap") {
			trapP2 = true;
			P2PowerIcon.GetComponent<Image> ().sprite = trapImage;
		}
		
		if (spawnTrapP2) {
			spawnTrap (trapSpawnP2);
			spawnTrapP2 = false;
		}

		//Spin Controller P2
		if (p2CurrentPower == "Spin") {
			spinP2 = true;
			P2PowerIcon.GetComponent<Image> ().sprite = spinImage;
		}

		//Projectile Controller P2
		if (p2CurrentPower == "Projectile") {
			projectileP2 = true;
			P2PowerIcon.GetComponent<Image> ().sprite = projectileImage;
		}
		
		if (shootProjectileP2) {
			shootProjectile(projectileSpawn1P2, projectileSpawn2P2);
			shootProjectileP2 = false;
		}

	}

	void shootProjectile(GameObject spawn1, GameObject spawn2) {

		var projectile1 = (GameObject)Instantiate(
			projectilePrefab,
			spawn1.transform.position,
			spawn1.transform.rotation);

		projectile1.GetComponent<Rigidbody>().velocity = projectile1.transform.forward * 50;

		Destroy(projectile1, 2.0f);

		var projectile2 = (GameObject)Instantiate(
			projectilePrefab,
			spawn2.transform.position,
			spawn2.transform.rotation);

		projectile2.GetComponent<Rigidbody>().velocity = projectile2.transform.forward * 50;

		Destroy(projectile2, 2.0f);
	}

	void spawnTrap(GameObject trapSpawn){
		var trap = (GameObject)Instantiate (
			trapPrefab,
			trapSpawn.transform.position,
			trapSpawn.transform.rotation);

		Destroy (trap, 10.0f);
	}
}
