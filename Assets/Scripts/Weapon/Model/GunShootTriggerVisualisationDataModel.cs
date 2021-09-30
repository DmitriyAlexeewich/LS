using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [System.Serializable]
    public class GunShootTriggerVisualisationDataModel
    {
        public Color MainGlowColor { get { return _mainGlowColor; } }
        public Color GlowSecondaryColor { get { return _glowSecondaryColor; } }

        [SerializeField]
        private Color _mainGlowColor;
        [SerializeField]
        private Color _glowSecondaryColor;

        public GunShootTriggerVisualisationDataModel(Color mainGlowColor, Color glowSecondaryColor)
        {
            _mainGlowColor = mainGlowColor;
            _glowSecondaryColor = glowSecondaryColor;
        }
    }
}
