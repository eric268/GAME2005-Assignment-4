using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    public void adjustMass(float newWeight)
    {

        //float weight = 5f; 
        for (int i = 0; i < 6; i++)
        {
            GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[i].GetComponent<BoxVariables>().weight = newWeight;
        }

        //return newWeight;
    }

    public void adjustFriction(float newFriction)
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[i].GetComponent<BoxVariables>().coefficientFriction = newFriction;
        }
    }

}
