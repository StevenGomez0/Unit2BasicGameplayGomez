using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float SensX;
    public float SensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        //locks cursor in middle of screen, makes it invisible
        //probably important
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //detecting mouse movement using input.getaxisraw and multiplying by sensitivity
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensY;

        //adds detected rotation to mouse variables
        yRotation += mouseX;
        xRotation += mouseY;

        //keeps camera from moving past -90 or 90 degrees rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotating camera 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //rotating player
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
