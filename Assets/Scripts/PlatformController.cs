using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public int rotateSpeedX;
    public int rotateSpeedY;
    public int rotateSpeedZ;

    //public bool isLocalRotation;

    // Use this for initialization
    void Start () {
        //if (isLocalRotation) {
        //    transform.localRotation = Quaternion.identity;
        //}		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(rotateSpeedX, rotateSpeedY, rotateSpeedZ) * Time.deltaTime);
		
	}
}
