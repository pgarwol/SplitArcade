using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class DebugScript : MonoBehaviour {
    SplitRaceMovement leftPlayer;
    SplitRaceMovement rightPlayer;
    string buttonName;

    void Awake() {
        buttonName = gameObject.name;

        leftPlayer = GameObject.Find("LeftPlayer").GetComponent<SplitRaceMovement>();
        rightPlayer = GameObject.Find("RightPlayer").GetComponent<SplitRaceMovement>();
    }

    public void IncreaseSpeedDebug() {
        // Left Player
        if (buttonName.Equals("LeftFasterDebug")) {
            leftPlayer.IncreaseSpeed();
            Debug.Log(leftPlayer.name + ", speed: " + leftPlayer.speed);
        }

        // Right Player
        if (buttonName.Equals("RightFasterDebug")) {
            rightPlayer.IncreaseSpeed();
            Debug.Log(rightPlayer.name + ", speed: " + rightPlayer.speed);
        }
    }

    public void DecreaseSpeedDebug() {
        // Left Player
        if (buttonName.Equals("LeftSlowerDebug")) {
            leftPlayer.DecreaseSpeed();
            Debug.Log(leftPlayer.name + ", speed: " + leftPlayer.speed);
        }

        // Right Player
        if (buttonName.Equals("RightSlowerDebug")) {
            rightPlayer.DecreaseSpeed();
            Debug.Log(rightPlayer.name + ", speed: " + rightPlayer.speed);
        }
    }
}
