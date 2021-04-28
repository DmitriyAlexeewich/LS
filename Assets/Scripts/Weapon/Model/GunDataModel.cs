using Assets.Scripts.Weapon.Bullet.Enumerators;
using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [System.Serializable]
    public class GunDataModel
    {
        public BulletDataModel BulletData { get { return _BulletData; } }
        public GunShootDataModel GunShootData { get { return _GunShootData; } }
        public GunShootTriggerDataModel ShootTriggerData { get { return _GunShootTriggerData; } }
        public GunVisualisationDataModel GunVisualisationData { get { return _GunVisualisationData; } }


        [SerializeField]
        private BulletDataModel _BulletData;
        [SerializeField]
        private GunShootDataModel _GunShootData;
        [SerializeField]
        private GunShootTriggerDataModel _GunShootTriggerData;
        [SerializeField]
        private GunVisualisationDataModel _GunVisualisationData;

        public GunDataModel(BulletDataModel NewBulletData, GunShootDataModel NewGunShootData, 
                            GunShootTriggerDataModel NewGunShootTriggerData, GunVisualisationDataModel NewGunVisualisationData)
        {
            _BulletData = NewBulletData;
            _GunShootData = NewGunShootData;
            _GunShootTriggerData = NewGunShootTriggerData;
            _GunVisualisationData = NewGunVisualisationData;
        }
    }
}
