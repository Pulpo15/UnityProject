 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    

    public float mouseSensitivity = 100f;
    float joystickSensitivty = 1000f;

    public Transform PlayerBody;

    float xRotation = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {

        //string[] joysticks = Input.GetJoystickNames();
        float mouseX;
        float mouseY;

        Debug.Log(Input.GetJoystickNames().Length);

        if (Input.GetJoystickNames().Length == 0) {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }
        else {
            mouseX = Input.GetAxis("HCam") * joystickSensitivty * Time.deltaTime;
            mouseY = Input.GetAxis("VCam") * joystickSensitivty * Time.deltaTime;
            //https://www.reddit.com/r/Unity3D/comments/1syswe/ps4_controller_map_for_unity/
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
