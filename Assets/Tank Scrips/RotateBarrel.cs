using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBarrel : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -45.0f, 10.0f);

        playerBody.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
    }
}
