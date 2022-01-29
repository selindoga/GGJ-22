using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 vector2_MoveDirection;
    public GameObject bulletPrefab;
    //public Rigidbody2D rbBullet;
    //private float bulletForce = 20f;
    private int movementSpeed = 5; 
    private Vector2 vector2_Shootdirection;
    private float cooldown = 0.5f;
    public float cooldownTimer;


    public Vector2 ShootDirection
    {
        get => vector2_Shootdirection;
        set => vector2_Shootdirection = value;
    }
    
    public float Cooldown
    {
        get => cooldown;
        set => cooldown = value;
    }
    
    private void Update()
    {
        vector2_MoveDirection.x = Input.GetAxis("Horizontal");
        vector2_MoveDirection.y = Input.GetAxis("Vertical");
        vector2_Shootdirection.x = Input.GetAxis("HorizontalShoot");
        vector2_Shootdirection.y = Input.GetAxis("VerticalShoot");
        vector2_Shootdirection = vector2_Shootdirection.normalized;
        Move();
        Shoot();
    }

    public void Move()
    {
        rb.velocity = vector2_MoveDirection * movementSpeed;
    }

    public void Shoot()
    {
        if (vector2_Shootdirection != Vector2.zero && cooldownTimer >= cooldown && !Powerup.PowerupsCollected)
        {
            cooldownTimer = 0f;
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, transform.rotation);
            bullet.GetComponent<Bullets>().direction = vector2_Shootdirection;
        }
        
        else if (cooldownTimer < cooldown)
        {
            cooldownTimer += Time.deltaTime;
        }
    }
}
