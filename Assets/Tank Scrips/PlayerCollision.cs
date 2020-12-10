using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool checkCollision(GameObject obj1, GameObject obj2)
    {
        GameObject tank = GameObject.Find("T95-1");
        float angle = tank.transform.rotation.y;

        //Obj1 tank 
        float minX1 = obj1.transform.position.x - (10f * Mathf.Cos(angle));
        float maxX1 = obj1.transform.position.x + (10f* Mathf.Cos(angle));
        float minY1 = obj1.transform.position.y - 3f;
        float maxY1 = obj1.transform.position.y + 3f;
        float minZ1 = obj1.transform.position.z - (25f * Mathf.Sin(angle));
        float maxZ1 = obj1.transform.position.z + (25f * Mathf.Sin(angle));

        float minX2 = obj2.transform.position.x - obj2.transform.localScale.x / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.x / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.y / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.y / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        return (minX1 <= maxX2 && maxX1 >= minX2) && 
               (minY1 <= maxY2 && maxY1 >= minY2) && 
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }


    // Update is called once per frame
    void Update()
    {
        GameObject tank = GameObject.Find("T95-1");
        pos = tank.transform.position;
        //GameObject NW = GameObject.Find("NorthWall");
        //if (checkCollision(tank, NW))
        //{
        //    Debug.Log("TANK COLLIDING!");
        //}
        //Debug.Log(tank.transform.rotation.y*180f/Mathf.PI);

        //Temp solution
        if (tank.transform.position.z >=7f)
        {
            pos.z = 7f;

            tank.transform.position = pos;
        }
        if (tank.transform.position.z <= -38f)
        {
            pos.z = -38f;

            tank.transform.position = pos;
        }
        if (tank.transform.position.x <= 118f)
        {
            pos.x = 118f;

            tank.transform.position = pos;
        }
        if (tank.transform.position.x >= 177f)
        {
            pos.x = 177f;

            tank.transform.position = pos;
        }
    }
}
