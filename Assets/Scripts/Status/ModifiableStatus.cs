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
        private List<StatusModificatorAlgorithm> _statusModificators = new List<StatusModificatorAlgorithm>();

        public ModifiableStatus(FieldContainer currentValue, FieldContainer minValue, FieldContainer maxValue, FieldContainer modificatorsCountLimit, List<StatusModificatorAlgorithm> statusModificators)
            :base(currentValue, minValue, maxValue)
        {
            _modificatorsCountLimit = modificatorsCountLimit;
            if (statusModificators != null)
                _statusModificators = statusModificators;
            else
                _statusModificators = new List<StatusModificatorAlgorithm>();
        }

        public StatusModificatorAlgorithm AddStatusModificator(StatusModificatorAlgorithm statusModificator)
        {
            if (_statusModificators.Count < _modificatorsCountLimit.FieldValue)
            {
                _statusModificators.Add(statusModificator);
                return statusModificator;
            }
            return null;
        }

        public void RemoveModificator(StatusModificatorAlgorithm statusModificator)
        {
            _statusModificators.Remove(statusModificator);
        }

    }
}
