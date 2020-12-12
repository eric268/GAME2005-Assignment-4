using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    Vector3 pos;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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

    void updateBoxVelocityTankCollision(GameObject box, GameObject tank)
    {
        Vector3 totalMomentum = box.GetComponent<BoxVariables>().momentum + tank.GetComponent<PlayerVariables>().momentum;
        float totalMass = box.GetComponent<BoxVariables>().weight + tank.GetComponent<PlayerVariables>().weight;

        Vector3 newVelocity = totalMomentum / totalMass;

        box.GetComponent<BoxVariables>().velocity = newVelocity;

        //Debug.Log("New Velocity: " + newVelocity);
        //Debug.Log("Total momentum: " + totalMomentum);
        //Debug.Log("Total Mass: " + totalMass);

    }

    void safteyNetForBoxYPos()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject box = GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[i];
            float yMin = 4.8f;
            Vector3 pos = box.transform.position;
            if (pos.y <= yMin)
            {
                pos.y = yMin;
            }
            box.transform.position = pos;
        }
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

    bool checkCollisionBottomYAxis(GameObject obj1, GameObject obj2)
    {
        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f - 0.15f;
        float maxY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
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
    bool checkCollisionLeftXAxis(GameObject obj1, GameObject obj2)
    {
        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f + 0.15f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
        float minZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f;

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
        float minX1 = obj1.transform.position.x + obj1.transform.localScale.x / 2f -0.15f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.x / 2f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.y / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.y / 2f;
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
    bool checkCollisionFrontZAxis(GameObject obj1, GameObject obj2)
    {
        //This one has to be the plane being checked 
        float minX1 = obj1.transform.position.x - obj1.transform.localScale.y / 2f;
        float maxX1 = obj1.transform.position.x + obj1.transform.localScale.y / 2f;
        float minY1 = obj1.transform.position.y - obj1.transform.localScale.x / 2f;
        float maxY1 = obj1.transform.position.y + obj1.transform.localScale.x / 2f;
        float minZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f;
        float maxZ1 = obj1.transform.position.z - obj1.transform.localScale.z / 2f + 0.15f;

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
        float minZ1 = obj1.transform.position.z + obj1.transform.localScale.z / 2f - 0.15f;
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

    void checkCollisionWithGroundAndBoxes()
    {
        GameObject ground = GameObject.Find("Ground");

        for (int i =0; i < 6;i++)
        {
            GameObject box = GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[i];
            if (checkCollisionBottomYAxis(box, ground))
            {
                box.GetComponent<BoxVariables>().velocity.y = 0f;
                box.GetComponent<BoxVariables>().acceleration.y = 0f;
                box.GetComponent<BoxVariables>().onGround = true;
            }
            if (!checkCollisionBottomYAxis(box, ground))
            {
                box.GetComponent<BoxVariables>().onGround = false;
            }
            for (int j=0; j <6;j++)
            {
                if (!box.GetComponent<BoxVariables>().onGround && i != j)
                {
                    GameObject box2 = GameObject.Find("Ground").GetComponent<BoxGeneration>().boxArray[j];

                    if (checkCollisionBottomYAxis(box, box2))
                    {
                        box.GetComponent<BoxVariables>().velocity.y = 0f;
                        box.GetComponent<BoxVariables>().acceleration.y = 0f;
                        box.GetComponent<BoxVariables>().collidingOtherBox = true;
                    }
                    if (!checkCollisionBottomYAxis(box, box2) && counter >= 40)
                    {
                        box.GetComponent<BoxVariables>().collidingOtherBox = false;
                        counter = 0;
                    }
                }
            }
        }
        counter++;

    }

    void checkCollisionWithTank()
    {
        GameObject ground = GameObject.Find("Ground");
        GameObject tank = GameObject.Find("T95-1");
        GameObject barrelEnd = GameObject.Find("BulletEmitter");


        for (int i = 0; i < 6; i++)
        {
            GameObject indiviBox = ground.GetComponent<BoxGeneration>().boxArray[i];
            //Checks if box is colliding with tank
            if (pointAABBCollision(indiviBox, barrelEnd))
            {
                updateBoxVelocityBarrelCollision(indiviBox, tank);
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    GameObject tankColliders = tank.GetComponent<ColliderArray>().colliderArray[j];
                    if (pointAABBCollision(indiviBox, tankColliders))
                    {
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
                if (checkCollisionLeftXAxis(box, wallArray[j]) || checkCollisionRightXAxis(box, wallArray[j]))
                {
                    box.GetComponent<BoxVariables>().velocity.x = -box.GetComponent<BoxVariables>().velocity.x;
                }
                if (checkCollisionFrontZAxis(box, wallArray[j]) || checkCollisionBackZAxis(box, wallArray[j]))
                {
                    box.GetComponent<BoxVariables>().velocity.z = -box.GetComponent<BoxVariables>().velocity.z;
                    box.GetComponent<BoxVariables>().velocity.x = -box.GetComponent<BoxVariables>().velocity.x;
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
        safteyNetForBoxYPos();

    }
}
