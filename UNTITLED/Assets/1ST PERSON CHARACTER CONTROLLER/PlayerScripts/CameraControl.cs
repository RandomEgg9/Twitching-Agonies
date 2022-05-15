using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
[SerializeField][Range(1,10)] private float sensY;
[SerializeField][Range(1,10)] private float sensX;
    private float rawsensX = 400;
    private float rawsensY = 400;
    public Transform orientation;
    float xRotate;
    float yRotate;

    private void Start()
    {
        lock_camera();
    }

    private void Update()
    {
        look_around();
    }




private void look_around()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * rawsensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * rawsensY;
        yRotate += mouseX;
        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        orientation.rotation = Quaternion.Euler(0, yRotate, 0);
    }



private void lock_camera()
    {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    }





}


