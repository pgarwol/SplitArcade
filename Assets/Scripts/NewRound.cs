using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRound : MonoBehaviour {
    public Canvas roundCanvas;
    private static bool destroyedCandies = false;
    static GameBehaviour gB1;
    static GameBehaviour gB2;

    void Awake() {
        gB1 = GameObject.Find("LeftAnswer").GetComponent<GameBehaviour>();
        gB2 = GameObject.Find("RightAnswer").GetComponent<GameBehaviour>();
    }

    public void DestroyCandies() {
        foreach (Transform childTransform in roundCanvas.transform) {
            // Destroy the child game object
            Destroy(childTransform.gameObject);
        }
        destroyedCandies = true;
    }

    void Update() {
        if (destroyedCandies) {
            Debug.Log("pyk");

            destroyedCandies = false;

            gB1.goodCircleTagged = false;
            gB2.goodCircleTagged = false;

            gB1.InitializeRound();
            gB2.InitializeRound();
        }
    }

    
}
