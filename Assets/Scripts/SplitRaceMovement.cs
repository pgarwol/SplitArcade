using UnityEngine.SceneManagement;
using UnityEngine;


public class SplitRaceMovement : MonoBehaviour {
    public Rigidbody rb;

    [SerializeField] public float speed = 100f;
    [SerializeField] private float transitionSpeed = 8f;
    [SerializeField] private AudioClip splashSound;

    private float startTime;
    private float raceTime;
    private bool timeMeasurementStarted = false;

    public RaceTimer raceTimer;
    void Start() {
        
    }

    private void FixedUpdate() {
        if (GameBehaviour.gameStarted) {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 targetPosition = new Vector3(rb.position.x, rb.position.y, rb.position.z);
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, transitionSpeed * Time.fixedDeltaTime) + forwardMove);  
        }

        if (!timeMeasurementStarted) {
            startTime = Time.time;
            timeMeasurementStarted = true;
        }
    }

    public void IncreaseSpeed() {
        speed *= 1.3f;
        SoundSystemSingleton.Instance.PlaySfxSound(splashSound);
    }

    public void DecreaseSpeed() {
        speed /= 1.5f;
    }

    public void StopTheVehicleSLowly() {
        InvokeRepeating("Brake", 0f, 0.2f);
            
    }

    private void Brake() {
        if (speed > 0) {
            speed *= 0.95f;
            if (speed <= 1f)
                speed = 0;
        }
    }

    public void SetRaceTime() {
        raceTime =  Time.time - startTime;
        Debug.Log(gameObject.name + ": " + raceTime.ToString());
    }

}
