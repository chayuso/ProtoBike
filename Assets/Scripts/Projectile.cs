using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private SpinAnimation SpinOut;
    //private PlayerMovementController pMovement;

	void Start(){
        SpinOut = GameObject.Find("SpinOutController").GetComponent<SpinAnimation>();
        //pMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovementController> ();
	}

	void OnTriggerEnter(Collider col){
        if (col.gameObject.name == "Motorcycle")
        {
            if (col.GetComponent<BikeNumber>().BikeNum == 1)
            {
                SpinOut.SpinPlayer1();
            }
            else if (col.GetComponent<BikeNumber>().BikeNum == 2)
            {
                SpinOut.SpinPlayer2();
            }
        }
        else if (col.gameObject.name == "Player1") {
            SpinOut.SpinPlayer1();
		}
		else if (col.gameObject.name == "Player2") {
            SpinOut.SpinPlayer2();
		}
	}
}
