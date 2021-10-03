using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [System.Serializable]
    public class GunShootLightDataModel
    {
        public float ShootLightRange { get { return _shootLightRange; } }
        public float ShootLightIntensity { get { return _shootLightIntensity; } }
        public int ShootLightLifeTime { get { return _shootLightLifeTime; } }
        public Color ShootLightColor { get { return _shootLightColor; } }


        [SerializeField]
        private float _shootLightRange;
        [SerializeField]
        private float _shootLightIntensity;
        [SerializeField]
        private int _shootLightLifeTime;
        [SerializeField]
        private Color _shootLightColor;

        public GunShootLightDataModel(float shootLightRange, float shootLightIntensity, int shootLightLifeTime, Color shootLightColor)
        {
            if (shootLightRange >= 0f)
                _shootLightRange = shootLightRange;
            else
                _shootLightRange = 0f;
            if (shootLightIntensity > 0f)
                _shootLightIntensity = shootLightIntensity;
            else
                _shootLightIntensity = 0.1f;
            if (shootLightLifeTime > 0)
                _shootLightLifeTime = shootLightLifeTime;
            else
                _shootLightLifeTime = 100;

            _shootLightColor = shootLightColor;
        }
    }
}
