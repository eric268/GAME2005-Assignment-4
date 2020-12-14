using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 inactiveLocation;
    public bool active = false;
    public float weight;
    public  Vector3 momentum;
    public float speed;
    public float wallSlowPercentage;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        weight = 40f;
        speed = 1.3f;
        inactiveLocation = new Vector3(-10000f, -10000f, -10000f);
        this.transform.position = inactiveLocation;
        wallSlowPercentage = 0.4f;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(velocity.magnitude);
        if (!active)
        {
            transform.position = inactiveLocation;
            velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        momentum = weight * velocity;
        this.transform.position += velocity;
    }
}
