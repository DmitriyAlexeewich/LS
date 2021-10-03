using Assets.Scripts.Weapon.Ammo.Models;
using System;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [Serializable]
    public class GunDataModel
    {
        public BulletDataModel BulletData { get { return _bulletData; } }
        public GunShootDataModel GunShootData { get { return _gunShootData; } }
        public GunShootTriggerDataModel ShootTriggerData { get { return _gunShootTriggerData; } }


        [SerializeField]
        private BulletDataModel _bulletData;
        [SerializeField]
        private GunShootDataModel _gunShootData;
        [SerializeField]
        private GunShootTriggerDataModel _gunShootTriggerData;

        public GunDataModel(BulletDataModel bulletData, GunShootDataModel gunShootData, 
                            GunShootTriggerDataModel gunShootTriggerData)
        {
            _bulletData = bulletData;
            _gunShootData = gunShootData;
            _gunShootTriggerData = gunShootTriggerData;
        }
    }
}
