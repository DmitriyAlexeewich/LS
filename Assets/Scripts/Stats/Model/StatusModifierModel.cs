using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Stats.Model
{
    [System.Serializable]
    public class StatusModifierModel
    {
        public int Id { get { return _Id; } }
        public float ModifierValue { get { return _ModifierValue; } }
        public float OriginalValue { get { return _OriginalValue; } }
        public bool isMultiplier { get { return _isMultiplier; } }
        public bool isUpdated { get { return _isUpdated; } }

        [SerializeField]
        private int _Id;
        [SerializeField]
        private float _ModifierValue;
        [SerializeField]
        private float _OriginalValue;
        [SerializeField]
        private bool _isMultiplier;
        [SerializeField]
        private bool _isUpdated;

        public StatusModifierModel(int NewId, float NewModifierValue, float? NewOriginalValue = null, bool isMultiplierFlag = false, bool isUpdatedFlag = false)
        {
            _isMultiplier = isMultiplierFlag;
            _isUpdated = isUpdatedFlag;

            if (NewId >= 0)
                _Id = NewId;
            if (NewModifierValue > 0f)
                _ModifierValue = NewModifierValue;
            else
            {
                _ModifierValue = 0;
                if(_isMultiplier)
                    _ModifierValue = 1;
            }
            if (NewOriginalValue != null)
                _OriginalValue = NewOriginalValue.Value;
        }
    }
}
