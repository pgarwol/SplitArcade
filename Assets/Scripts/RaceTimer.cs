using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour {
    private float startTime;
    private bool isMeasuring;

    private void Start() {
        isMeasuring = false;
    }

    public void StartMeasurement() {
        if (!isMeasuring)
        {
            startTime = Time.time;
            isMeasuring = true;
        }
    }

    public void StopMeasurement() {
        if (isMeasuring) {
            float elapsedTime = Time.time - startTime;
            Debug.Log("Time: " + elapsedTime + "s");
           
            isMeasuring = false;
        }
    }
    
    public bool IsMeasuring() {
        return isMeasuring;
    }
}