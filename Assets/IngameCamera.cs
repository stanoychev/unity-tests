using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCamera : MonoBehaviour
{
    public float speedH = 2f;
    public float speedV = 2f;
    public Camera camera;
    private float yaw = 0f;
    private float pitch = 0f;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        yaw -= speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        float zoom = Input.GetAxis("Mouse ScrollWheel");
        if (zoom > 0) //camera.fieldOfView--;
            transform.position = transform.position * 0.95f;

        else if (zoom < 0) //camera.fieldOfView++;
            transform.position = transform.position * 1.05f;
    }
}
