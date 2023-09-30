using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ChosenColor : MonoBehaviour {
    public int chosenColorIndex;

    public void ShowChosenColor() {
        Debug.Log(chosenColorIndex);
    }

    public void SaveChosenColor(int x) {
        chosenColorIndex = x;
    }
}
