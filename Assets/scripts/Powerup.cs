using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public static bool PowerupsCollected;
    public static bool[] arr = new bool[3] { p0collected, p1collected, p2collected };
    
    private static bool p0collected; // bunlar toplanan collectableın tag tipine göre true olacak
    private static bool p1collected;
    private static bool p2collected;
    private GameObject player;

    private Player _player;
    
    private Vector2 Here_Shootdirection;
    private float Here_cooldown;
    private float Here_cooldownTimer;
    private GameObject bulletPrefab;
    

    private void Awake()
    {
        player = GameObject.Find("player");
        _player = player.GetComponent<Player>();
        bulletPrefab = (GameObject)Resources.Load("prefabs/bullet", typeof(GameObject));

        Here_Shootdirection = _player.ShootDirection;
        Here_cooldown = _player.Cooldown;
        Here_cooldownTimer = _player.cooldownTimer;
    }


    private void OnTriggerEnter(Collider other)
    {
        PowerupsCollectedFunc();
        
        
        
        MakeCollectedsFalse();
    }
    
    private void Shoot()
    {
        
        if (Here_Shootdirection != Vector2.zero && Here_cooldownTimer >= Here_cooldown)
        {
            Here_cooldownTimer = 0f;
            GameObject bullet = Instantiate(bulletPrefab, player.transform.position, player.transform.rotation);
            bullet.GetComponent<Bullets>().direction = Here_Shootdirection;
        }
        
        else if (Here_cooldownTimer < Here_cooldown)
        {
            Here_cooldownTimer += Time.deltaTime;
        }
    }

    private void PowerupsCollectedFunc()
    {
        PowerupsCollected = true;
        if (gameObject.tag == "powerup0") p0collected = true;
        if (gameObject.tag == "powerup1") p1collected = true;
        if (gameObject.tag == "powerup2") p2collected = true;
    }
    private void MakeCollectedsFalse()
    {
        PowerupsCollected = false;
        
        p0collected = false;
        p1collected = false;
        p2collected = false;
    }
}
