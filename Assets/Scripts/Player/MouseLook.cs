using Assets.Scripts.Player.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float _mouseSensitivity;
    private Transform _cameraTransform;

    private float _xAxisClamp;
    private Transform _playerTransform;

    public void Construct(PlayerMouseLookStatsModel playerMouseLookStats, Transform cameraTransform, Transform playerTransform)
    {
        _mouseSensitivity = playerMouseLookStats.MouseSensitivity;
        _cameraTransform = cameraTransform;
        _playerTransform = playerTransform;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _xAxisClamp += mouseY;

        if (_xAxisClamp > 90.0f)
        {
            _xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (_xAxisClamp < -90.0f)
        {
            _xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        _cameraTransform.Rotate(Vector3.left * mouseY);
        _playerTransform.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = _cameraTransform.eulerAngles;
        eulerRotation.x = value;
        _cameraTransform.eulerAngles = eulerRotation;
    }
}
