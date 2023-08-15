using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetStart);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        
    }
    
    void SetStart()
    {
        //gameManager.StartGame();
    }
}
