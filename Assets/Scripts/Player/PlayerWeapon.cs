using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Model;
using Assets.Scripts.Weapon.Model.Enumerators;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    GunDataModel WeaponData;

    Inventory InventoryComponent = null;
    GunShootTrigger ShootTriggerComponent = null;
    GunShoot GunShootComponent = null;
    PlayerWeaponVisualisation PlayerWeaponVisualisationComponent = null;
    bool isStartShoot = false;
    float WaitShoot = 0;
    Transform BulletSpawnPoint = null;

    public void OnStart(Transform CameraTransform, Inventory NewInventoryComponent, GunDataModel NewWeaponData)
    {
        InventoryComponent = NewInventoryComponent;
        ShootTriggerComponent = this.gameObject.AddComponent<GunShootTrigger>();
        GunShootComponent = this.gameObject.AddComponent<GunShoot>();
        ShootTriggerComponent.SetShootComponent(GunShootComponent);
        ShootTriggerComponent.OnShoot += ShootTriggerComponent_OnShoot;
        GunShootComponent.SetCameraTransform(CameraTransform);
        Construct(NewWeaponData);
    }

    public void Construct(GunDataModel NewWeaponData)
    {
        WeaponData = NewWeaponData;
        var weaponVisualisation = InventoryComponent.GetPlayerWeaponVisualisation(WeaponData.Id);
        BulletSpawnPoint = weaponVisualisation.BulletSpawnPoint;
        ShootTriggerComponent.Construct(NewWeaponData.ShootTriggerData, weaponVisualisation);
        GunShootComponent.Construct(BulletSpawnPoint, NewWeaponData.GunShootData);
        WaitShoot = 0;
        PlayerWeaponVisualisationComponent = InventoryComponent.GetPlayerWeaponVisualisation(WeaponData.Id);
    }


    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (WaitShoot > 0)
            WaitShoot -= Time.deltaTime;
        if ((Input.GetMouseButtonDown(0)) && (isStartShoot == false) && (WaitShoot <= 0))
        {
            ShootTriggerComponent.StartShootLoadCoroutine();
            isStartShoot = true;
        }
        if ((Input.GetMouseButtonUp(0)) && (isStartShoot))
            StopShoot();
    }

    void StopShoot()
    {
        if (WeaponData.ShootTriggerData.Type != EnumGunShootTriggerType.Click)
            ShootTriggerComponent.StopShoot();
        isStartShoot = false;
        WaitShoot = WeaponData.ShootTriggerData.WaitingTime;
        PlayerWeaponVisualisationComponent.StopShootEffect();
    }

    
}
