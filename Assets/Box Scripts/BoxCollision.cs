using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum planeDirection
{
    X_AXIS_POSITIVE,
    X_AXIS_NEGATIVE,
    Y_AXIS_POSITIVE,
    Y_AXIS_NEGATIVE,
    Z_AXIS_POSITIVE,
    Z_AXIS_NEGATIVE,
     NONE
}
public class BoxCollision : MonoBehaviour
{
    Vector3 pos;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }
    bool pointAABBCollision(GameObject obj1, GameObject point)
    {
        float pointX = point.transform.TransformPoint(Vector3.zero).x;
        float pointY = point.transform.TransformPoint(Vector3.zero).y;
        float pointZ = point.transform.TransformPoint(Vector3.zero).z;

        float minX = obj1.transform.position.x - obj1.transform.localScale.x / 2f;
        float maxX = obj1.transform.position.x + obj1.transform.localScale.x / 2f;
        float minY = obj1.transform.position.y - obj1.transform.localScale.y / 2f;
        float maxY = obj1.transform.position.y + obj1.transform.localScale.y / 2f;
        float minZ = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ = obj1.transform.position.z + obj1.transform.localScale.z / 2f;

        return (pointX >= minX && pointX <= maxX) &&
               (pointY >= minY && pointY <= maxY) &&
               (pointZ >= minZ && pointZ <= maxZ);


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

        float radius = 0.5f;


        float x = Mathf.Max(minX, Mathf.Min(sphereX, maxX));
        float y = Mathf.Max(minY, Mathf.Min(sphereY, maxY));
        float z = Mathf.Max(minZ, Mathf.Min(sphereZ, maxZ));

        float distance = Mathf.Sqrt((x - sphereX) * (x + sphereX) + (y - sphereY) * (y + sphereY) +
        (z - sphereZ) * (z + sphereZ));

        if (distance < radius)
            return true;

        return false;
    }
    bool AABBCollision(GameObject obj1, GameObject obj2)
    {
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
        float minZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f;

        float minX2 = obj2.transform.position.x - obj2.transform.localScale.y / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.y / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.x / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.x / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        return (minX1 <= maxX2 && maxX1 >= minX2) &&
               (minY1 <= maxY2 && maxY1 >= minY2) &&
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }

    public void updateBoxVelocityTankCollision(GameObject box, GameObject tank)
    {
        Vector3 totalMomentum = box.GetComponent<BoxVariables>().momentum + tank.GetComponent<PlayerVariables>().momentum;
        float totalMass = box.GetComponent<BoxVariables>().weight + tank.GetComponent<PlayerVariables>().weight;

        Vector3 newVelocity = totalMomentum / totalMass;

        box.GetComponent<BoxVariables>().velocity = newVelocity;

        //Debug.Log("New Velocity: " + newVelocity);
        //Debug.Log("Total momentum: " + totalMomentum);
        //Debug.Log("Total Mass: " + totalMass);

    }
    void updateBoxVelocityBarrelCollision(GameObject box, GameObject tank)
    {

        Vector3 totalMomentum = box.GetComponent<BoxVariables>().momentum + tank.GetComponent<PlayerVariables>().barrelEndMomentum;
        float totalMass = box.GetComponent<BoxVariables>().weight + tank.GetComponent<PlayerVariables>().barrelEndWeight;

        Vector3 newVelocity = totalMomentum / totalMass;

        box.GetComponent<BoxVariables>().velocity = newVelocity;

        //Debug.Log("New Velocity: " + newVelocity);
        //Debug.Log("Total momentum: " + totalMomentum);
        //Debug.Log("Total Mass: " + totalMass);

    }

    bool drawRayCast(GameObject obj1, GameObject obj2, planeDirection dir)
    {
        float minX1 = obj1.transform.position.x;
        float maxX1 = obj1.transform.position.x;
        float minY1 = obj1.transform.position.y;
        float maxY1 = obj1.transform.position.y;
        float minZ1 = obj1.transform.position.z;
        float maxZ1 = obj1.transform.position.z;

        if (dir == planeDirection.Y_AXIS_NEGATIVE)
        {
            minY1 = obj1.transform.position.y - obj1.transform.localScale.y/2;
        }
        else if (dir == planeDirection.X_AXIS_NEGATIVE)
        {
            minX1 = obj1.transform.position.x - obj1.transform.localScale.x / 2;
        }
        else if (dir == planeDirection.X_AXIS_POSITIVE)
        {
            maxX1 = obj1.transform.position.x + obj1.transform.localScale.x / 2;
        }
        else if (dir == planeDirection.Z_AXIS_NEGATIVE)
        {
            minZ1 = obj1.transform.position.x - obj1.transform.localScale.x / 2;
        }
        else
        {
            maxZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2;
        }





        Vector3 pos1 = new Vector3(minX1, minY1, minZ1);
        Vector3 pos2 = new Vector3(maxX1, maxY1, maxZ1);

        Debug.DrawLine(pos1, pos2);

        float minX2 = obj2.transform.position.x - obj2.transform.localScale.y / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.y / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.x / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.x / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        return (minX1 <= maxX2 && maxX1 >= minX2) &&
               (minY1 <= maxY2 && maxY1 >= minY2) &&
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }
    bool checkCollisionBottomYAxis(GameObject obj1, GameObject obj2)
    {
        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f - 0.15f;
        float maxY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float minZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f;



        Vector3 vec1 = new Vector3(minX1, minY1, minZ1);
        Vector3 vec2 = new Vector3(maxX1, maxY1, maxZ1);
        if (Input.GetKeyDown("space"))
        {
            //Debug.DrawLine(vec1, vec2, Color.white, 2000, true);
        }


        float minX2 = obj2.transform.position.x - obj2.transform.localScale.y / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.y / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.x / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.x / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        return (minX1 <= maxX2 && maxX1 >= minX2) &&
               (minY1 <= maxY2 && maxY1 >= minY2) &&
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }


    bool checkCollisionTopYAxis(GameObject obj1, GameObject obj2)
    {
        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float minY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f + 0.15f;
        float minZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f;



        Vector3 vec1 = new Vector3(minX1, minY1, minZ1);
        Vector3 vec2 = new Vector3(maxX1, maxY1, maxZ1);
        if (Input.GetKeyDown("space"))
        {
            //Debug.DrawLine(vec1, vec2, Color.white, 2000, true);
        }


        float minX2 = obj2.transform.position.x - obj2.transform.localScale.y / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.y / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.x / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.x / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        return (minX1 <= maxX2 && maxX1 >= minX2) &&
               (minY1 <= maxY2 && maxY1 >= minY2) &&
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }
    bool checkCollisionLeftXAxis(GameObject obj1, GameObject obj2)
    {

        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f - 0.15f;
        float maxX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
        float minZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f;

        //Vector3 pos1 = new Vector3(minX1, minY1, minZ1);
        //Vector3 pos2 = new Vector3(maxX1, maxY1, maxZ1);
        //Debug.DrawLine(pos1, pos2);

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
    bool checkCollisionRightXAxis(GameObject obj1, GameObject obj2)
    {
        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f +0.15f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
        float minZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f;

        //Vector3 pos1 = new Vector3(minX1, minY1, minZ1);
        //Vector3 pos2 = new Vector3(maxX1, maxY1, maxZ1);
        //Debug.DrawLine(pos1, pos2);

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
    bool checkCollisionFrontZAxis(GameObject obj1, GameObject obj2)
    {
        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
        float minZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f - 0.15f;
        float maxZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f ;

        float minX2 = obj2.transform.position.x - obj2.transform.localScale.y / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.y / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.x / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.x / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        return (minX1 <= maxX2 && maxX1 >= minX2) &&
               (minY1 <= maxY2 && maxY1 >= minY2) &&
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }
    bool checkCollisionBackZAxis(GameObject obj1, GameObject obj2)
    {
        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
        float minZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f;
        float maxZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f + 0.15f;

        float minX2 = obj2.transform.position.x - obj2.transform.localScale.y / 2f;
        float maxX2 = obj2.transform.position.x + obj2.transform.localScale.y / 2f;
        float minY2 = obj2.transform.position.y - obj2.transform.localScale.x / 2f;
        float maxY2 = obj2.transform.position.y + obj2.transform.localScale.x / 2f;
        float minZ2 = obj2.transform.position.z - obj2.transform.localScale.z / 2f;
        float maxZ2 = obj2.transform.position.z + obj2.transform.localScale.z / 2f;

        return (minX1 <= maxX2 && maxX1 >= minX2) &&
               (minY1 <= maxY2 && maxY1 >= minY2) &&
               (minZ1 <= maxZ2 && maxZ1 >= minZ2);
    }
    void offsetCollision(GameObject obj1, GameObject obj2, planeDirection directionOffset)
    {
        Vector3 obj2Pos = obj2.transform.position;
        float Min, Max, overlap;

        if (directionOffset == planeDirection.Y_AXIS_POSITIVE)
        {
            if (obj1.name == "Ground")
            {
                Max = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
            }
            else
            {
                Max = obj1.transform.position.y + obj1.transform.localScale.y / 2f;
            }
            Min = obj2.transform.position.y - obj2.transform.localScale.y / 2f;
            overlap = Max - Min;
            obj2Pos.y += overlap;
            obj2.transform.position = obj2Pos;
        }
        if (directionOffset == planeDirection.X_AXIS_NEGATIVE)
        {
            Max = obj1.transform.position.x + obj1.transform.localScale.x / 2f;
            Min = obj2.transform.position.x - obj2.transform.localScale.x / 2f - 0.15f;
            overlap = Max - Min;
            obj2Pos.x += overlap;
            obj2.transform.position = obj2Pos;
        }
        if (directionOffset == planeDirection.X_AXIS_POSITIVE)
        {
            Min = obj1.transform.position.x - obj1.transform.localScale.x / 2f;
            Max = obj2.transform.position.x + obj2.transform.localScale.x / 2f - 0.3f;
            overlap = Max - Min;
            //Debug.LogError(overlap);
            obj2Pos.x += overlap;
            obj2.transform.position = obj2Pos;
        }
        if (directionOffset == planeDirection.Z_AXIS_NEGATIVE)
        {
            // if (obj1.name == )
            if (obj1.name == "WestWall"|| obj1.name == "EastWall")
            {
                Max = obj1.transform.position.z + obj1.transform.localScale.z / 2f;
            }
            else
            {
                Max = obj1.transform.position.z + obj1.transform.localScale.x / 2f;
            }

            Min = obj2.transform.position.z - obj2.transform.localScale.z / 2f - 0.15f;
            overlap = Max - Min;
            //Debug.Break();
            obj2Pos.z += overlap;
            obj2.transform.position = obj2Pos;
        }
        if (directionOffset == planeDirection.Z_AXIS_POSITIVE)
        {
            if (obj1.name == "WestWall" || obj1.name == "EastWall")
            {
                Min = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
            }
            else
            {
                Min = obj1.transform.position.z - obj1.transform.localScale.x / 2f;
            }

            Max = obj2.transform.position.z + obj2.transform.localScale.z / 2f - 0.3f;
            overlap = Max - Min;
            //Debug.LogError(overlap);
            obj2Pos.z += overlap;
            obj2.transform.position = obj2Pos;
        }

    }
    void checkCollisionWithGroundAndBoxes()
    {
        GameObject ground = GameObject.Find("Ground");
        //Debug.Break();
        for (int i = 0; i < 6; i++)
        {
            GameObject box = GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[i];
            if (drawRayCast(box, ground, planeDirection.Y_AXIS_NEGATIVE))
            {
                offsetCollision(ground, box, planeDirection.Y_AXIS_POSITIVE);
                box.GetComponent<BoxVariables>().velocity.y = 0f;
                box.GetComponent<BoxVariables>().acceleration.y = 0f;
                box.GetComponent<BoxVariables>().onGround = true;
            }
            else
            {
                box.GetComponent<BoxVariables>().onGround = false;
            }
            for (int j = 0; j < 6; j++)
            {

                if (i != j)
                {
                    GameObject box2 = GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[j];

                    if (AABBCollision(box, box2))
                    {
                        Vector3 dir = box2.transform.position - box.transform.position;

                        planeDirection directionCollision = findSideOfCollision(dir);
                        //Debug.Log(dir);
                        //Debug.Log(directionCollision);
                        ///Debug.Break();


                        if (!checkCollisionBottomYAxis(box, box2))
                        {
                            box.GetComponent<BoxVariables>().onGround = false;
                        }
                        if (directionCollision == planeDirection.Y_AXIS_NEGATIVE)
                        {
                            offsetCollision(box2, box, planeDirection.Y_AXIS_POSITIVE);
                            box.GetComponent<BoxVariables>().velocity.y = 0f;
                            box.GetComponent<BoxVariables>().acceleration.y = 0f;
                            box.GetComponent<BoxVariables>().onGround = true;
                        }
                        else if (directionCollision == planeDirection.X_AXIS_POSITIVE)
                        {
                            offsetCollision(box2, box, planeDirection.X_AXIS_NEGATIVE);
                        }
                        else if (directionCollision == planeDirection.X_AXIS_POSITIVE)
                        {
                            offsetCollision(box2, box, planeDirection.X_AXIS_NEGATIVE);
                        }
                        else if (directionCollision == planeDirection.Z_AXIS_NEGATIVE)
                        {
                            offsetCollision(box2, box, planeDirection.Z_AXIS_POSITIVE);
                        }
                        else if (directionCollision == planeDirection.Z_AXIS_POSITIVE)
                        {
                            offsetCollision(box2, box, planeDirection.Z_AXIS_NEGATIVE);
                        }
                    }
                }
            }
        }

    }

    void checkCollisionWithTank()
    {
        GameObject ground = GameObject.Find("Ground");
        GameObject tank = GameObject.Find("T95-1");
        GameObject barrelEnd = GameObject.Find("BulletEmitter");


        for (int i = 0; i < 6; i++)
        {
            GameObject indiviBox = ground.GetComponent<BoxGeneration>().boxArray[i];
            GameObject collider = GameObject.Find("Ground");
            //Checks if box is colliding with tank
            if (checkCollisionSphereAABB(indiviBox, barrelEnd))
            {
                updateBoxVelocityBarrelCollision(indiviBox, tank);
                planeDirection collisionDirection = findSideOfCollision(indiviBox.transform.InverseTransformPoint(barrelEnd.transform.position));
                //Debug.LogError(collisionDirection);
                //Debug.Break();
                if (collisionDirection == planeDirection.X_AXIS_POSITIVE)
                {
                    // Debug.Log("Collding X Positive");
                    collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, barrelEnd, planeDirection.X_AXIS_NEGATIVE);
                }
                else if (collisionDirection == planeDirection.X_AXIS_NEGATIVE)
                {
                    // Debug.Log("Collding X Positive");
                    collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, barrelEnd, planeDirection.X_AXIS_POSITIVE);
                }

                else if (collisionDirection == planeDirection.Z_AXIS_POSITIVE)
                {

                    collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, barrelEnd, planeDirection.Z_AXIS_NEGATIVE);

                }
                else if (collisionDirection == planeDirection.Z_AXIS_NEGATIVE)
                {
                    collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, barrelEnd, planeDirection.Z_AXIS_POSITIVE);
                }
                else //Collision on bottom of box
                {
                    collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, barrelEnd, planeDirection.Y_AXIS_NEGATIVE);
                }
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    GameObject tankColliders = tank.GetComponent<ColliderArray>().colliderArray[j];
                    planeDirection collisionDirection = findSideOfCollision(indiviBox.transform.InverseTransformPoint(tankColliders.transform.position));
                    if (pointAABBCollision(indiviBox, tankColliders))
                    {
                        if (collisionDirection == planeDirection.X_AXIS_POSITIVE)
                        {
                            // Debug.Log("Collding X Positive");
                            collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, tankColliders, planeDirection.X_AXIS_NEGATIVE);
                        }
                        else if (collisionDirection == planeDirection.X_AXIS_NEGATIVE)
                        {
                            // Debug.Log("Collding X Positive");
                            collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, tankColliders, planeDirection.X_AXIS_POSITIVE);
                        }

                        else if (collisionDirection == planeDirection.Z_AXIS_POSITIVE)
                        {

                            collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, tankColliders, planeDirection.Z_AXIS_NEGATIVE);

                        }
                        else if (collisionDirection == planeDirection.Z_AXIS_NEGATIVE)
                        {
                            collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, tankColliders, planeDirection.Z_AXIS_POSITIVE);
                        }
                        else //Collision on bottom of box
                        {
                            collider.GetComponent<BulletCollision>().offsetBullet(indiviBox, tankColliders, planeDirection.Y_AXIS_NEGATIVE);
                        }
                        updateBoxVelocityTankCollision(indiviBox, tank);
                    }
                }
            }

        }

    }
    void checkCollisionWithWalls()
    {
        GameObject NW = GameObject.Find("NorthWall");
        GameObject SW = GameObject.Find("SouthWall");
        GameObject EW = GameObject.Find("EastWall");
        GameObject WW = GameObject.Find("WestWall");
        GameObject Ceiling = GameObject.Find("Ceiling");
        GameObject[] wallArray = new GameObject[4];
        wallArray[0] = NW;
        wallArray[1] = SW;
        wallArray[2] = EW;
        wallArray[3] = WW;

        for (int i = 0; i < 6; i++)
        {
            GameObject box = GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[i];

            if (checkCollisionLeftXAxis(box, Ceiling))
            {
                box.GetComponent<BoxVariables>().velocity.y = -box.GetComponent<BoxVariables>().velocity.y;
            }
            for (int j = 0; j < 4; j++)
            {
                Vector3 dir = box.transform.position - wallArray[j].transform.position;

                planeDirection directionCollision = findSideOfCollision(dir);

                if (checkCollisionLeftXAxis(box, wallArray[j]))
                {
                    offsetCollision(wallArray[j], box, planeDirection.X_AXIS_NEGATIVE);
                    box.GetComponent<BoxVariables>().velocity.x = -box.GetComponent<BoxVariables>().velocity.x;
                    //Debug.Log(box.name + " collding X_AXIS");
                }
                else if (checkCollisionRightXAxis(box, wallArray[j]))
                {
                    offsetCollision(wallArray[j], box, planeDirection.X_AXIS_POSITIVE);
                    box.GetComponent<BoxVariables>().velocity.x = -box.GetComponent<BoxVariables>().velocity.x;
                    //Debug.Log(box.name + " collding X_AXIS positive!");
                }
                if (checkCollisionFrontZAxis(box, wallArray[j]))
                {
                    //offsetCollision(wallArray[j], box, planeDirection.Z_AXIS_NEGATIVE);
                    box.GetComponent<BoxVariables>().velocity.z = -box.GetComponent<BoxVariables>().velocity.z;
                    //box.GetComponent<BoxVariables>().velocity.x = -box.GetComponent<BoxVariables>().velocity.x;
                    //Debug.Log(box.name + " collding Z_AXIS");
                }
                else if (checkCollisionBackZAxis(box, wallArray[j]))
                {
                    //Debug.LogError(directionCollision);
                    //offsetCollision(wallArray[j], box, planeDirection.Z_AXIS_POSITIVE);
                    box.GetComponent<BoxVariables>().velocity.z = -box.GetComponent<BoxVariables>().velocity.z;
                    //box.GetComponent<BoxVariables>().velocity.x = -box.GetComponent<BoxVariables>().velocity.x;
                    //Debug.Log(box.name + " collding Z_AXIS");
                }
            }
        }

    }
    void updateBoxVelocityBulletCollision(GameObject box, GameObject bullet)
    {
        //Vector3 totalMomentum = box.GetComponent<BoxVariables>().momentum + bullet.GetComponent<Bullet>().momentum*100f;
        //float totalWeight = box.GetComponent<BoxVariables>().weight + bullet.GetComponent<Bullet>().weight;

        //Vector3 newVelocity = totalMomentum / totalWeight;

        //box.GetComponent<BoxVariables>().velocity = newVelocity;

        //Debug.Log("New Velocity: " + newVelocity);
        //Debug.Log("Total momentum: " + totalMomentum);
        //Debug.Log("Total Mass: " + totalWeight);
        box.GetComponent<BoxVariables>().velocity = bullet.GetComponent<Bullet>().momentum/ box.GetComponent<BoxVariables>().weight;
        //Debug.Log(box.GetComponent<BoxVariables>().velocity);
    }
    planeDirection findSideOfCollision(Vector3 pos)
    {
        planeDirection dir;
        float x = Mathf.Abs(pos.x);
        float y = Mathf.Abs(pos.y);
        float z = Mathf.Abs(pos.z);

        if (x > y && x > z)
        {
            if (pos.x > 0)
            {
                dir = planeDirection.X_AXIS_NEGATIVE;
            }
            else
            {
                dir = planeDirection.X_AXIS_POSITIVE;
            }
        }
        else if (y > x && y > z)
        {
            if (pos.y > 0)
            {
                dir = planeDirection.Y_AXIS_POSITIVE;
            }
            else
                dir = planeDirection.Y_AXIS_NEGATIVE;
        }
        else
        {
            if (pos.z > 0)
            {
                dir = planeDirection.Z_AXIS_NEGATIVE;
            }
            else
                dir = planeDirection.Z_AXIS_POSITIVE;
        }


        return dir;
    }
    void checkCollisionBullets()
    {
        int bulletPoolSize = GameObject.Find("Ground").GetComponent<BulletPool>().numBullets;
        for (int i=0; i < bulletPoolSize; i++)
        {
            GameObject indiBullet = GameObject.Find("Ground").GetComponent<BulletPool>().bulletPool[i];
            GameObject collider = GameObject.Find("Ground");
           
            if (indiBullet.GetComponent<Bullet>().active)
            {
                for(int j=0; j<6;j++)
                {
                     GameObject individualBox = GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[j];
                    if (CollisionManager.checkCollisionSphereAABB(individualBox, indiBullet))
                    {
                        planeDirection collisionDirection = findSideOfCollision(individualBox.transform.InverseTransformPoint(indiBullet.transform.position));
                        if (collisionDirection == planeDirection.X_AXIS_POSITIVE)
                        {
                           // Debug.Log("Collding X Positive");
                            updateBoxVelocityBulletCollision(individualBox, indiBullet);
                            collider.GetComponent<BulletCollision>().offsetBullet(indiBullet, individualBox, planeDirection.X_AXIS_POSITIVE);
                            indiBullet.GetComponent<Bullet>().velocity.x = -indiBullet.GetComponent<Bullet>().velocity.x;
                            collider.GetComponent<BulletCollision>().slowBulletOnCollision(indiBullet);
                        }
                        else if (collisionDirection == planeDirection.X_AXIS_NEGATIVE)
                        {
                            //Debug.Log("Collding X Negative");
                            updateBoxVelocityBulletCollision(individualBox, indiBullet);
                            collider.GetComponent<BulletCollision>().offsetBullet(indiBullet, individualBox, planeDirection.X_AXIS_NEGATIVE);
                            indiBullet.GetComponent<Bullet>().velocity.x = -indiBullet.GetComponent<Bullet>().velocity.x;
                            collider.GetComponent<BulletCollision>().slowBulletOnCollision(indiBullet);
                        }

                        else if (collisionDirection == planeDirection.Z_AXIS_POSITIVE)
                        {

                            updateBoxVelocityBulletCollision(individualBox, indiBullet);
                            collider.GetComponent<BulletCollision>().offsetBullet(indiBullet, individualBox, planeDirection.Z_AXIS_POSITIVE);
                            indiBullet.GetComponent<Bullet>().velocity.z = -indiBullet.GetComponent<Bullet>().velocity.z;
                            collider.GetComponent<BulletCollision>().slowBulletOnCollision(indiBullet);

                        }
                        else if (collisionDirection == planeDirection.Z_AXIS_NEGATIVE)
                        {
                            updateBoxVelocityBulletCollision(individualBox, indiBullet);
                            collider.GetComponent<BulletCollision>().offsetBullet(indiBullet, individualBox, planeDirection.Z_AXIS_NEGATIVE);
                            indiBullet.GetComponent<Bullet>().velocity.z = -indiBullet.GetComponent<Bullet>().velocity.z;
                            collider.GetComponent<BulletCollision>().slowBulletOnCollision(indiBullet);
                        }
                        else //Collision on bottom of box
                        {
                            updateBoxVelocityBulletCollision(individualBox, indiBullet);
                            collider.GetComponent<BulletCollision>().offsetBullet(indiBullet, individualBox, planeDirection.Y_AXIS_NEGATIVE);
                            indiBullet.GetComponent<Bullet>().velocity.y = -indiBullet.GetComponent<Bullet>().velocity.y;
                            collider.GetComponent<BulletCollision>().slowBulletOnCollision(indiBullet);
                        }

                    }
                }
            }
        }
    }





    // Update is called once per frame
    void Update()
    {
        checkCollisionWithGroundAndBoxes();
        checkCollisionWithTank();
        checkCollisionWithWalls();
        checkCollisionBullets(); 
    }

}
