using UnityEngine.SceneManagement;
using UnityEngine;


public class SplitRaceMovement : MonoBehaviour {
    public Rigidbody rb;

    [SerializeField] public float speed = 100f;
    [SerializeField] private float transitionSpeed = 8f;

    private void FixedUpdate() {
        if (GameBehaviour.gameStarted) {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 targetPosition = new Vector3(rb.position.x, rb.position.y, rb.position.z);
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, transitionSpeed * Time.fixedDeltaTime) + forwardMove);
        }
    }

    public void IncreaseSpeed() {
        speed *= 1.3f;
    }

    public void DecreaseSpeed() {
        speed /= 1.5f;
    }

    public void StopTheVehicleSLowly() {
        InvokeRepeating("Brake", 0f, 0.5f);
            
    }

    private void Brake() {
        if (speed > 0) {
            speed *= 0.9f;
            if (speed <= 1f)
                speed = 0;
        }
    }


}
