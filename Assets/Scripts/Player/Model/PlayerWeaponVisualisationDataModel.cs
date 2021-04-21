using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.Model
{
    [System.Serializable]
    public class PlayerWeaponVisualisationDataModel
    {
        public Vector3 Position { get { return _Position; } }
        public Quaternion Rotation { get { return _Rotation; } }
        public float Weight { get { return _Weight; } }
        public float MaxInertiaAmount { get { return _MaxInertiaAmount; } }
        public float ShootLightRange { get { return _ShootLightRange; } }
        public float ShootLightIntensity { get { return _ShootLightIntensity; } }
        public float ShootLightTimePercentByShootLoadTime { get { return _ShootLightTimePercentByShootLoadTime; } }
        public Color MainGlowColor { get { return _MainGlowColor; } }
        public Color GlowSecondaryColor { get { return _GlowSecondaryColor; } }
        public Color ShootLightColor { get { return _ShootLightColor; } }


        [SerializeField]
        private Vector3 _Position;
        [SerializeField]
        private Quaternion _Rotation;
        [SerializeField]
        private float _Weight;
        [SerializeField]
        private float _MaxInertiaAmount;
        [SerializeField]
        private float _ShootLightRange;
        [SerializeField]
        private float _ShootLightIntensity;
        [SerializeField]
        private float _ShootLightTimePercentByShootLoadTime;
        [SerializeField]
        [ColorUsage(true, true)]
        private Color _MainGlowColor;
        [SerializeField]
        [ColorUsage(true, true)]
        private Color _GlowSecondaryColor;
        [SerializeField]
        private Color _ShootLightColor;

        public PlayerWeaponVisualisationDataModel(Vector3 NewPosition, Quaternion NewRotation, float NewWeight, float NewMaxInertiaAmount,
                                                  float NewShootLightRange, float NewShootLightIntensity, float NewShootLightTimePercentByShootLoadTime,
                                                  Color NewMainGlowColor, Color NewGlowSecondaryColor, Color NewShootLightColor)
        {
            _Position = NewPosition;
            _Rotation = NewRotation;
            if (NewWeight > 0)
                _Weight = NewWeight;
            else
                _Weight = 0.1f;
            if (NewMaxInertiaAmount >= 0f)
                _MaxInertiaAmount = NewMaxInertiaAmount;
            else
                _MaxInertiaAmount = 0;
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
            _MainGlowColor = NewMainGlowColor;
            _GlowSecondaryColor = NewGlowSecondaryColor;
            _ShootLightColor = NewShootLightColor;
        }
    }
}
