using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public SpawnManager spawnManager;
    public GameObject titleScreen;
    public Button restartButton;
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI clearText;
    public TextMeshProUGUI TimerText;

    void Start()
    {

    }

    public void StartGame()
    {
        TimerOn = true;
        spawnManager.SpawnPlayer();
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
    }


    void Update()
    {
        //타이머 시작
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                restartButton.gameObject.SetActive(true);
                isGameActive = false;
                gameOverText.gameObject.SetActive(true);

            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        TimerOn = false;
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
    }
    public void Clear()
    {
        TimerOn = false;
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        clearText.gameObject.SetActive(true);
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
