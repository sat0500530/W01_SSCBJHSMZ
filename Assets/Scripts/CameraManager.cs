using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 targetPosition;
    public float smoothSpeed = 0.125f;
    public float yBoundaryMin = 0;
    public bool useMax = false;
    public float yBoundaryMax = 0;

    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        Vector3 desiredPosition = transform.position;

        if (targetPosition.y < yBoundaryMin)
        {
            desiredPosition.y = yBoundaryMin;
        }
        else if (useMax && targetPosition.y > yBoundaryMax)
        {
            desiredPosition.y = yBoundaryMax;
        }
        else
        {
            desiredPosition.y = targetPosition.y;
        }

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

    }

    public void SetTarget(Vector3 newPosition)
    {
        // 받은 위치 값을 카메라 타겟값으로 변경
        targetPosition = newPosition;
    }
}

