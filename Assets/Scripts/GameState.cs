using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameState : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;

    public GameObject[] ItemBlocks = new GameObject[] { };

    public GameObject StartButton;
    public GameObject ResumeButton;
    public GameObject MenuButton;
    public GameObject RestartButton;

	public GameObject CountDownText;

    public GameObject PowerManager;

    Vector3 startpos1;
    Vector3 startpos2;
    Quaternion startrot1;
    Quaternion startrot2;
    public GameObject Controls;
    public Camera PauseCamera;
    public Camera MenuCamera;
    public Camera Player1Camera;
    public Camera Player2Camera;

    public Text EscButtonText;
    public Text TimeRemainingText;
    public Text WinnerText;

    public bool StartGame = false;
    public bool PauseGame = false;
    public bool TimedOut = false;
    public bool GameWon = false;

    public int globalClock;
    public int timeDecay = 1;

    public bool startedGlobalTimeCourtine = false;

    public int totalTime = 100;

    public int level = 0; //NotImplemented

    public bool RedWinner = false;
    public bool BlueWinner = false;
    public bool NoWinner = false;
	public bool playStartTimer = true;

    private IEnumerator globalTimeCoroutine;
    public Vector3 lastPlayer1Velocity;
    public Vector3 lastPlayer2Velocity;
    public Vector3 lastPlayer1Position;
    public Vector3 lastPlayer2Position;

    public bool reset = false;

    private float lastP1ClockTime;
    private float lastP2ClockTime;

	private CountDown countDown;

    // Use this for initialization
    void Start () {
        TimeRemainingText.enabled = false;
        EscButtonText.enabled = false;
        globalClock = totalTime;
        globalTimeCoroutine = TimeLossRate();
        PauseCamera.enabled = false;
        MenuCamera.enabled = true;
        Player1Camera.enabled = false;
        Player2Camera.enabled = false;
        startpos1 = Player1.transform.position;
        startpos2 = Player2.transform.position;
        startrot1 = Player1.transform.rotation;
        startrot2 = Player2.transform.rotation;

		countDown = CountDownText.GetComponent<CountDown> ();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (PauseGame)
        {
            PowerManager.GetComponent<PowerManager>().boostTimeP1 = lastP1ClockTime;
            PowerManager.GetComponent<PowerManager>().boostTimeP2 = lastP2ClockTime;
            Player1.transform.position = lastPlayer1Position;
            Player2.transform.position = lastPlayer2Position;
            if (startedGlobalTimeCourtine) //If the Timer was started.
            {   //Stop the Countdown Timer if the game is Paused.
                StopAllCoroutines();
                startedGlobalTimeCourtine = false;
            }
            if (Input.GetButtonDown("Xbox1Start") || Input.GetButtonDown("Xbox2Start") || Input.GetKeyDown(KeyCode.Space))
            {
                ResumeButton.GetComponent<ResumeButton>().OnMouseDown();
            }
            if (Input.GetButtonDown("Xbox1Back") || Input.GetButtonDown("Xbox2Back") || Input.GetKeyDown(KeyCode.Return))
            {
                MenuButton.GetComponent<MenuButton>().OnMouseDown();
            }
            if (Input.GetButtonDown("Xbox1LB") || Input.GetButtonDown("Xbox2LB") || Input.GetKeyDown(KeyCode.Backspace))
            {
                RestartButton.GetComponent<RestartButton>().OnMouseDown();
            }
        }
        else if (StartGame)
        {
            reset = false;

			if (playStartTimer) {
				playStartTimer = false;
				GetComponent<AudioSource> ().Play ();
			}
            
            if (RedWinner)
            {
                WinnerText.text = "Player1 Wins!";
                WinnerText.color = Color.red;
            }
            else if (BlueWinner)
            {
                WinnerText.text = "Player2 Wins!";
                WinnerText.color = Color.blue;
            }
            WinnerText.enabled = true;
            EscButtonText.enabled = true;
            TimeRemainingText.enabled = true;
            TimeRemainingText.text = "Time Remaining: " + globalClock.ToString();
            if (Input.GetButtonDown("Xbox1Start") || Input.GetButtonDown("Xbox2Start") || Input.GetKeyDown(KeyCode.Escape))
            {
                lastP1ClockTime = PowerManager.GetComponent<PowerManager>().boostTimeP1;
                lastP2ClockTime = PowerManager.GetComponent<PowerManager>().boostTimeP2;
                lastPlayer1Velocity = Player1.GetComponent<Rigidbody>().velocity;
                lastPlayer2Velocity = Player2.GetComponent<Rigidbody>().velocity;
                lastPlayer1Position = Player1.transform.position;
                lastPlayer2Position = Player2.transform.position;
                Player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
                PauseGame = true;
                PauseCamera.enabled = true;
                EscButtonText.enabled = false;
                TimeRemainingText.enabled = false;
                WinnerText.enabled = false;
            }
            if (Input.GetButtonDown("Xbox1LB") || Input.GetButtonDown("Xbox2LB") || Input.GetKeyDown(KeyCode.Backspace))
            {
                RestartButton.GetComponent<RestartButton>().OnMouseDown();
            }
            if (globalClock == 0 || GameWon)
            {   //When the Timer reaches zero
                StopCoroutine(globalTimeCoroutine);
                StopAllCoroutines();
                if (globalClock == 0 && !GameWon)
                {
                    TimedOut = true;
                    WinnerText.text = "Out of Time!";
                    WinnerText.color = Color.white;
                }
            }
            else
            {
                if (!startedGlobalTimeCourtine && !PauseGame && !TimedOut && !GameWon)
                {
                    StartCoroutine(globalTimeCoroutine);
                    startedGlobalTimeCourtine = true;
                }
                
                if (globalClock<=totalTime-1)
                {
                    Controls.GetComponent<PlayerMovementController>().Controls();
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Xbox1Start") || Input.GetButtonDown("Xbox2Start") || Input.GetKeyDown(KeyCode.Space))
            {
                StartButton.GetComponent<StartButton>().OnMouseDown();
            }
        }
    }

    void globalTimeDecay()
    {
		if(countDown.countFinished)
        	globalClock += -(timeDecay);
    }

    IEnumerator TimeLossRate()
    {
		while (true)
        {
            yield return new WaitForSeconds(1);
            globalTimeDecay();
        }
    }

    public void ResetVariables()
    {
        reset = true;
        RedWinner = false;
        BlueWinner = false;
        NoWinner = false;
        TimedOut = false;
        PauseCamera.enabled = false;
        MenuCamera.enabled = true;
        Player1Camera.enabled = false;
        Player2Camera.enabled = false;

        globalClock = totalTime;
        StopAllCoroutines();
        startedGlobalTimeCourtine = false;
        level = 0;
        GameWon = false;    
        StartGame = false;
        PauseGame = false;
        playStartTimer = true;
        PauseCamera.enabled = false;
        WinnerText.text = "";
        EscButtonText.enabled = false;
        TimeRemainingText.enabled = false;
        Player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Player1.transform.position = startpos1;
        Player2.transform.position = startpos2;
        Player1.transform.rotation = startrot1;
        Player2.transform.rotation = startrot2;
        Controls.GetComponent<PlayerMovementController>().right1 = false;
        Controls.GetComponent<PlayerMovementController>().right2 = false;
        Controls.GetComponent<PlayerMovementController>().left1 = false;
        Controls.GetComponent<PlayerMovementController>().left2 = false;
        PowerManager.GetComponent<PowerManager>().p1CurrentPower = "None";
        PowerManager.GetComponent<PowerManager>().p2CurrentPower = "None";
        PowerManager.GetComponent<PowerManager>().boostP1 = false;
        PowerManager.GetComponent<PowerManager>().boostP2 = false;
        for (int i = 0; i < ItemBlocks.Length; ++i)
        {
            ItemBlocks[i].GetComponent<MeshRenderer>().enabled = true;
            ItemBlocks[i].GetComponent<BoxCollider>().enabled = true;
            ItemBlocks[i].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
