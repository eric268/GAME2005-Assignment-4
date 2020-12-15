using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    public void adjustMass(float newWeight)
    {
        float Sliders = GameObject.Find("BoxPrefab").GetComponent<BoxVariables>().weight;
        //float weight = 5f; 
        Sliders = newWeight;
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
