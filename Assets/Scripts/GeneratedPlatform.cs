using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    private void Update()
    {
        if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }

    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0.1f;

        var pm = new PhysicsMaterial2D();
        pm.friction = 100000f;
        pm.bounciness = 0;
        rb.sharedMaterial = pm;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        { 
            rb.mass *= 1000000;
            rb.velocity = Vector3.zero;
        }
    }
}
