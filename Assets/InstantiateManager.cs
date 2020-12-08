using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    int numBullets = 30;
    int counter;

    public GameObject[] bulletPool;

    public GameObject prefab;
    Vector3 bulletPos;

    // Start is called before the first frame update
    void Start()
    {
        bulletPos = new Vector3(0.0f, 0.0f, -10.0f);


        for (int i = 0; i < numBullets; i++)
        {
            //bulletPos.z += i;

            bulletPool[i] = Instantiate(prefab) as GameObject;

            bulletPool[i].transform.position = bulletPos;

            bulletPool[i].name = "Bullet# " + i;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
