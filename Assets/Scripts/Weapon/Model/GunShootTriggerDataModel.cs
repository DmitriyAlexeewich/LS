using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [System.Serializable]
    public class GunShootTriggerDataModel
    {
        public EnumGunShootTriggerType GunShootTriggerType { get { return _GunShootTriggerType; } }
        public float ShootLoadTime { get { return _ShootLoadTime; } }

        [SerializeField]
        private EnumGunShootTriggerType _GunShootTriggerType;
        [SerializeField]
        private float _ShootLoadTime;

        public GunShootTriggerDataModel(EnumGunShootTriggerType NewGunShootTriggerType, float NewShootLoadTime)
        {
            _GunShootTriggerType = NewGunShootTriggerType;
            if ((NewShootLoadTime > 0) && (NewShootLoadTime < 1))
                _ShootLoadTime = NewShootLoadTime;
            else
                _ShootLoadTime = 0.5f;
        }
    }
}
