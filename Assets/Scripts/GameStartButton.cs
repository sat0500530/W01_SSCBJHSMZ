using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GameStart);
    }

    void GameStart()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
