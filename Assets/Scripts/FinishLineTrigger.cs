using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class FinishLineTrigger : MonoBehaviour {
    SplitRaceMovement leftPlayer;
    SplitRaceMovement rightPlayer;
    string buttonName;

    void Awake() {
        leftPlayer = GameObject.Find("LeftPlayer").GetComponent<SplitRaceMovement>();
        rightPlayer = GameObject.Find("RightPlayer").GetComponent<SplitRaceMovement>();
    }

    private string whoWon;
    private string whoLost;
    private static bool winnerNoticed = false;
    private void OnTriggerExit(Collider other) {
        whoWon = other.gameObject.name;

        if (winnerNoticed) {
            if (whoLost.Equals("LeftPlayer")) {
                leftPlayer.StopTheVehicleSlowly();
                InGameCanvasBehaviour.SetLoserTime(leftPlayer.SetRaceTime());
            } else if (whoLost.Equals("RightPlayer")) {
                rightPlayer.StopTheVehicleSlowly();
                rightPlayer.SetRaceTime();
                InGameCanvasBehaviour.SetLoserTime(rightPlayer.SetRaceTime());
            }
        }

        if (whoWon.Equals("LeftPlayer") && !winnerNoticed) {
            whoLost = "RightPlayer";
            leftPlayer.StopTheVehicleSlowly();
            InGameCanvasBehaviour.SetWinnerTime(leftPlayer.SetRaceTime());
        } else if (whoWon.Equals("RightPlayer") && !winnerNoticed) {
            whoLost = "LeftPlayer";
            rightPlayer.StopTheVehicleSlowly();
            InGameCanvasBehaviour.SetWinnerTime(rightPlayer.SetRaceTime());
        }

        if (!winnerNoticed) {
            Debug.Log(whoWon + " won!");
            GameBehaviour.FinishGame(whoWon, whoLost);
            winnerNoticed = true;
        }
    }

    public static bool IsWinnerNoticed() {
        return winnerNoticed;
    }
}