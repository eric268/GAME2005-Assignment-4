using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    // Start is called before the first frame update

    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}
