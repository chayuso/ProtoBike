using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour {
    public GameObject GameState;
    public GameObject Player1;
    public GameObject Player2;
    public Animator HookShot1;
    public Animator HookShot2;
    public float t;

    private Vector3 lastPlayer1Position;
    private Vector3 lastPlayer2Position;

    bool hooked1 = false;
    bool hooked2 = false;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameState.GetComponent<GameState>().reset)
        {
            hooked1 = false;
            hooked2 = false;
            t = 0;
        }
        if (hooked1)
        {
            if (!GameState.GetComponent<GameState>().PauseGame)
            {
                t += Time.deltaTime;
                Player2.transform.position = Vector3.Lerp(lastPlayer2Position, lastPlayer1Position, t);
                Player1.transform.position = Vector3.Lerp(lastPlayer1Position, lastPlayer2Position, t);
                if (Player2.transform.position == lastPlayer1Position && Player1.transform.position == lastPlayer2Position)
                {
                    hooked1 = false;
                    HookShot2.SetBool("Hook", false);
                }
            }
            
            
        }
        else if (hooked2)
        {
            if (!GameState.GetComponent<GameState>().PauseGame)
            {
                t += Time.deltaTime;
                Player1.transform.position = Vector3.Lerp(lastPlayer1Position, lastPlayer2Position, t);
                Player2.transform.position = Vector3.Lerp(lastPlayer2Position, lastPlayer1Position, t);
                if (Player1.transform.position == lastPlayer2Position && Player2.transform.position == lastPlayer1Position)
                {
                    hooked2 = false;
                    HookShot1.SetBool("Hook", false);
                }
            }
        }

    }
    void OnTriggerEnter(Collider Player)
    {
        if (Player.gameObject.name == "Motorcycle")
        {
            if (!hooked1 && Player.GetComponent<BikeNumber>().BikeNum == 1 && HookShot2.GetCurrentAnimatorStateInfo(0).IsName("Extend"))
            {
                HookShot2.SetBool("Hook", true);
                lastPlayer1Position = Player1.transform.position;
                lastPlayer2Position = Player2.transform.position;
                hooked1 = true;
                t = 0;
            }
            else if (!hooked2 && Player.GetComponent<BikeNumber>().BikeNum == 2 && HookShot1.GetCurrentAnimatorStateInfo(0).IsName("Extend"))
            {
                HookShot1.SetBool("Hook", true);
                lastPlayer1Position = Player1.transform.position;
                lastPlayer2Position = Player2.transform.position;
                hooked2 = true;
                t = 0;
            }
        }
        else if (!hooked1 && Player.gameObject.name == Player1.name && HookShot2.GetCurrentAnimatorStateInfo(0).IsName("Extend"))
        {
            HookShot2.SetBool("Hook", true);
            lastPlayer1Position = Player1.transform.position;
            lastPlayer2Position = Player2.transform.position;
            hooked1 = true;
            t = 0;
        }
        else if (!hooked2 && Player.gameObject.name == Player2.name && HookShot1.GetCurrentAnimatorStateInfo(0).IsName("Extend"))
        {
            HookShot1.SetBool("Hook", true);
            lastPlayer1Position = Player1.transform.position;
            lastPlayer2Position = Player2.transform.position;
            hooked2 = true;
            t = 0;
        }
    }
}
