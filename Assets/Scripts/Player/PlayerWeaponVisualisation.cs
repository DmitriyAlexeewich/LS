using Assets.Scripts.Player.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerWeaponVisualisation : MonoBehaviour
{
    private Transform _playerWeaponTransformComponent;
    private Vector3 _startPosition;
    private float _weight;
    private float _maxInertiaAmount;
    private bool _isConstructed = false;

    public void Construct(PlayerWeaponVisualisationDataModel playerWeaponVisualisationData, Transform playerWeaponTransform)
    {
        _playerWeaponTransformComponent = playerWeaponTransform;

        _playerWeaponTransformComponent.localPosition = playerWeaponVisualisationData.Position;
        _playerWeaponTransformComponent.localRotation = playerWeaponVisualisationData.Rotation;
        _startPosition = _playerWeaponTransformComponent.localPosition;

        _weight = playerWeaponVisualisationData.Weight;
        _maxInertiaAmount = playerWeaponVisualisationData.MaxInertiaAmount;

        _isConstructed = true;
    }

    public void ShowWeapon()
    {
        _playerWeaponTransformComponent.gameObject.SetActive(true);
    }

    public void HideWeapon()
    {
        _playerWeaponTransformComponent.gameObject.SetActive(false);
    }

    public void DestroyComponent()
    {
        Destroy(this);
    }

    private void Update()
    {
        if (_isConstructed)
        {
            var lerpPosition = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            lerpPosition *= _weight;
            lerpPosition.x = Mathf.Clamp(lerpPosition.x, -_maxInertiaAmount, _maxInertiaAmount);
            lerpPosition.y = Mathf.Clamp(lerpPosition.y, -_maxInertiaAmount, _maxInertiaAmount);
            _playerWeaponTransformComponent.localPosition = Vector3.Lerp(_playerWeaponTransformComponent.localPosition, _startPosition + lerpPosition, Time.deltaTime);
        }
    }
}
