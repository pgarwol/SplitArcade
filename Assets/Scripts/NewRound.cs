using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class NewRound : MonoBehaviour {
    
    private static bool wereCandiesDestroyed = false;

    public Canvas roundCanvas;

    private static GameBehaviour gB1;
    private static GameBehaviour gB2;

    void Awake() {
        gB1 = GameObject.Find("LeftAnswer").GetComponent<GameBehaviour>();
        gB2 = GameObject.Find("RightAnswer").GetComponent<GameBehaviour>();
    }

    void Update() {
        if (wereCandiesDestroyed) {
            wereCandiesDestroyed = false;

            gB1.SetGoodCandyTaggedFalse();
            gB2.SetGoodCandyTaggedFalse();

            gB1.InitializeRoundDelay();
            gB2.InitializeRoundDelay();    
        }
    }   

    public void DestroyCandies() {
        foreach (Transform childTransform in roundCanvas.transform) {
            Destroy(childTransform.gameObject);
        }

        wereCandiesDestroyed = true;
    }
}
