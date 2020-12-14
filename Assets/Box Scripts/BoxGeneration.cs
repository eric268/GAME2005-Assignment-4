using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGeneration : MonoBehaviour
{
    public GameObject[] boxArray;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {

            boxArray[i] = Instantiate(prefab) as GameObject;

            boxArray[i].name = "Box" + i;
        }
        boxArray[0].transform.position = new Vector3(118f, 14.8f, 10f);
        boxArray[1].transform.position = new Vector3(122.61f, 14.8f, 16.12f);
        boxArray[2].transform.position = new Vector3(128.54f, 14.8f, 22f);
        boxArray[3].transform.position = new Vector3(120.85f, 28.9f, 12.85f);
        boxArray[4].transform.position = new Vector3(125.16f, 28.82f, 20.23f);
        boxArray[5].transform.position = new Vector3(122.47f, 40.6f, 17.48f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
