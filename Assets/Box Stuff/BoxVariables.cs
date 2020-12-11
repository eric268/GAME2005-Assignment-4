using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxVariables : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public float weight = 10f;
    public float gravity = -0.01f;
    public bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 0f, 0f);
        acceleration = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        acceleration.y = gravity * Time.deltaTime;
        Debug.Log(acceleration.y);
        velocity += acceleration;

        GameObject ground = GameObject.Find("Ground");
    }
}
