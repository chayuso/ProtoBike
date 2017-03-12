using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinOut : MonoBehaviour {
    public Animator ASM1; //Animator State Machine
    public Animator ASM2;
    private bool spunOut1 = false;
    private bool spunOut2 = false;
    void Update()
    {
        if (spunOut2 && ASM2.GetCurrentAnimatorStateInfo(0).IsName("Stable"))
        {
            spunOut2 = false;
        }
        else if (spunOut1 && ASM1.GetCurrentAnimatorStateInfo(0).IsName("Stable"))
        {
            spunOut1 = false;
        }
    }
    void OnCollisionEnter(Collision Player)
    {
        //print(Player.gameObject.name);
        if (!spunOut2 && Player.gameObject.name == "Player1" && ASM1.GetCurrentAnimatorStateInfo(0).IsName("Spin"))
        {
            //print("player2 spin");
            ASM2.SetTrigger("SpinOut");
            spunOut2 = true;
            //print("Done");
        }
        else if(!spunOut1 && Player.gameObject.name == "Player2" && ASM2.GetCurrentAnimatorStateInfo(0).IsName("Spin"))
        {
            //print("player1 spin");
            ASM1.SetTrigger("SpinOut");
            spunOut1 = true;
            //print("Done");
        }
    }
}
