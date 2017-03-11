using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Joystick1Test : MonoBehaviour {
    public Text DebugText;
    float hAxis;
    float vAxis;


    void ControllerCheck()
    {
        float taxis = Input.GetAxis("Xbox1Trigger");
        float dhaxis = Input.GetAxis("Xbox1DpadHorizontal");
        float dvaxis = Input.GetAxis("Xbox1DpadVertical");

        bool xbox_a = Input.GetButton("Xbox1A");
        bool xbox_b = Input.GetButton("Xbox1B");
        bool xbox_x = Input.GetButton("Xbox1X");
        bool xbox_y = Input.GetButton("Xbox1Y");
        bool xbox_lb = Input.GetButton("Xbox1LB");
        bool xbox_rb = Input.GetButton("Xbox1RB");
        bool xbox_ls = Input.GetButton("Xbox1LeftStickButton");
        bool xbox_rs = Input.GetButton("Xbox1RightStickButton");
        bool xbox_view = Input.GetButton("Xbox1Back");
        bool xbox_menu = Input.GetButton("Xbox1Start");

        DebugText.text =
            string.Format(
                "Horizontal: {13:0.000} Vertical: {14:0.000}\n" +
                "Trigger: {0:0.000}\n" +
                "A: {1} B: {2} X: {3} Y:{4}\n" +
                "LB: {5} RB: {6} LS: {7} RS:{8}\n" +
                "Back: {9} Start: {10}\n" +
                "Dpad-H: {11:0.000} Dpad-V: {12:0.000}\n",
                taxis,
                xbox_a, xbox_b, xbox_x, xbox_y,
                xbox_lb, xbox_rb, xbox_ls, xbox_rs,
                xbox_view, xbox_menu,
                dhaxis, dvaxis,
                hAxis, vAxis);
    }

    void FixedUpdate()
    {
        hAxis = Input.GetAxis("Xbox1LeftStickHorizontal");
        vAxis = Input.GetAxis("Xbox1LeftStickVertical");
        ControllerCheck();
    }
}
