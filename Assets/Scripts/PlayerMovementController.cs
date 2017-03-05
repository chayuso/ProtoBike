using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;

    public Animator ASM1; //Animator State Machine
    public Animator ASM2;

    public Animator Wheels1; //Animator State Machine
    public Animator Wheels2;

    public Animator HookShot1;
    public Animator HookShot2;

    public float accel;
    public float rotateSpeed;

    public bool left1 = false;
    public bool right1 = false;
    public bool left2 = false;
    public bool right2 = false;

    public bool accel1 = false;
    public bool accel2 = false;
    public bool reverse1 = false;
    public bool reverse2 = false;
    private Rigidbody P1RB;
    private Rigidbody P2RB;

    // Use this for initialization
    void Start () {
        P1RB = Player1.GetComponent<Rigidbody>();
        P2RB = Player2.GetComponent<Rigidbody>();
        P1RB.freezeRotation = true;
        P2RB.freezeRotation = true;
    }
    void Update()
    {
        WheelAnimationControls();
        ASM1.SetBool("Left", left1);
        ASM1.SetBool("Right", right1);
        ASM2.SetBool("Left", left2);
        ASM2.SetBool("Right", right2);
        Wheels1.SetBool("Accelerate", accel1);
        Wheels2.SetBool("Accelerate", accel2);
        Wheels1.SetBool("Reverse", reverse1);
        Wheels2.SetBool("Reverse", reverse2);
    }
    public void WheelAnimationControls()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {   accel1 = true; }
        if (Input.GetKeyUp(KeyCode.W))
        {   accel1 = false;}
        if (Input.GetKeyDown(KeyCode.S))
        { reverse1 = true; }
        if (Input.GetKeyUp(KeyCode.S))
        { reverse1 = false; }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        { accel2 = true; }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        { accel2 = false; }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        { reverse2 = true; }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        { reverse2 = false; }
    }

	public void Controls () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ASM1.SetTrigger("Spin");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            HookShot1.SetTrigger("ActivateHook");
        }
        if (Input.GetKey(KeyCode.W))
        {
            P1RB.AddRelativeForce(transform.forward * accel, ForceMode.Impulse);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            Player1.transform.Rotate(new Vector3(0, -rotateSpeed, 0));
        }
        if (Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
        {     left1 = true; }
        if (Input.GetKey(KeyCode.D))
        {
            Player1.transform.Rotate(new Vector3(0, rotateSpeed, 0));
        }
        if (Input.GetKeyDown(KeyCode.D) && !Input.GetKeyDown(KeyCode.A))
        {
            right1 = true; 
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left1 = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right1 = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            P1RB.AddRelativeForce(-transform.forward * accel, ForceMode.Impulse);
        }
        

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            ASM2.SetTrigger("Spin");
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            HookShot2.SetTrigger("ActivateHook");
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            P2RB.AddRelativeForce(transform.forward * accel, ForceMode.Impulse);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player2.transform.Rotate(new Vector3(0, -rotateSpeed, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            left2 = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player2.transform.Rotate(new Vector3(0, rotateSpeed, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
        {
            right2 = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left2 = false;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            right2 = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            P2RB.AddRelativeForce(-transform.forward * accel, ForceMode.Impulse);
        }
        
    }
}
