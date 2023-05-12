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
    private void OnTriggerExit(Collider other) {
        whoWon = other.gameObject.name;
        Debug.Log(whoWon + " won!");

        GameBehaviour.FinishGame(whoWon);
        leftPlayer.StopTheVehicleSLowly();
        rightPlayer.StopTheVehicleSLowly();
    }

    

}
