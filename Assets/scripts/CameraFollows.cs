using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform player;

    private float smoothness = 1.7f;
    private Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 0, -10);
    }
    
    private void LateUpdate()
    {
        Vector3 desiredPosition =  player.position + offset * smoothness;
        //transform.position = desiredPosition;
        transform.position = Vector3.Lerp(gameObject.transform.position, desiredPosition, smoothness * Time.deltaTime);
    }
}
