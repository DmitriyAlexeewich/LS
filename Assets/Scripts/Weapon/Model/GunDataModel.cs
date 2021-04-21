using Assets.Scripts.Player.Model;
using Assets.Scripts.Weapon.Bullet.Enumerators;
using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [System.Serializable]
    public class GunDataModel
    {
        public int Id { get { return _Id; } }
        public BulletDataModel BulletData { get { return _BullData; } }
        public GunShootDataModel GunShootData { get { return _GunShootData; } }
        public GunShootTriggerDataModel ShootTriggerData { get { return _GunShootTriggerData; } }
        public PlayerWeaponVisualisationDataModel PlayerWeaponVisualisationData { get { return _PlayerWeaponVisualisationData; } }


        [SerializeField]
        private int _Id;
        [SerializeField]
        private BulletDataModel _BullData;
        [SerializeField]
        private GunShootDataModel _GunShootData;
        [SerializeField]
        private GunShootTriggerDataModel _GunShootTriggerData;
        [SerializeField]
        private PlayerWeaponVisualisationDataModel _PlayerWeaponVisualisationData;

        public GunDataModel(int NewId, BulletDataModel NewBulletData, GunShootDataModel NewGunShootData, 
                               GunShootTriggerDataModel NewGunShootTriggerData, PlayerWeaponVisualisationDataModel NewPlayerWeaponVisualisationData)
        {
            _Id = NewId;
            _BullData = NewBulletData;
            _GunShootData = NewGunShootData;
            _GunShootTriggerData = NewGunShootTriggerData;
            _PlayerWeaponVisualisationData = NewPlayerWeaponVisualisationData;
        }
    }
}
