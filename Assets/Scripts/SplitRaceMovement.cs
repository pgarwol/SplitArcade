using UnityEngine.SceneManagement;
using UnityEngine;
using System;


public class SplitRaceMovement : MonoBehaviour {
    
    public Rigidbody rb;

    [SerializeField] private float transitionSpeed = 8f;
    [SerializeField] public float speed = 100f;

    [SerializeField] private AudioClip splashSound;
    [SerializeField] private AudioClip boostSound;
    [SerializeField] private AudioClip wrongSound;
    
    private bool timeMeasurementStarted = false;
    private float startTime;
    private float raceTime;

    private void FixedUpdate() {
        // Movement
        if (GameBehaviour.IsGameStarted()) {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 targetPosition = new Vector3(rb.position.x, rb.position.y, rb.position.z);
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, transitionSpeed * Time.fixedDeltaTime) + forwardMove);  
        }

        // Stopwatch start
        if (!timeMeasurementStarted) {
            startTime = Time.realtimeSinceStartup;
            timeMeasurementStarted = true;
        }
    }

    // <<< MOVEMENT >>>
    public void IncreaseSpeed() {
        speed *= 1.3f;
        
        SoundSystemSingleton.Instance.PlaySfxSound(boostSound);
        Invoke("PlaySplashSound", 0.5f);
    }
    
    private void PlaySplashSound() {
        SoundSystemSingleton.Instance.PlaySfxSound(splashSound);
    }

    public void DecreaseSpeed() {
        speed /= 1.5f;

        SoundSystemSingleton.Instance.PlaySfxSound(wrongSound);
    }

    public void StopTheVehicleSlowly() {
        InvokeRepeating("Brake", 0f, 0.2f);         
    }

    private void Brake() {
        if (speed > 0) {
            speed *= 0.95f;
            if (speed <= 1f)
                speed = 0;
        }
    }

    // <<< STOPWATCH >>>
    public string SetRaceTime() {
        raceTime = Time.realtimeSinceStartup - startTime - 3f;
        return raceTime.ToString();
        //Debug.Log(gameObject.name + ": " + raceTime.ToString());
    }

    public string GetRaceTime() {
        return raceTime.ToString();
    }

}
