using Assets.Scripts.Player.Model;
using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Model;
using Assets.Scripts.Weapon.Model.Enumerators;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    private Gun _gunComponent;
    private PlayerWeaponVisualisation _playerWeaponVisualisationComponent;

    public void Construct(Transform playerCamera, PlayerWeaponDataModel playerWeaponData, Transform playerWeaponTransform)
    {
        _gunComponent = this.gameObject.AddComponent<Gun>();
        //_gunComponent.Construct(playerCamera, playerWeaponData.GunData);

        _playerWeaponVisualisationComponent = this.gameObject.AddComponent<PlayerWeaponVisualisation>();
        _playerWeaponVisualisationComponent.Construct(playerWeaponData.PlayerWeaponVisualisationData, playerWeaponTransform);
    }

    public void ShowWeapon()
    {
        _playerWeaponVisualisationComponent.ShowWeapon();
    }

    public void HideWeapon()
    {
        _playerWeaponVisualisationComponent.HideWeapon();
    }

    private void Update()
    {
        Shoot();
    }

    /*

        void Shoot()
        {
            if (WaitShoot > 0)
                WaitShoot -= Time.deltaTime;
            if ((Input.GetMouseButtonDown(0)) && (isStartShoot == false) && (WaitShoot <= 0))
            {
                GunComponent.StartShoot();
                isStartShoot = true;
            }
            if ((Input.GetMouseButtonUp(0)) && (isStartShoot))
                StopShoot();
        }

        void StopShoot()
        {
            if (WeaponData.ShootTriggerData.Type != EnumGunShootTriggerType.Click)
                GunComponent.StopShoot();
            isStartShoot = false;
            WaitShoot = WeaponData.ShootTriggerData.WaitingTime;
            PlayerWeaponVisualisationComponent.StopShootEffect();
        }
    */

    private void Shoot()
    {/*
        if (Input.GetMouseButton(0))
            _gunComponent.StartShoot();*/
    }
    
}
