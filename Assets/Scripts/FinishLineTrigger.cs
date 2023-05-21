using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class FinishLineTrigger : MonoBehaviour {

    private SplitRaceMovement leftPlayer;
    private SplitRaceMovement rightPlayer;

    private string buttonName;

    private string whoWon;
    private string whoLost;
    private static bool winnerNoticed = false;

    void Awake() {
        leftPlayer = GameObject.Find("LeftPlayer").GetComponent<SplitRaceMovement>();
        rightPlayer = GameObject.Find("RightPlayer").GetComponent<SplitRaceMovement>();
    }

    private void OnTriggerExit(Collider other) {
        whoWon = other.gameObject.name;

        if (winnerNoticed) {
            if (whoLost.Equals("LeftPlayer")) {
                rightPlayer.SetRaceTime();
                SetLoserTimeAndSlowDown(leftPlayer);
            } else if (whoLost.Equals("RightPlayer")) {
                rightPlayer.SetRaceTime();
                SetLoserTimeAndSlowDown(rightPlayer);
            }
        }

        if (whoWon.Equals("LeftPlayer") && !winnerNoticed) {
            whoLost = "RightPlayer";
            SetWinnerTimeAndSlowDown(leftPlayer);
        } else if (whoWon.Equals("RightPlayer") && !winnerNoticed) {
            whoLost = "LeftPlayer";
            SetWinnerTimeAndSlowDown(rightPlayer);
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

    private void SetWinnerTimeAndSlowDown(SplitRaceMovement player) {
        player.StopTheVehicleSlowly();
        InGameCanvasBehaviour.SetWinnerTime(player.SetRaceTime());
    }

    private void SetLoserTimeAndSlowDown(SplitRaceMovement player) {
        player.StopTheVehicleSlowly();
        InGameCanvasBehaviour.SetLoserTime(player.SetRaceTime());
    }
}