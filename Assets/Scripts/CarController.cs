using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private GameObject diamondCollectEffect;
    public float carSpeed;

    private bool moveLeft = true;
    private bool firstInput = true;
    

    void Update(){
        if(GameManager.instance.gameStarted == true) {
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2) {
            GameManager.instance.GameOver();
        }
    }

    public void Move() {
        transform.position += transform.forward * carSpeed * Time.deltaTime;
    }

    public void CheckInput() {

        if(firstInput == true) {
            firstInput = false;
            return;
        }
        if (Input.GetMouseButtonDown(0) || (Input.GetKeyDown(KeyCode.Space))){
            ChangeDirection();
        }
    }

    private void ChangeDirection() {
        if(moveLeft) {
            moveLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);

        }
        else
        {
            moveLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Diamond") {
            Instantiate(diamondCollectEffect,other.transform.position,diamondCollectEffect.transform.rotation);
            GameManager.instance.PlayDiamondCollectSound();
            GameManager.instance.DiamondIncrementScore();
            other.gameObject.SetActive(false);
        }
    }
}
