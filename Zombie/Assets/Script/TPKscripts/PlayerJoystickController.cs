using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public FixedJoystick lookJoystick;
    public float speed = .02f;
    public float rotSpeed = 6f;

    private Vector3 dir;

    void Update()
    {
        //UpdateLookJoyStick();
        UpdateMoveJoyStick();
    }

    void UpdateMoveJoyStick()
    {
        float hoz = moveJoystick.Horizontal;
        float vert = moveJoystick.Vertical;

        //Vector2 convertedXY = ConvertWithCamera(Camera.main.transform.position, hoz, vert);

        Vector3 dir = new Vector3(hoz, 0, vert).normalized;
        transform.Translate(dir * speed);

        Vector2 rot = new Vector2(hoz, vert).normalized;
        transform.Rotate(rot * rotSpeed);
        transform.rotation = (Quaternion.LookRotation(dir));
    }
    void UpdateLookJoyStick()
    {
        float hoz = lookJoystick.Horizontal;
        float vert = lookJoystick.Vertical;

        dir = new Vector3(hoz, 0f, vert);

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
        }
        transform.Translate(transform.forward * speed);
    }
}
