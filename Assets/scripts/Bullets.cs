using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private float speed = 80f;
    public Vector2 direction;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // transform.Translate(direction * speed * Time.deltaTime);
        rb.MovePosition(rb.position + (direction * speed * Time.deltaTime));
    }
}
