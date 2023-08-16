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

    bool isGameActive;
    SpawnManager spawnManager;

    public GameObject stageStartUI;
    public GameObject onStageUI;
    public GameObject stageClearUI;
    public GameObject stageOverUI;

    public TextMeshProUGUI stageNameText;
    public TextMeshProUGUI stageGoalText;
    public TextMeshProUGUI limitText;
    public Image nextBlockImage;
    public TextMeshProUGUI stageClearText;
    public TextMeshProUGUI stageOverText;

    string stageName;

    void Start()
    {
        stageName = SceneManager.GetActiveScene().name;

        if (spawnManager == null)
        {
            spawnManager = FindObjectOfType<SpawnManager>();
        }

        stageNameText.text = stageName;
        stageGoalText.text = isTimeLimit ? $"Time Limit : {timeLimit} seconds" : $"Block Limit : {blockLimit}";

        isGameActive = false;
    }

    void Update()
    {
        if (!isTimeLimit) return;

        if (isGameActive && isTimeLimit)
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
        // TODO : 스테이지 씬들 사이에서만 이동하기(타이틀, 목록 씬 등 제외)
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextIndex = 0;
        }
        SceneManager.LoadScene(nextIndex);
    }

    public void GoToStageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public bool TrySpawnPlayer()
    {
        Sprite nextSprite;
        if (isTimeLimit)
        {
            nextSprite = spawnManager.SpawnPlayer(false);
            UpdateNextImage(nextSprite);
            return true;
        }

        if (blockLimit > 0)
        {
            blockLimit--;
            UpdateLimitText();

            nextSprite = spawnManager.SpawnPlayer(blockLimit == 0);
            UpdateNextImage(nextSprite);
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
    
    public void UpdateNextImage(Sprite sprite)
    {
        nextBlockImage.sprite = sprite;
    }
}
