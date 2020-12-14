using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    static Vector3 calculateNormalVec(Vector3 A, Vector3 B, Vector3 C)
    {
        Vector3 AB = B - A;
        Vector3 AC = C - A;

        //Cross product and normalize to get normal 
        Vector3 mNormal = Vector3.Cross(AB,AC);

        return mNormal.normalized;
    }

    bool planeAABBCollision(GameObject plane, GameObject box)
    {


        return false;
    }
    bool checkCollisionSphereAABB(GameObject obj1, GameObject obj2)
    {
        //Obj1 Cube
        //Obj2 Sphere

        float minX = obj1.transform.position.x - obj1.transform.localScale.x / 2f;
        float maxX = obj1.transform.position.x + obj1.transform.localScale.x / 2f;
        float minY = obj1.transform.position.y - obj1.transform.localScale.y / 2f;
        float maxY = obj1.transform.position.y + obj1.transform.localScale.y / 2f;
        float minZ = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ = obj1.transform.position.z + obj1.transform.localScale.z / 2f;

        //if (!debug)
        //{
        //    Debug.Log("Min X: " + minX);
        //    Debug.Log("Max X: " + maxX);
        //    Debug.Log("Min Y: " + minY);
        //    Debug.Log("Max Y: " + maxY);
        //    Debug.Log("Min Z: " + minZ);
        //    Debug.Log("Max Z: " + maxZ);
        //    debug = true;
        //}

        float sphereX = obj2.transform.position.x;
        float sphereY = obj2.transform.position.y;
        float sphereZ = obj2.transform.position.z;

        float radius = obj2.transform.localScale.z;


        float x = Mathf.Max(minX, Mathf.Min(sphereX, maxX));
        float y = Mathf.Max(minY, Mathf.Min(sphereY, maxY));
        float z = Mathf.Max(minZ, Mathf.Min(sphereZ, maxZ));

        float distance = Mathf.Sqrt((x - sphereX) * (x + sphereX) + (y - sphereY) * (y + sphereY) +
        (z - sphereZ) * (z + sphereZ));

        if (distance < radius)
            return true;

        return false;
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}
