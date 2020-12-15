using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxVariables : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 momentum;
    public Vector3 pos;
    public float weight;
    public float gravity;
    public bool collidingTank;
    public bool onGround;
    public bool collidingOtherBox;
    public float GravityForce = 0f;
    public float FrictionForce =0f;
    public float coefficientFriction;
    public float netForce =0f;
    public float decceleration = 0f;
    public bool collisionJustOccured = false;


    // Start is called before the first frame update
    public void Start()
    {
        velocity = new Vector3(0f, 0f, 0f);
        acceleration = new Vector3(0f, 0f, 0f);
        pos = new Vector3(0f, 0f, 0f);
        coefficientFriction = 0.1f;
        weight = 5f;
        gravity = -9.81f;
        collidingTank = false;
        onGround = false;
        collidingOtherBox = false;

    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerVariables.isPlaying)
        {

            if (velocity.magnitude >= 0.1f)
            {
                acceleration = velocity.normalized * coefficientFriction * gravity;
            }
            else
            {
                velocity = Vector3.zero;
            }
            if (!onGround || !collidingOtherBox)
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

            Debug.Log("Weight: " + weight);
        }
    }

    public void adjustMass(float newWeight)
    {
        //float weight = 5f; 
        weight = newWeight;
        Debug.Log("Weight");
        //return newWeight;
    }

    public void adjustFriction(float newFriction)
    {
        float coefficientFriction = 0.1f;
        coefficientFriction = newFriction;
        //return newFriction;
    }
    
}
