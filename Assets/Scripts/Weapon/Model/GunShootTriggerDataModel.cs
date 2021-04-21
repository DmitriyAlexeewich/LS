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
        public float WaitingTime { get { return _WaitingTime; } }

        [SerializeField]
        private EnumGunShootTriggerType _GunShootTriggerType;
        [SerializeField]
        private float _WaitingTime;

        public GunShootTriggerDataModel(EnumGunShootTriggerType NewGunShootTriggerType, float NewWaitingTime)
        {
            _GunShootTriggerType = NewGunShootTriggerType;
            if (NewWaitingTime > 0)
                _WaitingTime = NewWaitingTime;
            else
                _WaitingTime = 1;
        }
    }
}
