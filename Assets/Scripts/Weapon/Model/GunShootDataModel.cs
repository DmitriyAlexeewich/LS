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
    public class GunShootDataModel
    {
        public float Distance { get { return _distance; } }
        public List<Vector3> BulletsStartSpawnPosition { get { return _bulletsStartSpawnPosition; } }
        public GunShootLightDataModel GunShootLightData { get { return _gunShootLightData; } }


        [SerializeField]
        private float _distance;
        [SerializeField]
        private List<Vector3> _bulletsStartSpawnPosition;
        [SerializeField]
        private GunShootLightDataModel _gunShootLightData;


        public GunShootDataModel(float distance, List<Vector3> bulletsStartSpawnPosition, GunShootLightDataModel gunShootLightData)
        {
            if (distance > 0)
                _distance = distance;
            else
                _distance = 1;
            if (bulletsStartSpawnPosition.Count > 0)
                _bulletsStartSpawnPosition = bulletsStartSpawnPosition;
            else
                _bulletsStartSpawnPosition.Add(new Vector3(0f, 0f, 0.1f));
            _gunShootLightData = gunShootLightData;
        }
    }
}
