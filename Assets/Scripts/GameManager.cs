using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isTimeLimit; // true : time limit, false : block limit
    public float timeLimit;
    public int blockLimit;

    public bool isGameActive;
    public SpawnManager spawnManager;

    public GameObject stageStartUI;
    public GameObject onStageUI;
    public GameObject stageClearUI;
    public GameObject stageOverUI;

    public TextMeshProUGUI stageNameText;
    public TextMeshProUGUI stageGoalText;
    public TextMeshProUGUI limitText;
    public TextMeshProUGUI stageClearText;
    public TextMeshProUGUI stageOverText;

    string stageName;

    void Start()
    {
        stageName = SceneManager.GetActiveScene().name;

        stageNameText.text = stageName;
        stageGoalText.text = isTimeLimit ? $"Time Limit : {timeLimit} seconds" : $"Block Limit : {blockLimit}";
    }

    void Update()
    {
        if (!isTimeLimit) return;

        if (isTimeLimit)
        {
            if (timeLimit > 0)
            {
                timeLimit -= Time.deltaTime;
                UpdateLimitText();
            }
            else
            {
                timeLimit = 0;
                StageOver();
            }
        }
    }
    public void StartStage()
    {
        stageStartUI.SetActive(false);
        onStageUI.SetActive(true);
        isGameActive = true;
        TrySpawnPlayer();
    }
    public void StageClear()
    {
        if (!isGameActive) return;

        stageClearText.text = $"{stageName} Clear!";

        isGameActive = false;
        onStageUI.SetActive(false);
        stageClearUI.SetActive(true);

    }
    public void StageOver()
    {
        stageOverText.text = isTimeLimit ? "Time Over..." : "Out of Blocks...";

        isGameActive = false;
        onStageUI.SetActive(false);
        stageOverUI.SetActive(true);
    }

    public void RestartStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextStage()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextIndex = 0;
        }
        SceneManager.LoadScene(nextIndex);
    }

    public bool TrySpawnPlayer()
    {
        if (isTimeLimit)
        {
            spawnManager.SpawnPlayer();
            return true;
        }

        if (blockLimit > 0)
        {
            blockLimit--;
            UpdateLimitText();
            spawnManager.SpawnPlayer();
            return true;
        }
        else
        {
            StageOver();
            return false;
        }
    }
    void UpdateLimitText()
    { 
        if (isTimeLimit)
        {
            float currentTime = timeLimit;

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            limitText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            string plural = (blockLimit > 1 ? "s" : string.Empty);
            limitText.text = $"{blockLimit} block{plural} left";
        }
    }
    

}
