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
    List<PlayerWeaponDataModel> TestPlayerWeaponsData;


    List<PlayerWeapon> PlayerWeapons;

    PlayerHUDVisualisation PlayerHUDVisualisationComponent;
    Movement PlayerMovementComponent;
    MouseLook PlayerMouseLookComponent;
    int CurrentWeaponIndex = 0;


    void LoadGuns(List<PlayerWeaponDataModel> PlayerWeaponsData)
    {
        foreach (Transform child in WeaponBoneTransform)
            Destroy(child.gameObject);
        PlayerWeapons = new List<PlayerWeapon>();

        for (int i = 0; i < PlayerWeaponsData.Count; i++)
        {
            var weaponPrefabResource = Resources.Load($"Weapon/Hud/{PlayerWeaponsData[i].Id}/Weapon_{PlayerWeaponsData[i].Id}_Bone") as GameObject;
            if (weaponPrefabResource != null)
            {
                var playerWeaponTransform = Instantiate(weaponPrefabResource, WeaponBoneTransform).GetComponent<Transform>();
                PlayerWeapons.Add(playerWeaponTransform.gameObject.AddComponent<PlayerWeapon>());
                PlayerWeaponsData[i].GunData.BulletData.GenerateCheckHitPoints();
                PlayerWeapons.Last().Construct(MainCameraTransform, PlayerWeaponsData[i], playerWeaponTransform);
            }
        }
        if (PlayerWeapons.Count > 0)
            PlayerWeapons[0].ShowWeapon();
    }
    
    /*
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
    */

    void Start()
    {
        PlayerMovementComponent = this.gameObject.AddComponent<Movement>();
        PlayerMovementComponent.Construct(PlayerMovementStats);

        PlayerMouseLookComponent = this.gameObject.AddComponent<MouseLook>();
        PlayerMouseLookComponent.Construct(PlayerMouseLookStats, MainCameraTransform);

        PlayerHUDVisualisationComponent = WeaponBoneTransform.gameObject.GetComponent<PlayerHUDVisualisation>();
        PlayerHUDVisualisationComponent.Construct(PlayerMovementStats.DashSpeed, this, this.gameObject.GetComponent<CharacterController>());//this.gameObject.GetComponent<CharacterController>() -> event

        LoadGuns(TestPlayerWeaponsData);
    }

    void Update()
    {
        ChangeGun();
    }
    
    void ChangeGun()
    {
        if ((Input.GetAxis("MouseScroll") != 0) && (PlayerWeapons.Count > 1))
        {
            //StartSwitchWeapon(Guns[CurrentWeaponIndex], (Input.GetAxis("MouseScroll") > 0 ? 1 : -1));
        }
    }

}
