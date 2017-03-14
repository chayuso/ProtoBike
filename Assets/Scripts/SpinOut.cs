using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOut : MonoBehaviour {
    public Animator ASM1; //Animator State Machine
    public Animator ASM2;
    public GameObject SpinningController;

    void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.name == "Player1" && ASM1.GetCurrentAnimatorStateInfo(0).IsName("Spin"))
        {
            SpinningController.GetComponent<SpinAnimation>().SpinPlayer2();
        }
        else if(Player.gameObject.name == "Player2" && ASM2.GetCurrentAnimatorStateInfo(0).IsName("Spin"))
        {
            SpinningController.GetComponent<SpinAnimation>().SpinPlayer1();
        }
    }
}
