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
        public float ShootLightRange { get { return _ShootLightRange; } }
        public float ShootLightIntensity { get { return _ShootLightIntensity; } }
        public float ShootLightTimePercentByShootLoadTime { get { return _ShootLightTimePercentByShootLoadTime; } }
        public Color ShootLightColor { get { return _ShootLightColor; } }


        [SerializeField]
        private float _ShootLightRange;
        [SerializeField]
        private float _ShootLightIntensity;
        [SerializeField]
        private float _ShootLightTimePercentByShootLoadTime;
        [SerializeField]
        private Color _ShootLightColor;

        public GunShootLightDataModel(float NewShootLightRange, float NewShootLightIntensity, float NewShootLightTimePercentByShootLoadTime, Color NewShootLightColor)
        {
            if (NewShootLightRange >= 0f)
                _ShootLightRange = NewShootLightRange;
            else
                _ShootLightRange = 0f;
            if (NewShootLightIntensity > 0f)
                _ShootLightIntensity = NewShootLightIntensity;
            else
                _ShootLightIntensity = 0.1f;
            if (NewShootLightTimePercentByShootLoadTime > 0f)
                _ShootLightTimePercentByShootLoadTime = NewShootLightTimePercentByShootLoadTime;
            else
                _ShootLightTimePercentByShootLoadTime = 0.1f;

            _ShootLightColor = NewShootLightColor;
        }
    }
}
