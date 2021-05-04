using Assets.Scripts.Player.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float MouseSensitivity;
    Transform CameraTransform;

    float XAxisClamp;
    Transform PlayerTransform;

    public void Construct(PlayerMouseLookStatsModel PlayerMouseLookStats, Transform NewCameraTransform, Transform NewPlayerTransform)
    {
        MouseSensitivity = PlayerMouseLookStats.MouseSensitivity;
        CameraTransform = NewCameraTransform;
        PlayerTransform = NewPlayerTransform;
    }

    void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        XAxisClamp += mouseY;

        if (XAxisClamp > 90.0f)
        {
            XAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (XAxisClamp < -90.0f)
        {
            XAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        CameraTransform.Rotate(Vector3.left * mouseY);
        PlayerTransform.Rotate(Vector3.up * mouseX);
    }

    void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = CameraTransform.eulerAngles;
        eulerRotation.x = value;
        CameraTransform.eulerAngles = eulerRotation;
    }
}
