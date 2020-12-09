﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 inactiveLocation;
    public bool active = false;

    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        inactiveLocation = new Vector3(-10000f, -10000f, -10000f);
        this.transform.position = inactiveLocation;

    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            transform.position = inactiveLocation;
            velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }

        this.transform.position += velocity;
    }
}