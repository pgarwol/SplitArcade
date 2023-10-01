using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ColorUI : MonoBehaviour {
    
    public int colorIndex;
    
    GameObject obj;
    BoatMaterialChanger bMC;

    void Start() {
        obj = GameObject.Find("ChangeBoatMaterial");
        bMC = obj.GetComponent<BoatMaterialChanger>();
    }

    private char numberChar;

    public void SaveColorIndex() {
        numberChar = gameObject.name[gameObject.name.Length - 2];
        colorIndex = numberChar - '0';
        bMC.ChangeBoatMaterial(GetParentName(), colorIndex);
    }

    private string GetParentName() {
        return transform.parent.name;
    }
}
