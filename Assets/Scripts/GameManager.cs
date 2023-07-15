using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour { 

    public static GameManager instance;

    public GameObject platformSpawner;
    public GameObject gamePlayUI;
    public GameObject mainMenuUI;
    public Text highScoreText;

    public Text scoreText;

    public bool gameStarted;

    private int score = 0;
    private int highScore;

    AudioSource audioSource;
    public AudioClip[] gameMusics;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        highScore = PlayerPrefs.GetInt("HighScore");

        highScoreText.text = "BEST SCORE : " + highScore;
    }

    private void Update() {
        GameStart();
    }


    public void GameStart() {
        if (!gameStarted) {
            if (Input.GetMouseButtonDown(0)|| (Input.GetKeyDown(KeyCode.Space))) {
                gameStarted = true;
                platformSpawner.SetActive(true);
                mainMenuUI.SetActive(false);
                gamePlayUI.SetActive(true);

                //Audio
                //audioSource.clip = gameMusics[1];
                //audioSource.Play();

                StartCoroutine(UpdateScore());
            }
        }
    }

    public void DiamondIncrementScore() {
        score += 2;
        scoreText.text = score.ToString();
    }

    public void PlayDiamondCollectSound() {
        audioSource.PlayOneShot(gameMusics[2]);
    }

    public void GameOver() {
        //Game Overs
        platformSpawner.SetActive(false);
        SaveHighScore();
        StopCoroutine(UpdateScore());
        Invoke("ReloadScence", 1f);

    }

    public void ReloadScence() {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore() {
        while (true) {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = score.ToString();

        }
    }

    public void SaveHighScore() {
        if (PlayerPrefs.HasKey("HighScore")) {
            //Player has played alredy
            if (score > PlayerPrefs.GetInt("HighScore")) {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else {
            //Playing first Time
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}


