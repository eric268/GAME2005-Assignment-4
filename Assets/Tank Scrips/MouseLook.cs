﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    public float totalXRotation =0f;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerVariables.isPlaying)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            totalXRotation += mouseX;

            playerBody.Rotate(Vector3.up * mouseX);
            xRotation = Mathf.Clamp(xRotation, -45f, 5f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            xRotation -= mouseY;
            //Debug.Log("Rotation: " + totalXRotation);
        }
    }
}
