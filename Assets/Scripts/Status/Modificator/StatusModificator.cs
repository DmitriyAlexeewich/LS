using Assets.Scripts.Status.Enumerators;
using Assets.Scripts.Status.Modificator.Enumerators;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Status.Modificator
{
    [Serializable]
    public abstract class StatusModificator
    {
        [SerializeField]
        private EnumStatusType _statusType;
        [SerializeField]
        protected EnumModifiedFieldType _modifiedFieldType;
        [SerializeField]
        protected EnumMathOperationType _mathOperationType;
        [SerializeField, Min(0)]
        protected int _modifierValue;

        public StatusModificator(EnumModifiedFieldType modifiedFieldType, EnumMathOperationType mathOperationType, int modifierValue)
        {
            _modifiedFieldType = modifiedFieldType;
            _mathOperationType = mathOperationType;
            _modifierValue = modifierValue;
        }

        public bool StartModificator(StatusCollections statusCollections)
        {
            Status _target = statusCollections.Statuses.FirstOrDefault(item => item.StatusType == _statusType);
            if (_target != null)
                return AddModificator((ModifiableStatus)_target);
            return false;
        }

        protected abstract bool AddModificator(ModifiableStatus target);

        protected bool ApplyModifications(ModifiableStatus target, int modifierValue)
        {
            if (target != null)
            {
                switch (_mathOperationType)
                {
                    case EnumMathOperationType.Summation:
                        return target.AddValue(_modifiedFieldType, modifierValue);
                    case EnumMathOperationType.Subtraction:
                        return target.SubtractValue(_modifiedFieldType, modifierValue);
                    case EnumMathOperationType.Multiplication:
                        return target.MultiplyValue(_modifiedFieldType, modifierValue);
                    case EnumMathOperationType.Division:
                        return target.DivideValue(_modifiedFieldType, modifierValue);
                }
            }
            return false;
        }

    }
}
