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
            // ���� ��� ���� �� ���� ����
            isOnGround = true;
        }

        else if (collision.gameObject.CompareTag("Lava"))
        {
            // ��Ͽ� ���� �� ���� ����
            Debug.Log("Game Over");
            gameOver = true;
            gameManager.GameOver();
            Destroy(gameObject);

        }

        else if (collision.gameObject.CompareTag("Goal"))
        {
            // ���� ����
            clear = true;
            gameManager.Clear();
        }
    }

    private void ChangeToPlatform()
    {
        // player �ڸ��� platform prefab ��ȯ ��, player ������Ʈ ����, �׸��� player ��ȯ
        Instantiate(changePlatform, transform.position, changePlatform.transform.rotation);
        Destroy(gameObject);
        spawnManager.SpawnPlayer();
    }
}
