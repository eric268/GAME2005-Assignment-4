using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletPool : MonoBehaviour
{
   public  int numBullets = 100;
   int counter;

    public GameObject[] bulletPool;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBullets; i++)
        {

            bulletPool[i] = Instantiate(prefab) as GameObject;

            bulletPool[i].name = "Bullet# " + i;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
