using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [System.Serializable]
    public class GunVisualisationDataModel
    {
        public Color MainGlowColor { get { return _mainGlowColor; } }
        public Color GlowSecondaryColor { get { return _glowSecondaryColor; } }
        public GunShootLightDataModel GunShootLightData { get { return _gunShootLightData; } }

        [SerializeField]
        [ColorUsage(true, true)]
        private Color _mainGlowColor;
        [SerializeField]
        [ColorUsage(true, true)]
        private Color _glowSecondaryColor;
        [SerializeField]
        private GunShootLightDataModel _gunShootLightData;

        public GunVisualisationDataModel(Color mainGlowColor, Color glowSecondaryColor, GunShootLightDataModel gunShootLightData)
        {
            _mainGlowColor = mainGlowColor;
            _glowSecondaryColor = glowSecondaryColor;
            _gunShootLightData = gunShootLightData;
        }
    }
}
