using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject diamond;

    private void Start() {
        int randDiamonds = Random.Range(0, 10);

        Vector3 diamondPos = transform.position;

        diamondPos.y += 1f;

        if (randDiamonds < 1) {
            GameObject diamondPrefab = Instantiate(diamond, diamondPos, diamond.transform.rotation);
            diamondPrefab.transform.SetParent(gameObject.transform);
        }
    }



    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            Invoke("Fall", 0.2f);
        }
    }

    private void Fall() {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject,1f);
    }
}
