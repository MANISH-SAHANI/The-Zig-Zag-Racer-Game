using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPosition;
    public bool stop;

    private void Start() {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatform());
    }

    private void Update() {
       
    }

    IEnumerator SpawnPlatform() {

        while (!stop) {
            GeneratePosition();
            Instantiate(platform, newPosition, Quaternion.identity);
            lastPosition = newPosition;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void GeneratePosition() {
        newPosition = lastPosition;

        int rand = Random.Range(0, 2);

        if(rand > 0) {
            newPosition.x += 2f;
        }
        else {
            newPosition.z += 2f;
        }
    }

}
