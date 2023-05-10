using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;


public class InGameCanvasBehaviour : MonoBehaviour {
    public static TextMeshProUGUI colorTMP;
    private static TextMeshProUGUI countdownText;

     void Awake() {
        colorTMP = GameObject.Find("Color").GetComponent<TextMeshProUGUI>();
        countdownText = GameObject.Find("CountdownText").GetComponent<TextMeshProUGUI>();
    }

    void Start() {
        InvokeRepeating("Countdown", 0f, 1.0f);
    }

    public static void UpdateColorTMP() {
        // Update the text of the TextMeshPro component
        colorTMP.text = RandomizeColor.randomizedColor;

        colorTMP.color = Color.white;
    }

    static int countdownCounter = 3;
    private void Countdown() {
        if (countdownCounter > 0) {
            switch (countdownCounter) {
                case 3: countdownText.color = Color.red; break;
                case 2: countdownText.color = new Color(1.0f, 0.5f, 0.0f); break;
                case 1: countdownText.color = Color.yellow; break;
                default: countdownText.color = Color.white; break;
            }

            countdownText.text = countdownCounter.ToString();
            countdownCounter--;
        } else if (countdownCounter == 0) {
            countdownText.color = Color.green;
            countdownText.text = "GO!";
            GameBehaviour.gameStarted = true;
            countdownCounter--;
        } else {
            countdownText.text = "";
        }

    }
    
}
