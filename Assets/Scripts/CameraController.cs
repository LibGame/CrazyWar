using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private float leftLimit;
    private float rightLimit;
    private float upperLimit;
    private float bottomLimit;


    public void SetTarget(Transform player)
    {
        target = player;
    }

    public void LimmitSetter(float left , float right , float up , float bottom)
    {
        leftLimit = left + 8.4f;
        rightLimit = right - 9.45f;
        upperLimit = up - 5.57f;
        bottomLimit = bottom + 4.4f;
    }

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -10));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), 
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z);
    }
}
