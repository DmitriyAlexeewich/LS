using Assets.Scripts.Player.Model;
using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Model;
using Assets.Scripts.Weapon.Model.Enumerators;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    Gun GunComponent;
    PlayerWeaponVisualisation PlayerWeaponVisualisationComponent;

    public void Construct(Transform PlayerCamera, PlayerWeaponDataModel PlayerWeaponData, Transform PlayerWeaponTransform)
    {
        GunComponent = this.gameObject.AddComponent<Gun>();
        GunComponent.Construct(PlayerCamera, PlayerWeaponData.GunData);

        PlayerWeaponVisualisationComponent = this.gameObject.AddComponent<PlayerWeaponVisualisation>();
        PlayerWeaponVisualisationComponent.Construct(PlayerWeaponData.PlayerWeaponVisualisationData, PlayerWeaponTransform);
    }

    public void ShowWeapon()
    {
        PlayerWeaponVisualisationComponent.ShowWeapon();
    }

    public void HideWeapon()
    {
        PlayerWeaponVisualisationComponent.HideWeapon();
    }

    void Update()
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

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
            GunComponent.StartShoot();
        if(Input.GetMouseButtonUp(0))
            GunComponent.StopShoot();
    }
    
}
