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
        if (PlayerVariables.isPlaying)
        {

            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -45.0f, 5.0f);

            playerBody.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        }
    }


    //Keep cursor on screen for UI changes
  public void OnGUI()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
