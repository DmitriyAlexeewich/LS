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
        public Color MainGlowColor { get { return _MainGlowColor; } }
        public Color GlowSecondaryColor { get { return _GlowSecondaryColor; } }
        public GunShootLightDataModel GunShootLightData { get { return _GunShootLightData; } }

        [SerializeField]
        [ColorUsage(true, true)]
        private Color _MainGlowColor;
        [SerializeField]
        [ColorUsage(true, true)]
        private Color _GlowSecondaryColor;
        [SerializeField]
        private GunShootLightDataModel _GunShootLightData;

        public GunVisualisationDataModel(Color NewMainGlowColor, Color NewGlowSecondaryColor, GunShootLightDataModel NewGunShootLightData)
        {
            _MainGlowColor = NewMainGlowColor;
            _GlowSecondaryColor = NewGlowSecondaryColor;
            _GunShootLightData = NewGunShootLightData;
        }
    }
}
