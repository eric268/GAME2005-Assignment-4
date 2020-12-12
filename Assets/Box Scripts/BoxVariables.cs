using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxVariables : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 momentum;
    public Vector3 pos;
    public float weight = 1f;
    public float gravity = -9.81f;
    public bool collidingTank = false;
    public bool onGround = false;
    public bool collidingOtherBox = false;
    public float GravityForce = 0f;
    public float FrictionForce =0f;
    public float coefficientFriction = 0.1f;
    public float netForce =0f;
    public float decceleration = 0f;
    public bool collisionJustOccured = false;


    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 0f, 0f);
        acceleration = new Vector3(0f, 0f, 0f);
        pos = new Vector3(0f, 0f, 0f);


    }

    // Update is called once per frame
    void Update()
    {
        if (velocity.magnitude >= 0.5f)
        {
            acceleration = velocity.normalized * coefficientFriction * gravity;
        }
        else
        {
            velocity = Vector3.zero;
        }
        if (!onGround)
        {
        acceleration.y = gravity;
        }
       // else
          // acceleration.y = 0f;


        //Debug.Log(velocity.magnitude);


        velocity += acceleration;


        pos = transform.position;
            pos += velocity * Time.deltaTime;
           transform.position = pos;
            //Debug.Log(indiviBox.GetComponent<BoxVariables>().velocity);

        // GameObject test = GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[0];


        momentum = velocity * weight;

    }
}
