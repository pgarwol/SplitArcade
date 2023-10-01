using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class BoatMaterialChanger : MonoBehaviour {

    public Material[] boatMaterials;
    public Material[] darkerBoatMaterials;

    private GameObject boatGO;
    Transform boatTransform;
    GameObject hull;
    GameObject[] sits = new GameObject[2];

    Material[] newMaterials = new Material[2];

    public void ChangeBoatMaterial(string n, int index) {
        boatGO = FindCorrectBoatGO(n);
        newMaterials[0] = boatMaterials[index];
        newMaterials[1] = boatMaterials[index];

        boatTransform = boatGO.transform.GetChild(1);
        //Debug.Log(boatTransform.transform.GetChild(2).gameObject);
        hull = boatTransform.transform.GetChild(0).gameObject;
        sits[0] = boatTransform.transform.GetChild(1).gameObject;
        sits[1] = boatTransform.transform.GetChild(2).gameObject;

        ChangeHullColor();
        ChangeSitsColor(index);
    }

    GameObject correctBoatGO;

    private GameObject FindCorrectBoatGO(string N) {
        correctBoatGO = GameObject.FindWithTag(DirectionString(N) + "Player");
        if (correctBoatGO == null)
            return new GameObject();
        else
            return correctBoatGO;
    }

    private string DirectionString(string fullName) {
        if (fullName[0] == 'L') {
            return fullName.Substring(0, 4);
        } else {
            return fullName.Substring(0, 5);
        }
    }

    private void ChangeHullColor() {
        hull.GetComponent<MeshRenderer>().materials = newMaterials;
    }

    private void ChangeSitsColor(int idx) {
        foreach (GameObject sit in sits) {
            sit.GetComponent<MeshRenderer>().material = darkerBoatMaterials[idx];
        }
    }

}
