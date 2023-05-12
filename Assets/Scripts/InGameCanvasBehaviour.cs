using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;


public class InGameCanvasBehaviour : MonoBehaviour {
    public static TextMeshProUGUI colorTMP;
    private static TextMeshProUGUI countdownText;

    public static Canvas gameResult;
    private static TextMeshProUGUI winnerText;

    private static Canvas answerCanvas;

    void Awake() {
        // Countdown
        colorTMP = GameObject.Find("Color").GetComponent<TextMeshProUGUI>();
        countdownText = GameObject.Find("CountdownText").GetComponent<TextMeshProUGUI>();

        // Answers for both players
        answerCanvas = GameObject.Find("AnswerCanvas").GetComponent<Canvas>();

        // GameResult
        gameResult = GameObject.Find("GameResult").GetComponent<Canvas>();
        winnerText = GameObject.Find("WinnerText").GetComponent<TextMeshProUGUI>();

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


    
    public static void ShowWinner(string winner) {
        answerCanvas.enabled = false;
        winnerText.text = winner;

    }
    
}
