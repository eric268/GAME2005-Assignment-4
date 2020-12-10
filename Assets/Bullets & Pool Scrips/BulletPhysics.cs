using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    //Variables

    public float gravity = -1.8f;
    public Vector3 velocity;
    public Vector3 acceleration;
    public int amIWorkign = 0;
    public float speed = 0.1f;
    public GameObject Bullet;
    bool debug = false;

    void instatiateValues()
    {
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        acceleration = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Start is called before the first frame update

    void Start()
    {


        float frameRate = Time.deltaTime;
        instatiateValues();
        acceleration.y = gravity * frameRate;
       // Debug.LogWarning("Acceleration: " + acceleration);
       // Debug.LogWarning("Frame Rate: " + frameRate);

    }

    bool checkCollisionSphereAABB(GameObject obj1, GameObject obj2)
    { 
        //Obj1 Cube
        //Obj2 Sphere

        float minX = obj1.transform.position.x - obj1.transform.localScale.x /2f;
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
    bool checkCollisionSphereAABBRotated(GameObject obj1, GameObject obj2)
    {
        //Obj1 Cube
        //Obj2 Sphere

        float minX = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float minY = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float maxY = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
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
        GameObject ground = GameObject.Find("Ground");
        GameObject Bullet = GameObject.Find("Ground");
        GameObject EW = GameObject.Find("EastWall");
        GameObject WW = GameObject.Find("WestWall");
        GameObject NW = GameObject.Find("NorthWall");
        GameObject SW = GameObject.Find("SouthWall");


        for (int i = 0; i < 30; i++)
        {
            GameObject indiBullet = Bullet.GetComponent<BulletPool>().bulletPool[i];

            if (indiBullet.GetComponent<Bullet>().active)
            {
                if (checkCollisionSphereAABBRotated(ground, indiBullet))
                {
                    //Debug.Log("COLLIDING!!!\n");
                    indiBullet.GetComponent<Bullet>().velocity.y = -indiBullet.GetComponent<Bullet>().velocity.y;
                }
                if (checkCollisionSphereAABBRotated(EW, indiBullet) || checkCollisionSphereAABBRotated(WW, indiBullet))
                {
                    indiBullet.GetComponent<Bullet>().velocity.z = -indiBullet.GetComponent<Bullet>().velocity.z;
                }
                if (checkCollisionSphereAABB(NW, indiBullet) || checkCollisionSphereAABB(SW, indiBullet))
                {
                   // Debug.Log("COLLIDING!!!\n");
                    indiBullet.GetComponent<Bullet>().velocity.x = -indiBullet.GetComponent<Bullet>().velocity.x;
                }

            }
        }

    }
}
