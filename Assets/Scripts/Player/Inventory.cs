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
    PlayerHandVisualisation PlayerHandVisualisationComponent;
    Movement PlayerMovementComponent;
    MouseLook PlayerMouseLookComponent;


    void Start()
    {
        PlayerMovementComponent = this.gameObject.AddComponent<Movement>();
        PlayerMovementComponent.Construct(PlayerMovementStats);

        PlayerMouseLookComponent = this.gameObject.AddComponent<MouseLook>();
        PlayerMouseLookComponent.Construct(PlayerMouseLookStats, MainCameraTransform, PlayerMovementComponent.GetPlayerTransform());

        PlayerHandVisualisationComponent = WeaponBoneTransform.gameObject.GetComponent<PlayerHandVisualisation>();
        PlayerHandVisualisationComponent.Construct(PlayerMovementComponent.GetCharacterController());

        LoadGuns(TestPlayerWeaponsData);
    }

    void Update()
    {
        ChangeGun();
    }

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

    void ChangeGun()
    {
        if ((Input.GetAxis("MouseScroll") != 0) && (PlayerWeapons.Count > 1))
        {
            SwitchWeapon((Input.GetAxis("MouseScroll") > 0 ? 1 : -1));
        }
    }

    void SwitchWeapon(int Direction)
    {
        for (int i = 0; i < PlayerWeapons.Count; i++)
        {
            if (PlayerWeapons[i].isActiveAndEnabled)
            {
                var currentWeaponIndex = i + Direction;
                if (currentWeaponIndex < 0)
                    currentWeaponIndex = PlayerWeapons.Count - 1;
                else if (i >= PlayerWeapons.Count)
                    currentWeaponIndex = 0;
                PlayerHandVisualisationComponent.StartSwitchWeapon(PlayerWeapons[i], PlayerWeapons[currentWeaponIndex]);
                break;
            }
        }
    }

}
