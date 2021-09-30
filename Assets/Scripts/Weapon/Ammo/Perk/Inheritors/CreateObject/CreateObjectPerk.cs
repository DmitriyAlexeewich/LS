using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Ammo.Perk.Condition;
using Assets.Scripts.Weapon.Ammo.Perk.Model;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.Inheritors.CreateObject
{
    [Serializable]
    public abstract class CreateObjectPerk : Perk
    {

        [SerializeField]
        protected List<StartPerkDirectionModel> _startPerkDirections = new List<StartPerkDirectionModel>();

        public CreateObjectPerk(EnumStartOn startOn, EnumStartBy startBy, int perkActivationCount, PerkCondition perkCondition) : base(startOn, startBy, perkActivationCount, perkCondition)
        {
        }

        protected override void ActivatePerk(BulletEventArgs bulletEventArgs)
        {
            if (_startPerkDirections.Count > 0)
            {
                for (int i = 0; i < _startPerkDirections.Count; i++)
                {
                    for (int j = 0; j < _startPerkDirections[i].SpawnCount; j++)
                        SpawnObject(bulletEventArgs.BulletTransform.TransformPoint(_startPerkDirections[j].SpawnPoint), bulletEventArgs);
                }
            }
            else
                SpawnObject(bulletEventArgs.BulletTransform.position, bulletEventArgs);
        }

        protected abstract void SpawnObject(Vector3 spawnPosition, BulletEventArgs bulletEventArgs);

    }
}
