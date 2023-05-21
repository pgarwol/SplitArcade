using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ResponseToCircleClick : MonoBehaviour {

    private static SplitRaceMovement leftPlayer;
    private static SplitRaceMovement rightPlayer;

    public static NewRound leftSideCanvas;
    public static NewRound rightSideCanvas;

    void Awake() {
        leftPlayer = GameObject.Find("LeftPlayer").GetComponent<SplitRaceMovement>();
        rightPlayer = GameObject.Find("RightPlayer").GetComponent<SplitRaceMovement>();

        leftSideCanvas = GameObject.Find("LeftAnswer").GetComponent<NewRound>();
        rightSideCanvas = GameObject.Find("RightAnswer").GetComponent<NewRound>();
    }

    public static void ResponseToClick(string screenSide, string tag) {
        // <<< Left Side of the screen >>>
        // For debugging purposes: Debug.Log(leftPlayer.name + ", speed: " + leftPlayer.speed);
        if (screenSide.Equals("LeftAnswer")) {
            if (tag.Equals("Good")) {
                leftPlayer.IncreaseSpeed();
                InGameCanvasBehaviour.SetColorTMP("");
                FinishRound();
            } else {
                leftPlayer.DecreaseSpeed();
            }
        }

        // <<< Right Side of the screen >>>
        if (screenSide.Equals("RightAnswer")) {
            if (tag.Equals("Good")) {
                rightPlayer.IncreaseSpeed();
                InGameCanvasBehaviour.SetColorTMP("");
                FinishRound();
            } else {
                rightPlayer.DecreaseSpeed();
            }
        }
    }
    // [!] Should it be here?
    public static void FinishRound() {
        RandomizeColor.SetIsRoundRandomizedToFalse();
        leftSideCanvas.DestroyCandies();
        rightSideCanvas.DestroyCandies();
    } 
}
