using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Ammo.Perk.Condition;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.CreateObject;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.CreateObject.Inheritors.CreateZone.Enumerators;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using System;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.CreateObject.Inheritors.Inheritors.CreateZone
{
    [Serializable]
    public class CreateZonePerk : CreateObjectPerk
    {

        [SerializeReference]
        private Zone _zone;
        [SerializeField]
        private EnumZoneTargetType _zoneTargetType = EnumZoneTargetType.HitObject;

        public CreateZonePerk(EnumStartOn startOn, EnumStartBy startBy, int perkActivationCount, PerkCondition perkCondition) : base(startOn, startBy, perkActivationCount, perkCondition)
        {
        }

        protected override void SpawnObject(Vector3 spawnPosition, BulletEventArgs bulletEventArgs)
        {
            switch (_zoneTargetType)
            {
                case EnumZoneTargetType.ShootInitializer:
                    spawnPosition = bulletEventArgs.ShootInitializerTransform.position;
                    break;
                case EnumZoneTargetType.HitObject:
                    spawnPosition = bulletEventArgs.DestinationPoint;
                    break;
                default:
                    break;
            }
            Zone _tempZone = GameObject.Instantiate(_zone, spawnPosition, new Quaternion(0, 0, 0, 0));
            _tempZone.StartZone();
        }
    }
}