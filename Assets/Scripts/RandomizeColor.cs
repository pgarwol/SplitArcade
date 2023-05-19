using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class RandomizeColor : MonoBehaviour {
    private static string blue = "blue";
    private static string green = "green";
    private static string pink = "pink";
    private static string purple = "purple";
    private static string red = "red";
    private static string yellow = "yellow";

    private static List<string> possibilities = new List<string> { blue, green, pink, purple, red, yellow };

    private static int randomIndex;
    public static string randomizedColor;
    public static int correctColorIndex;

    public static bool randomized = false;

    public static void RndColor() {
        if (!randomized) {
            randomIndex = Random.Range(0, possibilities.Count);
            randomizedColor = possibilities[randomIndex];
            // Debug.Log("Randomized color: " + randomizedColor);

            correctColorIndex = possibilities.IndexOf(randomizedColor);
            InGameCanvasBehaviour.UpdateColorTMP();

            randomized = true;
        }
    }

    public static int GetCorrectColorIndex() {
        return correctColorIndex;
    }
}
