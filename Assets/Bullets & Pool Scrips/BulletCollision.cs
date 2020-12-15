using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletCollision : MonoBehaviour
{
    //Variables

    public Vector3 velocity;
    public Vector3 acceleration;
    public int amIWorkign = 0;
    public float speed = 0.1f;
    public GameObject Bullet;
    public GameObject[] boxArray;

    //bool debug = false;

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
        //acceleration.y = gravity * frameRate;
       // Debug.LogWarning("Acceleration: " + acceleration);
       // Debug.LogWarning("Frame Rate: " + frameRate);

        for (int i=0; i < 6;i++)
        {

        }

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
    public void slowBulletOnCollision(GameObject bullet)
    {
        Vector3 slowAmount = bullet.GetComponent<Bullet>().velocity * bullet.GetComponent<Bullet>().wallSlowPercentage;
        bullet.GetComponent<Bullet>().velocity -= slowAmount;
        if (bullet.GetComponent<Bullet>().velocity.magnitude <= 0.1f)
        {
            Debug.Log(Bullet.name + " deactivated");
            bullet.GetComponent<Bullet>().active = false;
            //Debug.LogError(bullet.name +  " Despawned");
        }
    }

    public void offsetBullet(GameObject bullet, GameObject wall, planeDirection dir)
    {
        float offset;
        Vector3 pos;
        if (dir == planeDirection.Y_AXIS_NEGATIVE)
        {
            pos = bullet.transform.position;
            offset = wall.transform.position.y - (bullet.transform.position.y - bullet.transform.localScale.y);
            //Debug.LogError("Offset: " + offset);
            pos.y += Mathf.Abs(offset);
            bullet.transform.position = pos;
        }
        else if (dir == planeDirection.Y_AXIS_POSITIVE)
        {
            pos = bullet.transform.position;
            offset = wall.transform.position.y - (bullet.transform.position.y + bullet.transform.localScale.y);
            //Debug.LogError(offset);
            pos.y -= Mathf.Abs(offset);
            bullet.transform.position = pos;
        }
        else if (dir == planeDirection.X_AXIS_NEGATIVE)
        {
            pos = bullet.transform.position;
            offset = wall.transform.position.x + wall.transform.localScale.x / 2 - (bullet.transform.position.x - bullet.transform.localScale.x / 2);

            float temp1 = wall.transform.position.x + wall.transform.localScale.x / 2;
            float temp2 = bullet.transform.position.x - bullet.transform.localScale.x / 2;
            //Debug.LogError("Wall: " + temp1);
            //Debug.LogError("Bullet: " + temp2);
            //Debug.LogError("Offset: " + offset);
            pos.x += Mathf.Abs(offset);
            bullet.transform.position = pos;
            //Debug.Break();

        }
        else if (dir == planeDirection.X_AXIS_POSITIVE)
        {
            pos = bullet.transform.position;
            offset = wall.transform.position.x - wall.transform.localScale.x / 2 - (bullet.transform.position.x + bullet.transform.localScale.x / 2);
            //Debug.LogError(offset);
            pos.x -= Mathf.Abs(offset);
            bullet.transform.position = pos;
        }
        else if (dir == planeDirection.Z_AXIS_NEGATIVE)
        {
            pos = bullet.transform.position;
            offset = wall.transform.position.z + wall.transform.localScale.z/2 - (bullet.transform.position.z - bullet.transform.localScale.z/2);
            float temp = wall.transform.position.z + wall.transform.localScale.z/2;
            //Debug.LogError(offset);
            pos.z += Mathf.Abs(offset);
            bullet.transform.position = pos;
        }
        else if (dir == planeDirection.Z_AXIS_POSITIVE)
        {
            pos = bullet.transform.position;
            offset = wall.transform.position.z - wall.transform.localScale.z / 2 - (bullet.transform.position.z + bullet.transform.localScale.z / 2);
            float temp = bullet.transform.position.z + bullet.transform.localScale.z / 2;
            //Debug.LogError(offset);
            pos.z -= Mathf.Abs(offset);
            bullet.transform.position = pos;
        }
        else if (dir == planeDirection.Y_AXIS_NEGATIVE)
        {
            pos = bullet.transform.position;
            offset = wall.transform.position.y - wall.transform.localScale.y / 2 - (bullet.transform.position.y + bullet.transform.localScale.y / 2);

            float temp1 = wall.transform.position.y - wall.transform.localScale.y / 2;
            float temp2 = bullet.transform.position.y + bullet.transform.localScale.y / 2;

            Debug.LogError("Wall: " + temp1);
            Debug.LogError("Bullet: " + temp2);
            Debug.LogError("Offset: " + offset);
            pos.y -= Mathf.Abs(offset);
            bullet.transform.position = pos;
            //Debug.Break();

        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ground = GameObject.Find("Ground");
        GameObject ceiling = GameObject.Find("Ceiling");
        GameObject Bullet = GameObject.Find("Ground");
        GameObject EW = GameObject.Find("EastWall");
        GameObject WW = GameObject.Find("WestWall");
        GameObject NW = GameObject.Find("NorthWall");
        GameObject SW = GameObject.Find("SouthWall");

        int bulletPoolSize = GameObject.Find("Ground").GetComponent<BulletPool>().numBullets;
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject indiBullet = Bullet.GetComponent<BulletPool>().bulletPool[i];

            if (indiBullet.GetComponent<Bullet>().active)
            {
                //Debug.Log(indiBullet.GetComponent<Bullet>().velocity.magnitude);
                if (checkCollisionSphereAABBRotated(ground, indiBullet))
                {
                    offsetBullet(indiBullet, ground, planeDirection.Y_AXIS_NEGATIVE);
                    indiBullet.GetComponent<Bullet>().velocity.y = -indiBullet.GetComponent<Bullet>().velocity.y;
                    slowBulletOnCollision(indiBullet);
                }
                if (checkCollisionSphereAABB(ceiling, indiBullet))
                {
                    offsetBullet(indiBullet, ceiling, planeDirection.Y_AXIS_POSITIVE);
                    indiBullet.GetComponent<Bullet>().velocity.y = -indiBullet.GetComponent<Bullet>().velocity.y;
                    slowBulletOnCollision(indiBullet);
                }


                if (checkCollisionSphereAABBRotated(EW, indiBullet))
                {
                    offsetBullet(indiBullet, EW, planeDirection.Z_AXIS_POSITIVE);
                    indiBullet.GetComponent<Bullet>().velocity.z = -indiBullet.GetComponent<Bullet>().velocity.z;
                    slowBulletOnCollision(indiBullet);

                }
                if (checkCollisionSphereAABBRotated(WW, indiBullet))
                {
                    offsetBullet(indiBullet, WW, planeDirection.Z_AXIS_NEGATIVE);
                    indiBullet.GetComponent<Bullet>().velocity.z = -indiBullet.GetComponent<Bullet>().velocity.z;
                    slowBulletOnCollision(indiBullet);
                }
                if (checkCollisionSphereAABB(SW, indiBullet))
                {
                    offsetBullet(indiBullet, SW, planeDirection.X_AXIS_POSITIVE);
                    indiBullet.GetComponent<Bullet>().velocity.x = -indiBullet.GetComponent<Bullet>().velocity.x;
                    slowBulletOnCollision(indiBullet);
                }
                if (checkCollisionSphereAABB(NW, indiBullet))
                {
                    offsetBullet(indiBullet, NW, planeDirection.X_AXIS_NEGATIVE);
                    indiBullet.GetComponent<Bullet>().velocity.x = -indiBullet.GetComponent<Bullet>().velocity.x;
                    slowBulletOnCollision(indiBullet);

                }
            }
        }
    }
}
