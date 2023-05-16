using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    // <<< MENU SCENE >>>
    public void PlayBoatGame() {
        SceneManager.LoadScene("SplitRaceBoats");
    }


    // <<< BOAT GAME SCENE >>>
    public void RestartBoatGame() {
        
    }
    
    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
