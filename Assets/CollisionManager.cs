using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

     public static float distance(Vector3 obj1, Vector3 obj2)
    {
        return Mathf.Sqrt((obj2.x - obj1.x) * (obj2.x - obj1.x) + (obj2.y - obj1.y) * (obj2.y - obj1.y) + (obj2.z - obj1.z) * (obj2.z - obj1.z));
    }

    static Vector3 calculateNormalVec(Vector3 A, Vector3 B, Vector3 C)
    {
        Vector3 AB = B - A;
        Vector3 AC = C - A;

        //Cross product and normalize to get normal 
        Vector3 mNormal = Vector3.Cross(AB,AC);

        return mNormal.normalized;
    }

    static public bool planeSphereCollision(GameObject plane, GameObject sphere)
    {
        Vector3 A = new Vector3(plane.transform.position.x, plane.transform.position.y - plane.transform.localScale.y, plane.transform.position.z - plane.transform.localScale.z);
        Vector3 B = new Vector3(plane.transform.position.x, plane.transform.position.y + plane.transform.localScale.y, plane.transform.position.z - plane.transform.localScale.z);
        Vector3 C = new Vector3(plane.transform.position.x, plane.transform.position.y - plane.transform.localScale.y, plane.transform.position.z + plane.transform.localScale.z);
        Vector3 planeN = calculateNormalVec(A, B, C);

        //float distance = Vector3.Dot((sphere.transform.position - A), planeN);

        float yMin = plane.transform.position.y - plane.transform.localScale.y / 2;
        float yMax = plane.transform.position.y + plane.transform.localScale.y / 2;

        float zMin = plane.transform.position.z - plane.transform.localScale.z / 2;
        float zMax = plane.transform.position.z + plane.transform.localScale.z / 2;

        float xMin = plane.transform.position.x + plane.transform.localScale.x / 2;
        float xMax = plane.transform.position.x + plane.transform.localScale.x / 2 +0.25f;
        //Debug.LogError("Distance: " + distance);

        if ((sphere.transform.position.y <= yMax && sphere.transform.position.y >= yMin) &&
            sphere.transform.position.z <= yMax && sphere.transform.position.z >= yMin &&
            (sphere.transform.position.x <= xMax && sphere.transform.position.x >= xMin))
                
        {
            return true;
        }

        return false;
    }

    static public bool checkCollisionSphereAABB(GameObject obj1, GameObject obj2)
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

        float radius = obj2.transform.localScale.x;


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
