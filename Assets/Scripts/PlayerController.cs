using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public bool gameOver;
    public bool clear;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public CameraManager cameraManager;
    public Color groundColor;
    private GameManager gameManager;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isOnGround = true;
    private SpawnManager spawnManager;
    

    private void Start()
    {
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        for (int i = 0; i < transform.childCount; i++)
        {
            var block = transform.GetChild(i);
            block.tag = "Ground";
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.0000001f)
        {
            isOnGround = true;
        }
    }

    private void Update()
    {
        
        cameraManager.SetTarget(transform.position);

        float moveX = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveX * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        if (Input.GetKey(KeyCode.Space) && isOnGround && !gameOver && !clear)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && !gameOver && !clear)
        {
            ChangeToPlatform();
            gameManager.TrySpawnPlayer();
        }

        if (Input.GetKeyDown(KeyCode.Z) && !gameOver && !clear)
        {
            transform.Rotate(Vector3.forward * 90);
        }


        if (Input.GetKeyDown(KeyCode.C) && !gameOver && !clear)
        {
            transform.Rotate(Vector3.forward * -90);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

        }

        else if (collision.gameObject.CompareTag("Lava"))
        {
            Destroy(gameObject);
            gameManager.TrySpawnPlayer();
        }

        else if (collision.gameObject.CompareTag("Goal"))
        {
            // ���� ����
            clear = true;
            gameManager.StageClear();
        }
    }

    private void ChangeToPlatform()
    {
        gameObject.tag = "Ground";
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = groundColor;
            }
        }

        rb.mass *= 1000000;
        Destroy(this);
    }
}
