using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Effects.Model
{
    [System.Serializable]
    public class EffectDataModel
    {
        public EnumMagicType MagicType { get { return _MagicType; } }
        public EnumStatusType TargetStatusType { get { return _TargetStatusType; } }
        public float EffectValue { get { return _EffectValue; }}
        public bool isMultiplier { get { return _isMultiplier; } }
        public bool isUpdated { get { return _isUpdated; } }


        [SerializeField]
        private EnumMagicType _MagicType;
        [SerializeField]
        private EnumStatusType _TargetStatusType;
        [SerializeField]
        private float _EffectValue;
        [SerializeField]
        private bool _isMultiplier;
        [SerializeField]
        private bool _isUpdated;


        public EffectDataModel(EnumMagicType NewMagicType, EnumStatusType NewTargetStatusType, float NewEffectValue, bool isMultiplierFlag, bool isUpdatedFlag)
        {
            _MagicType = NewMagicType;
            _TargetStatusType = NewTargetStatusType;
            _isMultiplier = isMultiplierFlag;
            _isUpdated = isUpdatedFlag;
            if (NewEffectValue > 0f)
                _EffectValue = NewEffectValue;
            else
            {
                _EffectValue = 0;
                if (_isMultiplier)
                    _EffectValue = 1;
            }
        }
    }
}
