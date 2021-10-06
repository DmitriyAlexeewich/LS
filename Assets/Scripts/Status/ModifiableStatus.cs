using Assets.Scripts.Status.Enumerators;
using Assets.Scripts.Status.Field;
using Assets.Scripts.Status.Modificator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Status
{
    [Serializable]
    public class ModifiableStatus : Status
    {        
        public FieldContainer ModificatorsCountLimit { get { return _modificatorsCountLimit; } }

        [SerializeField]
        private FieldContainer _modificatorsCountLimit;
        [SerializeField]
        private List<StatusModificator> _statusModificators = new List<StatusModificator>();

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
            if (_statusModificators.Count < _modificatorsCountLimit.FieldValue)
            {
                _statusModificators.Add(statusModificator);
                return statusModificator;
            }
            return null;
        }

        public void RemoveModificator(StatusModificator statusModificator)
        {
            _statusModificators.Remove(statusModificator);
        }

    }
}
