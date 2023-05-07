using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ResponseToCircleClick : MonoBehaviour {
    static SplitRaceMovement leftPlayer;
    static SplitRaceMovement rightPlayer;

    void Awake() {
        leftPlayer = GameObject.Find("LeftPlayer").GetComponent<SplitRaceMovement>();
        rightPlayer = GameObject.Find("RightPlayer").GetComponent<SplitRaceMovement>();
    }

    public static void ResponseToClick(string screenSide, string tag) {
        // Debug.Log(screenSide + " " + tag);

        // Left Side of the screen clicked
        if (screenSide.Equals("LeftAnswer")) {
            if (tag.Equals("Good")) {
                leftPlayer.IncreaseSpeed();
                Debug.Log(leftPlayer.name + ", speed: " + leftPlayer.speed);
            } else {
                leftPlayer.DecreaseSpeed();
                Debug.Log(leftPlayer.name + ", speed: " + leftPlayer.speed);
            }
        }

        // Right Side of the screen clicked
        if (screenSide.Equals("RightAnswer")) {
            if (tag.Equals("Good")) {
                rightPlayer.IncreaseSpeed();
                Debug.Log(rightPlayer.name + ", speed: " + rightPlayer.speed);
            }
            else {
                rightPlayer.DecreaseSpeed();
                Debug.Log(rightPlayer.name + ", speed: " + rightPlayer.speed);
            }
        }


    }
}
