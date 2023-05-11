using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class FinishLineTrigger : MonoBehaviour {
    private void OnTriggerExit(Collider other) {
        Debug.Log(other.gameObject.name + " won!");
    }

}
