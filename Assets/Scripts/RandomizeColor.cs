using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class RandomizeColor : MonoBehaviour {

    private static List<string> possibilities = new List<string> { "blue", "green", "pink", "purple", "red", "yellow" };

    public static string randomizedColor;
    public static int correctColorIndex;
    private static int randomIndex;

    private static bool isRoundRandomized = false;

    public static void RndColor() {
        if (!isRoundRandomized) {
            randomIndex = Random.Range(0, possibilities.Count);
            randomizedColor = possibilities[randomIndex];

            correctColorIndex = possibilities.IndexOf(randomizedColor);
            InGameCanvasBehaviour.UpdateColorTMP();

            isRoundRandomized = true;
        }
    }

    public static void SetIsRoundRandomizedToFalse() {
        isRoundRandomized = false;
    }

    public static int GetCorrectColorIndex() {
        return correctColorIndex;
    }
}
