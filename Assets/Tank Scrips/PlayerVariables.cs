using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerVariables : MonoBehaviour
{
    public  float weight = 100f;
    public  Vector3 position;
    public  Vector3 previousPosition;
    public  Vector3 velocity;
    public Vector3 momentum;

    public float barrelEndWeight = 10f;
    public Vector3 barrelEndPosition;
    public Vector3 barrelPreviousEndPosition;
    public Vector3 barrelEndVelocity;
    public Vector3 barrelEndMomentum;
    static public bool isPlaying;



    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(0f, 0f, 0f);
        previousPosition = new Vector3(0f, 0f, 0f);
        velocity = new Vector3(0f, 0f, 0f);
        momentum = new Vector3(0f, 0f, 0f);

        barrelEndPosition = new Vector3(0f, 0f, 0f);
        barrelPreviousEndPosition = new Vector3(0f, 0f, 0f);
        barrelEndVelocity = new Vector3(0f, 0f, 0f);
        barrelEndMomentum = new Vector3(0f, 0f, 0f);

        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject bulletEmitter = GameObject.Find("BulletEmitter");
        GameObject tank = GameObject.Find("T95-1");

        //Calculates velocity and momentum of the tank
        position = tank.transform.position;
        velocity = (position - previousPosition) / Time.deltaTime;
        momentum = velocity * weight;
        previousPosition = position;

        //Calculates velocity and momentum of the nozzel on the tank barrel
        barrelEndPosition = bulletEmitter.transform.position;
        barrelEndVelocity = (barrelEndPosition - barrelPreviousEndPosition) / Time.deltaTime;
        barrelEndMomentum = barrelEndVelocity * barrelEndWeight;
        barrelPreviousEndPosition = barrelEndPosition;

        //Debug.Log("Barrel Velocity: " + barrelEndVelocity);
    }
}
