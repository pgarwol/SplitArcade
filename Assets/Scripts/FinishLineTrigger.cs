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
    private void OnTriggerExit(Collider other) {
        whoWon = other.gameObject.name;
        if (whoWon.Equals("LeftPlayer"))
            whoLost = "RightPlayer";
        else if (whoWon.Equals("RightPlayer"))
            whoLost = "LeftPlayer";

        Debug.Log(whoWon + " won!");

        GameBehaviour.FinishGame(whoWon, whoLost);
        leftPlayer.StopTheVehicleSLowly();
        rightPlayer.StopTheVehicleSLowly();

        Destroy(gameObject);
    }

    

}
