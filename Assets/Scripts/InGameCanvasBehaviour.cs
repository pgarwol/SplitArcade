using Random = UnityEngine.Random;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;


public class InGameCanvasBehaviour : MonoBehaviour {

    GameObject leftReadyButton;
    GameObject rightReadyButton;

    [SerializeField] private Sprite redLight;
    [SerializeField] private Sprite greenLight;
    [SerializeField] private Sprite yellowLight;
    private Image lightImage;

    [SerializeField] private AudioClip readySetSound;
    [SerializeField] private AudioClip goSound;

    private static TextMeshProUGUI leftColorTMP;
    private static TextMeshProUGUI rightColorTMP;
    
    private static TextMeshProUGUI countdownText;

    private static Canvas chooseColorCanvas;
    private static Canvas countdownCanvas;
    private static Canvas answerCanvas;
    private static Canvas gameResultCanvas;
    private static Canvas afterGameDecisionCanvas;

    private static TextMeshProUGUI winnerText;
    private static TextMeshProUGUI loserText;
    private static TextMeshProUGUI winnerTime;
    private static TextMeshProUGUI loserTime;

    public static List<Color> colors;

    void Awake() {
        // Color pick
        chooseColorCanvas = GameObject.Find("ChooseColorCanvas").GetComponent<Canvas>();
        leftReadyButton = GameObject.Find("LeftReadyButton");
        rightReadyButton = GameObject.Find("RightReadyButton");

        // Countdown
        lightImage = GameObject.Find("TrafficLight").GetComponent<Image>();
        countdownCanvas = GameObject.Find("Countdown").GetComponent<Canvas>();
        countdownCanvas.enabled = false;
        leftColorTMP = GameObject.Find("LeftColor").GetComponent<TextMeshProUGUI>();
        rightColorTMP = GameObject.Find("RightColor").GetComponent<TextMeshProUGUI>();
        countdownText = GameObject.Find("CountdownText").GetComponent<TextMeshProUGUI>();

        // Answers for both players
        answerCanvas = GameObject.Find("AnswerCanvas").GetComponent<Canvas>();

        // GameResult
        gameResultCanvas = GameObject.Find("GameResult").GetComponent<Canvas>();
        winnerText = GameObject.Find("WinnerText").GetComponent<TextMeshProUGUI>();
        loserText = GameObject.Find("LoserText").GetComponent<TextMeshProUGUI>();
        winnerTime = GameObject.Find("WinnerTime").GetComponent<TextMeshProUGUI>();
        loserTime = GameObject.Find("LoserTime").GetComponent<TextMeshProUGUI>();

        afterGameDecisionCanvas = GameObject.Find("AfterGameDecision").GetComponent<Canvas>();
        afterGameDecisionCanvas.enabled = false;
        gameResultCanvas.enabled = false;
        lightImage.enabled = true;

        colors = new List<Color> {
            new Color(65f, 105f, 225f),
            Color.blue,
            Color.green,
            new Color(255f, 105f, 180f),
            new Color(0.5f, 0f, 0.5f),
            Color.red,
            Color.yellow
        };
        
        countdownCounter = 2;
        GameBehaviour.SetIsGameStartedFalse();
    }

    void Start() {
        playersReady = false;
    }

    private void DisableChooseColorCanvas() {
        chooseColorCanvas.enabled = false;
        StartGame();
    }

    private void StartGame() {
        playersReady = false;
        countdownCanvas.enabled = true;
        InvokeRepeating("Countdown", 0f, 1.5f);
    }


    // -----[Players ready?]-----

    private bool leftPlayerReady;
    private bool rightPlayerReady;
    private bool playersReady;

    // LEFT

    public void LeftPlayerReadySetter() {
        if (leftPlayerReady) {
            SetLeftPlayerNotReady();
        }
        else {
            SetLeftPlayerReady();
        }  
    }

    public void SetLeftPlayerNotReady() {
        leftPlayerReady = false;

        // Change button looks
        leftReadyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Niegotowy";
        leftReadyButton.GetComponent<Image>().color = Color.red;//new Color(255, 97, 97);
    }

    public void SetLeftPlayerReady() {
        leftPlayerReady = true;
        CheckIfPlayersReady();

        // Change button looks
        leftReadyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Gotowy";
        leftReadyButton.GetComponent<Image>().color = Color.green;// new Color(84, 238, 55);
    }

    // RIGHT

    public void RightPlayerReadySetter() {
        if (rightPlayerReady) {
            SetRightlayerNotReady();
        }
        else {
            SetRightlayerReady();
        }
    }

    public void SetRightlayerNotReady() {
        rightPlayerReady = false;

        // Change button looks
        rightReadyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Niegotowy";
        rightReadyButton.GetComponent<Image>().color = Color.red;// new Color(255, 97, 97);
    }

    public void SetRightlayerReady() {
        rightPlayerReady = true;
        CheckIfPlayersReady();

        // Change button looks
        rightReadyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Gotowy";
        rightReadyButton.GetComponent<Image>().color = Color.green;// new Color(84, 238, 55);
    }


    private void CheckIfPlayersReady() {
        if (leftPlayerReady && rightPlayerReady) {
            Debug.Log("<color=#5af542><b> Both players ready </b></color>");
            leftReadyButton.GetComponent<Button>().enabled = false;
            rightReadyButton.GetComponent<Button>().enabled = false;
            Invoke("DisableChooseColorCanvas", 2f);
        }
    }

    // <<< COLORS >>>
    public static void UpdateColorTMP() {
        //colorTMP.text = RandomizeColor.randomizedColor;
        leftColorTMP.text = GetPolishColor(RandomizeColor.randomizedColor);
        rightColorTMP.text = GetPolishColor(RandomizeColor.randomizedColor);
        leftColorTMP.color = GetRandomColor();
        rightColorTMP.color = GetRandomColor();
    }
    
    private static Color GetRandomColor() {
        return colors[Random.Range(0, colors.Count)];
    }

    public static string GetPolishColor(string engColor) {
        switch (engColor) {
            case "blue": return "Niebieski";
            case "green": return "Zielony";
            case "pink": return "Rozowy"; // Różowy
            case "purple": return "Fioletowy";
            case "red": return "Czerwony";
            case "yellow": return "Zolty"; // Żółty
            default: return "";
        }
    }

    public static void SetColorTMP(string s) {
        leftColorTMP.text = s;
        rightColorTMP.text = s;
    }

    // <<< COUNTDOWN >>>
    private static int countdownCounter;

    private void Countdown() {
        if (countdownCounter == 2) {
            lightImage.sprite = redLight;
            countdownCounter--;
            SoundSystemSingleton.Instance.PlaySfxSound(readySetSound);
        }
        else if (countdownCounter == 1) {
            lightImage.sprite = yellowLight;
            countdownCounter--;
            SoundSystemSingleton.Instance.PlaySfxSound(readySetSound);
        }
        else if (countdownCounter == 0) {
            countdownText.color = Color.green;
            lightImage.sprite = greenLight;
            countdownText.text = "Jazda!";
            GameBehaviour.SetIsGameStartedTrue();
            countdownCounter--;
            SoundSystemSingleton.Instance.PlaySfxSound(goSound);
        } else {
            countdownText.text = "";
            lightImage.enabled = false;
            CancelInvoke();
            //Destroy(lightImage);
        }
    }

    // <<< SOMEONE WON: >>>
    public static void ShowAGDCanvas() {
        afterGameDecisionCanvas.enabled = true;
    }

    public static void ShowWinner(string winner, string loser) {
        answerCanvas.enabled = false;
        gameResultCanvas.enabled = true;
        winnerText.text = winner;
        winnerText.color = new Color(1.0f, 0.843f, 0.0f);
        loserText.text = loser;
        loserText.color = new Color(0.753f, 0.753f, 0.753f);
    }

    public static void SetWinnerTime(string raceTime) {
        winnerTime.text = CreateTimerOutput(raceTime);
        loserTime.text = "--:--:--";
    }

    public static void SetLoserTime(string raceTime) {
        loserTime.text = CreateTimerOutput(raceTime);
    }

    private static string CreateTimerOutput(string time) {
        string seconds = CalculateTime(time)[0];
        string minutes = CalculateTime(time)[1];
        string miliseconds = time.Substring(time.IndexOf(",") + 1, 2);

        return String.Format("{0}:{1}:{2}", minutes, seconds, miliseconds);
    }

    private static List<string> CalculateTime(string time) {
        string seconds;
        if (time.Substring(1, 1).Equals(","))
            seconds = time.Substring(0, 1);
        else
            seconds = time.Substring(0, 2);

        int secondsInteger = Int32.Parse(seconds);
        int minutes = secondsInteger / 60;
        if (secondsInteger > 60) {
            secondsInteger -= 60;

            if (secondsInteger < 10)
                seconds = "0" + secondsInteger.ToString();
            else secondsInteger.ToString();
                seconds = secondsInteger.ToString();
        }

        return new List<string> { seconds, minutes.ToString() };
    }
}
