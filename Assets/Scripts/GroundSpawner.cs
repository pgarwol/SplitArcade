using UnityEngine;


public class GroundSpawner : MonoBehaviour {

    public GameObject groundTile;
    Vector3 nextSpawnPoint = new Vector3(0, 0, 0.98f);

    void Start() {
       for (int i = 1; i <= 3; i++) {
            SpawnTile();
            if (i == 1)//2
                groundTile = GameObject.Find("FINALRaceTrackSegment");

        }
    }
    //FINALRaceTrackSegment
    public void SpawnTile() {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }
}
