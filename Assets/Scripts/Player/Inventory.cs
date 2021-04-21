using Assets.Scripts.Player.Model;
using Assets.Scripts.Weapon.Bullet.Enumerators;
using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Model;
using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    PlayerMovementStatsModel PlayerMovementStats;
    [SerializeField]
    PlayerMouseLookStatsModel PlayerMouseLookStats;
    [SerializeField]
    Transform WeaponBoneTransform;
    [SerializeField]
    Transform MainCameraTransform;
    [SerializeField]
    List<GunDataModel> Guns;

    PlayerHUDVisualisation PlayerHUDVisualisationComponent;
    Movement PlayerMovementComponent;
    MouseLook PlayerMouseLookComponent;
    PlayerWeapon PlayerWeaponComponent;
    List<PlayerWeaponVisualisation> PlayerWeaponVisualisationes = new List<PlayerWeaponVisualisation>();
    int CurrentWeaponIndex = 0;

    public int GetWeaponsCount()
    {
        return Guns.Count;
    }

    public PlayerWeaponVisualisation GetPlayerWeaponVisualisation(int Id)
    {
        return PlayerWeaponVisualisationes.FirstOrDefault(item => item.WeaponId == Id);
    }
    
    public void UpdateHudWeaponFromInventory()
    {
        AddHudWeaponFromInventory();
        PlayerWeaponComponent.Construct(Guns[CurrentWeaponIndex]);
    }

    public void StartSwitchWeapon(GunDataModel CurrentWeapon, int Direction)
    {
        PlayerWeaponComponent.enabled = false;

        CurrentWeaponIndex = Guns.IndexOf(CurrentWeapon) + Direction;
        if (CurrentWeaponIndex < 0)
            CurrentWeaponIndex = Guns.Count - 1;
        if (CurrentWeaponIndex >= Guns.Count)
            CurrentWeaponIndex = 0;

        PlayerWeaponComponent.Construct(Guns[CurrentWeaponIndex]);
        PlayerHUDVisualisationComponent.StartSwitchWeapon();
    }

    public void ShowWeapon()
    {
        for (int i = 0; i < PlayerWeaponVisualisationes.Count; i++)
        {
            PlayerWeaponVisualisationes[i].HideWeapon();
            if (PlayerWeaponVisualisationes[i].WeaponId == Guns[CurrentWeaponIndex].Id)
                PlayerWeaponVisualisationes[i].ShowWeapon();
        }
    }

    public void EndSwitchWeapon()
    {
        PlayerWeaponComponent.enabled = true;
    }
    
    void AddHudWeaponFromInventory()
    {
        foreach (Transform child in WeaponBoneTransform)
            Destroy(child.gameObject);

        //!--Rework
        PlayerWeaponVisualisationes = new List<PlayerWeaponVisualisation>();
        for (int i = 0; i < Guns.Count; i++)
        {
            var weaponHudPrefabResource = Resources.Load($"Weapon/Hud/{Guns[i].Id}/Weapon_{Guns[i].Id}_Bone") as GameObject;
            if (weaponHudPrefabResource != null)
            {
                var weaponHudPrefab = Instantiate(weaponHudPrefabResource, WeaponBoneTransform);
                PlayerWeaponVisualisationes.Add(weaponHudPrefab.GetComponent<PlayerWeaponVisualisation>());
                PlayerWeaponVisualisationes.Last().Construct(Guns[i].Id, Guns[i].PlayerWeaponVisualisationData, Guns[i].ShootTriggerData.WaitingTime);
            }
            Guns[i].BulletData.GenerateCheckHitPoints();
        }
        PlayerWeaponVisualisationes.FirstOrDefault(item => item.WeaponId == Guns[CurrentWeaponIndex].Id).ShowWeapon();
        //--!

    }

    void Start()
    {
        PlayerMovementComponent = this.gameObject.AddComponent<Movement>();
        PlayerMovementComponent.Construct(PlayerMovementStats);

        PlayerMouseLookComponent = this.gameObject.AddComponent<MouseLook>();
        PlayerMouseLookComponent.Construct(PlayerMouseLookStats, MainCameraTransform);

        PlayerWeaponComponent = this.gameObject.AddComponent<PlayerWeapon>();
        PlayerWeaponComponent.OnStart(MainCameraTransform, this, Guns[CurrentWeaponIndex]);

        PlayerHUDVisualisationComponent = WeaponBoneTransform.gameObject.GetComponent<PlayerHUDVisualisation>();
        PlayerHUDVisualisationComponent.Construct(PlayerMovementStats.DashSpeed, this, this.gameObject.GetComponent<CharacterController>());//this.gameObject.GetComponent<CharacterController>() -> event

        AddHudWeaponFromInventory();

    }

    void Update()
    {
        ChangeGun();
    }

    void ChangeGun()
    {
        if ((Input.GetAxis("MouseScroll") != 0) && (Guns.Count > 1))
        {
            StartSwitchWeapon(Guns[CurrentWeaponIndex], (Input.GetAxis("MouseScroll") > 0 ? 1 : -1));
        }
    }
}
