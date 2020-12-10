using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum Collision_Type
//{
//    NO_COLLISION,
//    NORTH_COLLISION,
//    SOUTH_COLLISION,
//    EAST_COLLISION,
//    WEST_COLLISION,
//}

public class PlayerCollision : MonoBehaviour
{
    Vector3 pos;
    bool debug = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool checkCollision(GameObject obj1, GameObject obj2)
    {
        GameObject tank = GameObject.Find("T95-1");
        //float angle = tank.transform.rotation.y;
        GameObject camera = GameObject.Find("Main Camera");
  
        float angle = camera.GetComponent<MouseLook>().totalXRotation;

        //angle = angle * 180f / Mathf.PI;
        float minX1;
        float maxX1;
        float minY1;
        float maxY1;
        float minZ1;
        float maxZ1;

       // Obj1 tank
        minX1 = obj1.transform.position.x - (5f * Mathf.Cos(angle * Mathf.PI / 180f) - 18f * Mathf.Sin(angle * Mathf.PI / 180f));
        maxX1 = obj1.transform.position.x + (5f * Mathf.Cos(angle * Mathf.PI / 180f) - 7f * Mathf.Sin(angle * Mathf.PI / 180f));
        minY1 = obj1.transform.position.y - 3f;
        maxY1 = obj1.transform.position.y + 3f;
        minZ1 = obj1.transform.position.z - (7f * Mathf.Cos(angle * Mathf.PI / 180f) + 5f * Mathf.Sin(angle * Mathf.PI / 180f));
        maxZ1 = obj1.transform.position.z + (18f * Mathf.Cos(angle * Mathf.PI / 180f) + 5f * Mathf.Sin(angle * Mathf.PI / 180f));



        float minX2 = obj2.transform.position.x - obj2.transform.localScale.x / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.x / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.y / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.y / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        //if (!debug)
        //{
        //    Debug.Log("Min X: " + minX1);
        //    Debug.Log("Max X: " + maxX1);
        //    Debug.Log("Min Y: " + minY1);
        //    Debug.Log("Max Y: " + maxY1);
        //    Debug.Log("Min Z: " + minZ1);
        //    Debug.Log("Max Z: " + maxZ1);
        //    Debug.Log("Angle: " + angle);
        //    debug = true;
        //}

        return (minX1 <= maxX2 && maxX1 >= minX2) && 
               (minY1 <= maxY2 && maxY1 >= minY2) && 
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }

    bool checkCollisionSouth(GameObject obj1, GameObject obj2)
    {
        GameObject tank = GameObject.Find("T95-1");
        //float angle = tank.transform.rotation.y;
        GameObject camera = GameObject.Find("Main Camera");

        float angle = camera.GetComponent<MouseLook>().totalXRotation;

        //angle = angle * 180f / Mathf.PI;
        float minX1;
        float maxX1;
        float minY1;
        float maxY1;
        float minZ1;
        float maxZ1;

        //Obj1 tank 
        maxX1 = obj1.transform.position.x - (5f * Mathf.Cos(angle * Mathf.PI / 180f) - 18f * Mathf.Sin(angle * Mathf.PI / 180f));
        minX1 = obj1.transform.position.x + (5f * Mathf.Cos(angle * Mathf.PI / 180f) - 7f * Mathf.Sin(angle * Mathf.PI / 180f));
        minY1 = obj1.transform.position.y - 3f;
        maxY1 = obj1.transform.position.y + 3f;
        maxZ1 = obj1.transform.position.z - (18f * Mathf.Cos(angle * Mathf.PI / 180f) + 5f * Mathf.Sin(angle * Mathf.PI / 180f));
        minZ1 = obj1.transform.position.z + (7f * Mathf.Cos(angle * Mathf.PI / 180f) + 5f * Mathf.Sin(angle * Mathf.PI / 180f));


        float minX2 = obj2.transform.position.x - obj2.transform.localScale.x / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.x / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.y / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.y / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;


        //Debug.Log(minZ1);
        //if (!debug)
        //{
        //    Debug.Log("Min X: " + minX1);
        //    Debug.Log("Max X: " + maxX1);
        //    Debug.Log("Min Y: " + minY1);
        //    Debug.Log("Max Y: " + maxY1);
        //    Debug.Log("Min Z: " + minZ1);
        //    Debug.Log("Max Z: " + maxZ1);
        //    Debug.Log("Angle: " + angle);
        //    debug = true;
        //}

        return (minX1 <= maxX2 && maxX1 >= minX2) &&
               (minY1 <= maxY2 && maxY1 >= minY2) &&
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }

    bool checkCollisionWest(GameObject obj1, GameObject obj2)
    {
        GameObject tank = GameObject.Find("T95-1");
        //float angle = tank.transform.rotation.y;
        GameObject camera = GameObject.Find("Main Camera");

        float angle = camera.GetComponent<MouseLook>().totalXRotation;

        //angle = angle * 180f / Mathf.PI;
        float minX1;
        float maxX1;
        float minY1;
        float maxY1;
        float minZ1;
        float maxZ1;
  

        //Obj1 tank 
        minX1 = obj1.transform.position.x + (7f * Mathf.Sin(angle * Mathf.PI / 180f) + 5f * Mathf.Cos(angle * Mathf.PI / 180f));
        maxX1 = obj1.transform.position.x - (18f * Mathf.Sin(angle * Mathf.PI / 180f) + 5f * Mathf.Cos(angle * Mathf.PI / 180f));
        minY1 = obj1.transform.position.y - 3f;
        maxY1 = obj1.transform.position.y + 3f;
        minZ1 = obj1.transform.position.z + (18f * Mathf.Cos(angle * Mathf.PI / 180f) + 5f * Mathf.Sin(angle * Mathf.PI / 180f));
        maxZ1 = obj1.transform.position.z - (7f * Mathf.Cos(angle * Mathf.PI / 180f) + 5f * Mathf.Sin(angle * Mathf.PI / 180f));
        //if (!debug)
        //{ 
        //    Debug.Log("Min Z: " + minZ1);
        //    Debug.Log("Max Z: " + maxZ1);
        //    debug = true;
        //}

        float minX2 = obj2.transform.position.x - obj2.transform.localScale.x / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.x / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.y / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.y / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        if (!debug)
        {
            Debug.Log("Min X: " + minX1);
            Debug.Log("Max X: " + maxX1);
            Debug.Log("Min Y: " + minY1);
            Debug.Log("Max Y: " + maxY1);
            Debug.Log("Min Z: " + minZ1);
            Debug.Log("Max Z: " + maxZ1);
            Debug.Log("Angle: " + angle);
            debug = true;
        }

        return (minX1 <= maxX2 && maxX1 >= minX2) &&
               (minY1 <= maxY2 && maxY1 >= minY2) &&
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            debug = false;
        }
        GameObject tank = GameObject.Find("T95-1");
        GameObject NW = GameObject.Find("NorthWall");
        GameObject SW = GameObject.Find("SouthWall");
        GameObject EW = GameObject.Find("EastWall");
        GameObject WW = GameObject.Find("WestWall");
        pos = tank.transform.position;


        if (checkCollision(tank, NW))
        {
            Debug.Log(" NW COLLIDING!");
            pos.x = NW.transform.position.x + 23f;
            tank.transform.position = pos;
        }
        if (checkCollisionSouth(tank, SW))
        {
            Debug.Log("SW COLLIDING!");
            pos.x = SW.transform.position.x - 23f;
            tank.transform.position = pos;
        }
        if (checkCollision(tank, EW))
        {
            Debug.Log("EW COLLIDING!");
            pos.z = EW.transform.position.z - 22f;
            tank.transform.position = pos;
        }
        if (checkCollisionWest(tank, WW))
        {
            Debug.Log("WW COLLIDING!");
            pos.z = WW.transform.position.z + 22f;
            tank.transform.position = pos;
        }

    }
}
