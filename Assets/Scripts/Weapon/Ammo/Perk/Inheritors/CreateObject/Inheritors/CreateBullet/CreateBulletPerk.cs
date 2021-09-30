﻿using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Ammo.Perk.Condition;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using System;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.Inheritors.CreateObject.Inheritors.CreateBullet
{
    [Serializable]
    public class CreateBulletPerk : CreateObjectPerk
    {

        [SerializeReference]
        private Bullet _bullet;

        public CreateBulletPerk(EnumStartOn startOn, EnumStartBy startBy, int perkActivationCount, PerkCondition perkCondition) : base(startOn, startBy, perkActivationCount, perkCondition)
        {
        }

        protected override void SpawnObject(Vector3 spawnPosition, BulletEventArgs bulletEventArgs)
        {
            Bullet _tempBullet = GameObject.Instantiate(_bullet, spawnPosition, new Quaternion(0, 0, 0, 0));
            _tempBullet.StartBullet(bulletEventArgs.DestinationPoint, bulletEventArgs.ShootInitializerTransform);
        }
    }
}