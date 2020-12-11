using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision : MonoBehaviour
{
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
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

    // Update is called once per frame
    void Update()
    {
        GameObject ground = GameObject.Find("Ground");
        
        for (int i =0; i < 6; i++)
        {
            GameObject indiviBox = ground.GetComponent<BoxGeneration>().boxArray[i];
            if (AABBCollision(indiviBox, ground))
            {
                indiviBox.GetComponent<BoxVariables>().velocity.y = 0f;
                indiviBox.GetComponent<BoxVariables>().gravity = 0f;
                indiviBox.GetComponent<BoxVariables>().onGround = true;
            }
            for (int j=0;j<6;j++)
            {
                if (!indiviBox.GetComponent<BoxVariables>().onGround && i !=j)
                {
                    GameObject nextBox = ground.GetComponent<BoxGeneration>().boxArray[j];
                    if (AABBCollision(indiviBox, nextBox))
                    {
                        indiviBox.GetComponent<BoxVariables>().velocity.y = 0f;
                        indiviBox.GetComponent<BoxVariables>().gravity = 0f;
                        indiviBox.GetComponent<BoxVariables>().onGround = true;
                    }

                }
            }


            pos = indiviBox.transform.position;
            pos.y += indiviBox.GetComponent<BoxVariables>().velocity.y;
            indiviBox.transform.position = pos;

        }
    }
}
