using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameCanvasBehaviour : MonoBehaviour {
    private static TextMeshProUGUI colorTMP;
     void Awake() {
        colorTMP = GameObject.Find("Color").GetComponent<TextMeshProUGUI>();
    }


    public static void UpdateColorTMP() {
        // Update the text of the TextMeshPro component
        colorTMP.text = RandomizeColor.randomizedColor;
        colorTMP.color = Color.white;
    }
}
