using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
	public GameObject PowerManager;

    public GameObject Player1;
    public GameObject Player2;

    public Animator ASM1; //Animator State Machine
    public Animator ASM2;

    public Animator Wheels1; //Animator State Machine
    public Animator Wheels2;

    public Animator HookShot1; //Animator State Machine
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

    public float joystick_turn_modifier = 2.5f;
    public float joystick_acceleration_modifier = 1.005f;
    public float brake_modifier = 2;

	public bool lockP1Movement = false;
	public bool lockP2Movement = false;

	private audioScript audioControlP1;
	private audioScript audioControlP2;

    private Rigidbody P1RB;
	private Rigidbody P2RB;

	private float p1DistToGoal;
	private float p2DistToGoal;
	private float playerDistance;
    private string test1;
    private string test2;

	private PowerManager pManager;

    // Use this for initialization
    void Start () {
        P1RB = Player1.GetComponent<Rigidbody>();
        P2RB = Player2.GetComponent<Rigidbody>();
        P1RB.freezeRotation = true;
        P2RB.freezeRotation = true;

		pManager = PowerManager.GetComponent<PowerManager> ();

		audioControlP1 = Player1.GetComponent<audioScript> ();
		audioControlP2 = Player2.GetComponent<audioScript> ();
    }
    void FixedUpdate()
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

		if (lockP1Movement)
			StartCoroutine (lockPlayer1 ());
		if (lockP2Movement)
			StartCoroutine (lockPlayer2 ());
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
			if (pManager.spinP1) {
				ASM1.SetTrigger ("Spin");
				pManager.spinP1 = false;
				pManager.p1CurrentPower = "None";
			} else if (pManager.hookshotP1) {
				HookShot1.SetTrigger ("ActivateHook");
				pManager.hookshotP1 = false;
				pManager.p1CurrentPower = "None";
			} else if (pManager.boostP1) {
				pManager.boostP1 = false;
				pManager.startBoostP1 = true;
				pManager.p1CurrentPower = "None";
			} else if (pManager.projectileP1) {
				pManager.projectileP1 = false;
				pManager.shootProjectileP1 = true;
				pManager.p1CurrentPower = "None";
			} else if (pManager.trapP1) {
				pManager.trapP1 = false;
				pManager.spawnTrapP1 = true;
				pManager.p1CurrentPower = "None";
			}
        }
        //################################################################
        //Accelerate
		if (Input.GetKeyDown (KeyCode.W) && !lockP1Movement) {
			audioControlP1.notPlayAccel = false;
			audioControlP1.playAccel = true;
		}

		if (Input.GetKeyUp (KeyCode.S) && !lockP1Movement) {
			audioControlP1.notPlayBackUp = true;
			audioControlP1.playBackUp = false;
		}
			
		if (xbox_a1 || Input.GetKey(KeyCode.W) && !lockP1Movement)
        {
			P1RB.AddRelativeForce(transform.forward * Player1Accel, ForceMode.Impulse);
        }
		else if (xbox_taxis1 < 0  && !lockP1Movement)
        {
            P1RB.AddRelativeForce(transform.forward * Player1Accel * ((-Input.GetAxis("Xbox1Trigger") * joystick_acceleration_modifier)), ForceMode.Impulse);
        }
        //################################################################
        //LeftTurn 
		if (xbox_hAxis1 < 0  && !lockP1Movement)
        {
            Player1.transform.Rotate(new Vector3(0, Input.GetAxis("Xbox1LeftStickHorizontal")* joystick_turn_modifier, 0));
        }
		else if (Input.GetKey(KeyCode.A) && !lockP1Movement)
        {
            Player1.transform.Rotate(new Vector3(0, -rotateSpeed, 0));
        }

		if (xbox_hAxis1 < 0||(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) && !lockP1Movement)
        { left1 = true; }
        else
        { left1 = false; }
        //##################################################################
        //RightTurn
		if (xbox_hAxis1 > 0  && !lockP1Movement)
        {
            Player1.transform.Rotate(new Vector3(0, Input.GetAxis("Xbox1LeftStickHorizontal")* joystick_turn_modifier, 0));
        }
		else if (Input.GetKey(KeyCode.D)  && !lockP1Movement)
        {
            Player1.transform.Rotate(new Vector3(0, rotateSpeed, 0));
        }

		if (xbox_hAxis1 > 0 || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) && !lockP1Movement)
        { right1 = true; }
        else
        { right1 = false; }
        //#################################################################
        //Reverse/Brake
		if (Input.GetKeyDown (KeyCode.S) && !lockP1Movement) {
			audioControlP1.notPlayBackUp = false;
			audioControlP1.playBackUp = true;
		}
			
		if (Input.GetKeyUp (KeyCode.W) && !lockP1Movement) {
			audioControlP1.notPlayAccel = true;
			audioControlP1.playAccel = false;
		}	

		if (xbox_b1 || Input.GetKey(KeyCode.S) && !lockP1Movement)
        {
            P1RB.AddRelativeForce(-transform.forward * Player1Accel * brake_modifier, ForceMode.Impulse);
        }
		else if (xbox_taxis1 > 0  && !lockP1Movement)
        {
            P1RB.AddRelativeForce(-transform.forward * Player1Accel * (Input.GetAxis("Xbox1Trigger")*joystick_acceleration_modifier)* brake_modifier, ForceMode.Impulse);
        }
        //=======================================================================================
        //Player2
        //=======================================================================================
        //item activations

		if (xbox_x2 || Input.GetKeyDown(KeyCode.RightShift))
        {
			if (pManager.spinP2) {
				ASM2.SetTrigger ("Spin");
				pManager.spinP2 = false;
				pManager.p2CurrentPower = "None";
			} else if (pManager.hookshotP2) {
				HookShot2.SetTrigger ("ActivateHook");
				pManager.hookshotP2 = false;
				pManager.p2CurrentPower = "None";
			} else if (pManager.boostP2) {
				pManager.boostP2 = false;
				pManager.startBoostP2 = true;
				pManager.p2CurrentPower = "None";
			} else if (pManager.projectileP2) {
				pManager.projectileP2 = false;
				pManager.shootProjectileP2 = true;
				pManager.p2CurrentPower = "None";
			} else if (pManager.trapP2) {
				pManager.trapP2 = false;
				pManager.spawnTrapP2 = true;
				pManager.p2CurrentPower = "None";
			}
		}
        //################################################################
        //Accelerate
		if (Input.GetKeyUp (KeyCode.DownArrow) && !lockP2Movement) {
			audioControlP2.notPlayBackUp = true;
			audioControlP2.playBackUp = false;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && !lockP2Movement) {
			audioControlP2.notPlayAccel = false;
			audioControlP2.playAccel = true;
		}

		if (xbox_a2 || Input.GetKey(KeyCode.UpArrow) && !lockP2Movement)
        {
            P2RB.AddRelativeForce(transform.forward * Player2Accel, ForceMode.Impulse);
        }
		else if (xbox_taxis2 < 0  && !lockP2Movement)
        {
            P2RB.AddRelativeForce(transform.forward * Player2Accel * ((-Input.GetAxis("Xbox2Trigger")) * joystick_acceleration_modifier), ForceMode.Impulse);
        }
        //################################################################
        //LeftTurn 
		if (xbox_hAxis2 < 0  && !lockP2Movement)
        {
            Player2.transform.Rotate(new Vector3(0, Input.GetAxis("Xbox2LeftStickHorizontal")* joystick_turn_modifier, 0));
        }
		else if (Input.GetKey(KeyCode.LeftArrow)  && !lockP2Movement)
        {
            Player2.transform.Rotate(new Vector3(0, -rotateSpeed, 0));
        }

		if (xbox_hAxis2 < 0 || (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))  && !lockP2Movement)
        { left2 = true; }
        else
        { left2 = false; }
        //##################################################################
        //RightTurn
		if (xbox_hAxis2 > 0  && !lockP2Movement)
        {
            Player2.transform.Rotate(new Vector3(0, Input.GetAxis("Xbox2LeftStickHorizontal")*joystick_turn_modifier, 0));
        }
		else if (Input.GetKey(KeyCode.RightArrow)  && !lockP2Movement)
        {
            Player2.transform.Rotate(new Vector3(0, rotateSpeed, 0));
        }

		if (xbox_hAxis2 > 0 || (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))  && !lockP2Movement)
        { right2 = true; }
        else
        { right2 = false; }
        //#################################################################
        //Reverse/Brake
		if (Input.GetKeyDown (KeyCode.DownArrow) && !lockP2Movement) {
			audioControlP2.notPlayBackUp = false;
			audioControlP2.playBackUp = true;
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) && !lockP2Movement) {
			audioControlP2.notPlayAccel = true;
			audioControlP2.playAccel = false;
		}

		if (xbox_b2 || Input.GetKey(KeyCode.DownArrow)  && !lockP2Movement)
        {
            P2RB.AddRelativeForce(-transform.forward * Player2Accel*brake_modifier, ForceMode.Impulse);
        }
		else if (xbox_taxis2 > 0  && !lockP2Movement)
        {
            P2RB.AddRelativeForce(-transform.forward * Player2Accel * (Input.GetAxis("Xbox2Trigger") * joystick_acceleration_modifier)* brake_modifier, ForceMode.Impulse);
        }
        //#################################################################
    }

	private IEnumerator lockPlayer1(){
		yield return new WaitForSeconds (2.0f);
		lockP1Movement = false;
	}

	private IEnumerator lockPlayer2(){
		yield return new WaitForSeconds (2.0f);
		lockP2Movement = false;
	}
}
