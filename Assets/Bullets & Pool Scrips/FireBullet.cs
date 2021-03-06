﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        GameObject indivBullet = GameObject.Find("Ground");
        Bullet_Emitter = GameObject.Find("BulletEmitter");

        if (Input.GetMouseButtonDown(0) && PlayerVariables.isPlaying)
        {
            Bullet = indivBullet.GetComponent<BulletPool>().bulletPool[counter];
            Bullet.GetComponent<Bullet>().active = true;

            Bullet.transform.position = Bullet_Emitter.transform.position;
            Bullet.transform.rotation = Bullet_Emitter.transform.rotation;

            Bullet.GetComponent<Bullet>().velocity = Bullet_Emitter.transform.forward * Bullet.GetComponent<Bullet>().speed;


            counter++;
            int bulletPoolSize = indivBullet.GetComponent<BulletPool>().numBullets;
            if (counter >= bulletPoolSize)
            {
                counter = 0;
            }
        }
      
    }
}
