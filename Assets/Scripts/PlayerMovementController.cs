using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public GameObject Player1;
    public GameObject Player2;
	public GameObject Goal;

    public Animator ASM1; //Animator State Machine
    public Animator ASM2;

    public Animator Wheels1; //Animator State Machine
    public Animator Wheels2;

    public Animator HookShot1;
    public Animator HookShot2;

    public float Player1Accel;
	public float Player2Accel;
    public float rotateSpeed;


    public bool left1 = false;
    public bool right1 = false;
    public bool left2 = false;
    public bool right2 = false;

    public bool accel1 = false;
    public bool accel2 = false;
    public bool reverse1 = false;
    public bool reverse2 = false;
    
    public double xbox_taxis1;
    public double xbox_dhaxis1;
    public double xbox_dvaxis1;
    public double xbox_hAxis1;
    public double xbox_vAxis1;
    public bool xbox_a1;
    public bool xbox_b1;
    public bool xbox_x1;
    public bool xbox_y1;
    public bool xbox_lb1;
    public bool xbox_rb1;
    public bool xbox_ls1;
    public bool xbox_rs1;
    public bool xbox_back1;
    public bool xbox_start1;

    public double xbox_taxis2;
    public double xbox_dhaxis2;
    public double xbox_dvaxis2;
    public double xbox_hAxis2;
    public double xbox_vAxis2;
    public bool xbox_a2;
    public bool xbox_b2;
    public bool xbox_x2;
    public bool xbox_y2;
    public bool xbox_lb2;
    public bool xbox_rb2;
    public bool xbox_ls2;
    public bool xbox_rs2;
    public bool xbox_back2;
    public bool xbox_start2;

	private Rigidbody P1RB;
	private Rigidbody P2RB;

	private bool spin1 = false;
	private bool spin2 = false;
	private bool spinanimating1 = false;
	private bool spinanimating2 = false;

	private bool hookshot1 = false;
	private bool hookshot2 = false;
	private bool hookshotanimating1 = false;
	private bool hookshotanimating2 = false;

	private float p1DistToGoal;
	private float p2DistToGoal;
	private float playerDistance;

	private double deadspace = .005;

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
        //names                                      //+value = left trigger
        xbox_taxis1 = Input.GetAxis("Xbox1Trigger"); //-value = right trigger
        xbox_dhaxis1 = Input.GetAxis("Xbox1DpadHorizontal");
        xbox_dvaxis1 = Input.GetAxis("Xbox1DpadVertical");
        xbox_hAxis1 = Input.GetAxis("Xbox1LeftStickHorizontal");
        xbox_vAxis1 = Input.GetAxis("Xbox1LeftStickVertical");
        xbox_a1 = Input.GetButton("Xbox1A");
        xbox_b1 = Input.GetButton("Xbox1B");
        xbox_x1 = Input.GetButtonDown("Xbox1X");
        xbox_y1 = Input.GetButtonDown("Xbox1Y");
        xbox_lb1 = Input.GetButtonDown("Xbox1LB");
        xbox_rb1 = Input.GetButtonDown("Xbox1RB");
        xbox_ls1 = Input.GetButtonDown("Xbox1LeftStickButton");
        xbox_rs1 = Input.GetButtonDown("Xbox1RightStickButton");
        xbox_back1 = Input.GetButtonDown("Xbox1Back");
        xbox_start1 = Input.GetButtonDown("Xbox1Start");

        xbox_taxis2 = Input.GetAxis("Xbox2Trigger"); //-value = right trigger
        xbox_dhaxis2 = Input.GetAxis("Xbox2DpadHorizontal");
        xbox_dvaxis2 = Input.GetAxis("Xbox2DpadVertical");
        xbox_hAxis2 = Input.GetAxis("Xbox2LeftStickHorizontal");
        xbox_vAxis2 = Input.GetAxis("Xbox2LeftStickVertical");
        xbox_a2 = Input.GetButton("Xbox2A");
        xbox_b2 = Input.GetButton("Xbox2B");
        xbox_x2 = Input.GetButtonDown("Xbox2X");
        xbox_y2 = Input.GetButtonDown("Xbox2Y");
        xbox_lb2 = Input.GetButtonDown("Xbox2LB");
        xbox_rb2 = Input.GetButtonDown("Xbox2RB");
        xbox_ls2 = Input.GetButtonDown("Xbox2LeftStickButton");
        xbox_rs2 = Input.GetButtonDown("Xbox2RightStickButton");
        xbox_back2 = Input.GetButtonDown("Xbox2Back");
        xbox_start2 = Input.GetButtonDown("Xbox2Start");

    }
    public void WheelAnimationControls()
    {
        if (xbox_a1 || xbox_taxis1 < 0 || Input.GetKey(KeyCode.W))
        {   accel1 = true; }
        else
        {   accel1 = false;}
        if (xbox_b1 || xbox_taxis1 > 0 || Input.GetKey(KeyCode.S))
        { reverse1 = true; }
        else
        { reverse1 = false; }

        if (xbox_a2 || xbox_taxis2 < 0 || Input.GetKey(KeyCode.UpArrow))
        { accel2 = true; }
        else
        { accel2 = false; }
        if (xbox_b2 || xbox_taxis2 > 0 || Input.GetKey(KeyCode.DownArrow))
        { reverse2 = true; }
        else
        { reverse2 = false; }
    }

	public void Controls () {
        //################################################################
        //item activations
        if (xbox_x1 || Input.GetKeyDown(KeyCode.E))
        {
            ASM1.SetTrigger("Spin");
        }
        if (xbox_rb1 || Input.GetKeyDown(KeyCode.R))
        {
            HookShot1.SetTrigger("ActivateHook");
        }
        //################################################################
        //Accelerate
        if (xbox_a1 || Input.GetKey(KeyCode.W))
        {
			P1RB.AddRelativeForce(transform.forward * Player1Accel, ForceMode.Impulse);
        }
        else if (xbox_taxis1 < 0)
        {
            P1RB.AddRelativeForce(transform.forward * Player1Accel * (-Input.GetAxis("Xbox1Trigger")), ForceMode.Impulse);
        }
        //################################################################
        //LeftTurn 
        if (xbox_hAxis1 < 0)
        {
            Player1.transform.Rotate(new Vector3(0, Input.GetAxis("Xbox1LeftStickHorizontal"), 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Player1.transform.Rotate(new Vector3(0, -rotateSpeed, 0));
        }

        if (xbox_hAxis1 < 0||(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)))
        { left1 = true; }
        else
        { left1 = false; }
        //##################################################################
        //RightTurn
        if (xbox_hAxis1 > 0)
        {
            Player1.transform.Rotate(new Vector3(0, Input.GetAxis("Xbox1LeftStickHorizontal"), 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Player1.transform.Rotate(new Vector3(0, rotateSpeed, 0));
        }

        if (xbox_hAxis1 > 0 || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)))
        { right1 = true; }
        else
        { right1 = false; }
        //#################################################################
        //Reverse/Brake
        if (xbox_b1 || Input.GetKey(KeyCode.S))
        {
            P1RB.AddRelativeForce(-transform.forward * Player1Accel, ForceMode.Impulse);
        }
        else if (xbox_taxis1 > 0)
        {
            P1RB.AddRelativeForce(-transform.forward * Player1Accel * Input.GetAxis("Xbox1Trigger"), ForceMode.Impulse);
        }
        //=======================================================================================
        //Player2
        //=======================================================================================
        //item activations
        if (xbox_x2 || Input.GetKeyDown(KeyCode.RightControl))
        {
            ASM2.SetTrigger("Spin");
        }
        if (xbox_rb2 || Input.GetKeyDown(KeyCode.RightShift))
        {
            HookShot2.SetTrigger("ActivateHook");
        }
        //################################################################
        //Accelerate
        if (xbox_a2 || Input.GetKey(KeyCode.UpArrow))
        {
            P2RB.AddRelativeForce(transform.forward * Player2Accel, ForceMode.Impulse);
        }
        else if (xbox_taxis2 < 0)
        {
            P2RB.AddRelativeForce(transform.forward * Player2Accel * (-Input.GetAxis("Xbox2Trigger")), ForceMode.Impulse);
        }
        //################################################################
        //LeftTurn 
        if (xbox_hAxis2 < 0)
        {
            Player2.transform.Rotate(new Vector3(0, Input.GetAxis("Xbox2LeftStickHorizontal"), 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player2.transform.Rotate(new Vector3(0, -rotateSpeed, 0));
        }

        if (xbox_hAxis2 < 0 || (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)))
        { left2 = true; }
        else
        { left2 = false; }
        //##################################################################
        //RightTurn
        if (xbox_hAxis2 > 0)
        {
            Player2.transform.Rotate(new Vector3(0, Input.GetAxis("Xbox2LeftStickHorizontal"), 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Player2.transform.Rotate(new Vector3(0, rotateSpeed, 0));
        }

        if (xbox_hAxis2 > 0 || (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)))
        { right2 = true; }
        else
        { right2 = false; }
        //#################################################################
        //Reverse/Brake
        if (xbox_b2 || Input.GetKey(KeyCode.DownArrow))
        {
            P2RB.AddRelativeForce(-transform.forward * Player2Accel, ForceMode.Impulse);
        }
        else if (xbox_taxis2 > 0)
        {
            P2RB.AddRelativeForce(-transform.forward * Player2Accel * Input.GetAxis("Xbox2Trigger"), ForceMode.Impulse);
        }
        //#################################################################
    }
}
