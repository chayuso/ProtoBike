using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollisionTest : MonoBehaviour {
    public Text Test; 
	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        Test.text = col.gameObject.name;
    }
    void OnCollisionEnter(Collision col)
    {
        Test.text = col.gameObject.name;
    }

}
