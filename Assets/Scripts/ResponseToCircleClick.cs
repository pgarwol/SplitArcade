using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ResponseToCircleClick : MonoBehaviour {
    static SplitRaceMovement leftPlayer;
    static SplitRaceMovement rightPlayer;

    static NewRound leftSideCanvas;
    static NewRound rightSideCanvas;

    void Awake() {

        leftPlayer = GameObject.Find("LeftPlayer").GetComponent<SplitRaceMovement>();
        rightPlayer = GameObject.Find("RightPlayer").GetComponent<SplitRaceMovement>();

        leftSideCanvas = GameObject.Find("LeftAnswer").GetComponent<NewRound>();
        rightSideCanvas = GameObject.Find("RightAnswer").GetComponent<NewRound>();
    }

    public static void ResponseToClick(string screenSide, string tag) {
        // Debug.Log(screenSide + " " + tag);
        
        // -----------------------------------------
        // TODO: code repetition, add code to method
        // -----------------------------------------
        
        // Left Side of the screen clicked
        if (screenSide.Equals("LeftAnswer")) {
            if (tag.Equals("Good")) {
                leftPlayer.IncreaseSpeed();
                Debug.Log(leftPlayer.name + ", speed: " + leftPlayer.speed);
                InGameCanvasBehaviour.colorTMP.text = "";
                FinishRound();
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
                InGameCanvasBehaviour.colorTMP.text = "";
                FinishRound();
            }
            else {
                rightPlayer.DecreaseSpeed();
                Debug.Log(rightPlayer.name + ", speed: " + rightPlayer.speed);
            }
        }
    }

    private static void FinishRound() {
        RandomizeColor.randomized = false;
        leftSideCanvas.DestroyCandies();
        rightSideCanvas.DestroyCandies();
    } 
}
