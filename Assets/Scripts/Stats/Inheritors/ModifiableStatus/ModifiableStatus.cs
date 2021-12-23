using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Field;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Stats.Inheritors.ModifiableStatus
{
    [Serializable]
    public class ModifiableStatus : Status
    {        
        public FieldContainer ModificatorsCountLimit { get { return _modificatorsCountLimit; } }

        [SerializeField]
        private FieldContainer _modificatorsCountLimit;
        [SerializeField]
        private List<StatusModificator> _statusModificators;

        public ModifiableStatus(EnumStatusType statusType, FieldContainer currentValue, FieldContainer minValue, FieldContainer maxValue, FieldContainer modificatorsCountLimit, List<StatusModificator> statusModificators)
            :base(statusType, currentValue, minValue, maxValue)
        {
            _modificatorsCountLimit = modificatorsCountLimit;
            if (statusModificators != null)
                _statusModificators = statusModificators;
            else
                _statusModificators = new List<StatusModificator>();
        }

        public StatusModificator AddStatusModificator(StatusModificator statusModificator)
        {
            StatusModificator _modificator = null;

            if (_statusModificators.Count < _modificatorsCountLimit.FieldValue)
            {
               _statusModificators.Add(statusModificator);
                if(_statusModificators.IndexOf(statusModificator) != -1)
                    _modificator = _statusModificators[_statusModificators.IndexOf(statusModificator)];
            }

            return _modificator;
        }

        public void RemoveModificator(StatusModificator statusModificator)
        {
            _statusModificators.Remove(statusModificator);
        }
    }
}
