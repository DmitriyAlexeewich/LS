using Assets.Scripts.Player.Model;
using Assets.Scripts.Weapon.Ammo.Models;
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
    private PlayerMovementStatsModel _playerMovementStats;
    [SerializeField]
    private PlayerMouseLookStatsModel _playerMouseLookStats;
    [SerializeField]
    private Transform _weaponBoneTransform;
    [SerializeField]
    private Transform _mainCameraTransform;

    
    [SerializeField]
    private List<PlayerWeaponDataModel> _testPlayerWeaponsData;


    private List<PlayerWeapon> _playerWeapons;
    private PlayerHandVisualisation _playerHandVisualisationComponent;
    private Movement _playerMovementComponent;
    private MouseLook _playerMouseLookComponent;


    void Start()
    {
        _playerMovementComponent = this.gameObject.AddComponent<Movement>();
        _playerMovementComponent.Construct(_playerMovementStats);

        _playerMouseLookComponent = this.gameObject.AddComponent<MouseLook>();
        _playerMouseLookComponent.Construct(_playerMouseLookStats, _mainCameraTransform, _playerMovementComponent.GetPlayerTransform());

        _playerHandVisualisationComponent = _weaponBoneTransform.gameObject.GetComponent<PlayerHandVisualisation>();
        _playerHandVisualisationComponent.Construct(_playerMovementComponent.GetCharacterController());

        //LoadGuns(_testPlayerWeaponsData);
    }

    void Update()
    {
        //ChangeGun();
    }

    void LoadGuns(List<PlayerWeaponDataModel> playerWeaponsData)
    {
        foreach (Transform child in _weaponBoneTransform)
            Destroy(child.gameObject);
        _playerWeapons = new List<PlayerWeapon>();

        for (int i = 0; i < playerWeaponsData.Count; i++)
        {
            var weaponPrefabResource = Resources.Load($"Weapon/Hud/{playerWeaponsData[i].Id}/Weapon_{playerWeaponsData[i].Id}_Bone") as GameObject;
            if (weaponPrefabResource != null)
            {
                var playerWeaponTransform = Instantiate(weaponPrefabResource, _weaponBoneTransform).GetComponent<Transform>();
                _playerWeapons.Add(playerWeaponTransform.gameObject.AddComponent<PlayerWeapon>());
                //PlayerWeaponsData[i].GunData.BulletData.GenerateCheckHitPoints();
                _playerWeapons.Last().Construct(_mainCameraTransform, playerWeaponsData[i], playerWeaponTransform);
            }
        }
        if (_playerWeapons.Count > 0)
            _playerWeapons[0].ShowWeapon();
    }

    void ChangeGun()
    {
        if ((Input.GetAxis("MouseScroll") != 0) && (_playerWeapons.Count > 1))
        {
            SwitchWeapon((Input.GetAxis("MouseScroll") > 0 ? 1 : -1));
        }
    }

    void SwitchWeapon(int direction)
    {
        for (int i = 0; i < _playerWeapons.Count; i++)
        {
            if (_playerWeapons[i].isActiveAndEnabled)
            {
                var currentWeaponIndex = i + direction;
                if (currentWeaponIndex < 0)
                    currentWeaponIndex = _playerWeapons.Count - 1;
                else if (i >= _playerWeapons.Count)
                    currentWeaponIndex = 0;
                _playerHandVisualisationComponent.StartSwitchWeapon(_playerWeapons[i], _playerWeapons[currentWeaponIndex]);
                break;
            }
        }
    }

}
