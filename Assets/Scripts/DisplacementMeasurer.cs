using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementMeasurer : MonoBehaviour
{
    float startX;
    float startY;
    float maxY;

    bool isMeasuring;

    void OnEnable()
    {
        isMeasuring = false;
    }

    void Update()
    {
        if (!isMeasuring && Input.GetKeyDown(KeyCode.Space))
        {
            StartMeasuring();
        }

        if (isMeasuring)
        {
            if (transform.position.y >= maxY)
            {
                maxY = transform.position.y;
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") && isMeasuring)
        {
            EndMeasuring();
        }
    }

    void StartMeasuring()
    {
        Debug.Log("Start Measuring!");
        isMeasuring = true;
        startX = transform.position.x;
        startY = transform.position.y;
        maxY = startY;
    }
    
    void EndMeasuring()
    {
        isMeasuring = false;
        Debug.Log("End Measuring!");
        float displacementX = transform.position.x - startX;
        float apexY = maxY - startY;
        Debug.Log($"Displacement_X : {displacementX}, Apex_Y = {apexY}");
    }
}
