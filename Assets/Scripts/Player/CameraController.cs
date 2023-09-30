using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform orientation;
    private float mouseSpeed = 200.0f;
    private float mouseX;
    private float mouseY;

    private float xRotation;
    private float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        HideMouse();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        LookAround();
    }

    void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void GetInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;
    }

    void LookAround()
    {
        // Change Rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
