using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public bool gameOver;
    public bool clear;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public GameObject changePlatform;
    public CameraManager cameraManager;
    private GameManager gameManager;
    private Rigidbody2D rb;
    private bool isOnGround = true;
    private SpawnManager spawnManager;
    

    private void Start()
    {
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        cameraManager.SetTarget(transform.position);

        float moveX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveX * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver && !clear)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && !gameOver && !clear)
        {
            ChangeToPlatform();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // 땅에 닿아 있을 시 점프 가능
            isOnGround = true;
        }

        else if (collision.gameObject.CompareTag("Lava"))
        {
            // 용암에 닿을 시 게임 오버
            Debug.Log("Game Over");
            gameOver = true;
            gameManager.GameOver();
            Destroy(gameObject);

        }

        else if (collision.gameObject.CompareTag("Goal"))
        {
            // 골인 도착
            clear = true;
            gameManager.Clear();
        }
    }

    private void ChangeToPlatform()
    {
        // player 자리에 platform prefab 소환 후, player 오브젝트 제거, 그리고 player 소환
        Instantiate(changePlatform, transform.position, changePlatform.transform.rotation);
        Destroy(gameObject);
        spawnManager.SpawnPlayer();
    }
}
