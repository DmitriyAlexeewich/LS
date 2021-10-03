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
        public EnumGunShootTriggerType GunShootTriggerType { get { return _gunShootTriggerType; } }
        public int ShootLoadTime { get { return _shootLoadTime; } }
        public GunShootTriggerVisualisationDataModel GunShootTriggerVisualisationData { get { return _gunShootTriggerVisualisationData; } }

        [SerializeField]
        private EnumGunShootTriggerType _gunShootTriggerType;
        [SerializeField]
        private int _shootLoadTime;
        [SerializeField]
        private GunShootTriggerVisualisationDataModel _gunShootTriggerVisualisationData;

        public GunShootTriggerDataModel(EnumGunShootTriggerType gunShootTriggerType, int shootLoadTime, GunShootTriggerVisualisationDataModel gunShootTriggerVisualisationData)
        {
            _gunShootTriggerType = gunShootTriggerType;
            if ((shootLoadTime > 0) && (shootLoadTime < 1))
                _shootLoadTime = shootLoadTime;
            else
                _shootLoadTime = 1;
            _gunShootTriggerVisualisationData = gunShootTriggerVisualisationData;
        }
    }
}
