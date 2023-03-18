using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;

    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;

    void Update()
    {
        KeyboardMovement();
    }


    void KeyboardMovement()
    {
        Vector3 dir = new Vector3(0, 0, 0);

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

}