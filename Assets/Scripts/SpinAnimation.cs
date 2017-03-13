using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAnimation : MonoBehaviour {
    public GameObject GameState;
    public GameObject Player1;
    public GameObject Player2;
    public Animator ASM1; //Animator State Machine
    public Animator ASM2;
    public bool spunOut1 = false;
    public bool spunOut2 = false;
    public bool animate1 = false;
    public bool animate2 = false;
    private PlayerMovementController pMovement;
    void Start()
    {
        pMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovementController>();
    }
    void FixedUpdate()
    {
        if (GameState.GetComponent<GameState>().reset)
        {
            spunOut1 = false;
            spunOut2 = false;
            animate1 = false;
            animate2 = false;
        }

        if (animate2 && ASM2.GetCurrentAnimatorStateInfo(0).IsName("SpinOut"))
        {
            spunOut2 = true;
        }
        else if (animate1 && ASM1.GetCurrentAnimatorStateInfo(0).IsName("SpinOut"))
        {
            spunOut1 = true;
        }

        if (spunOut2 && !ASM2.GetCurrentAnimatorStateInfo(0).IsName("SpinOut"))
        {
            spunOut2 = false;
            animate2 = false;
        }
        else if (spunOut1 && !ASM1.GetCurrentAnimatorStateInfo(0).IsName("SpinOut"))
        {
            spunOut1 = false;
            animate1 = false;
        }
    }

    public void SpinPlayer1()
    {
        if (!animate1)
        {
            ASM1.SetTrigger("SpinOut");
            spunOut1 = true;
            pMovement.lockP1Movement = true;
        }
    }

    public void SpinPlayer2()
    {
        if (!animate2)
        {
            ASM2.SetTrigger("SpinOut");
            animate2 = true;
            pMovement.lockP2Movement = true;
        }
    }
}
