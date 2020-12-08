using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour
{
    //Variables

    public float gravity = -1.8f;
    public Vector3 velocity;
    public Vector3 acceleration;

    public float speed = 0.1f;

    void instatiateValues()
    {
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        acceleration = new Vector3(0.0f, 0.0f, 0.0f);
    }


    // Start is called before the first frame update

    void Start()
    {
        float frameRate = Time.deltaTime;
        instatiateValues();
        acceleration.y = gravity * frameRate;
       // Debug.LogWarning("Acceleration: " + acceleration);
       // Debug.LogWarning("Frame Rate: " + frameRate);

    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration;
       // Debug.LogWarning("Velocity: " + velocity);
        this.transform.position += velocity;
    }
}
