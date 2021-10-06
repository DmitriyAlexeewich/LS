using Assets.Scripts.Status.Enumerators;
using Assets.Scripts.Status.Modificator.ModificatorAlgorithm.Enumerators;
using System;
using UnityEngine;

namespace Assets.Scripts.Status.Modificator.ModificatorAlgorithm
{
    [Serializable]
    public abstract class StatusModificatorAlgorithm
    {
        [SerializeField]
        protected EnumModifiedFieldType _modifiedFieldType;
        [SerializeField]
        protected EnumMathOperationType _mathOperationType;
        [SerializeField, Min(0)]
        protected int _modifierValue;

        public StatusModificatorAlgorithm(EnumModifiedFieldType modifiedFieldType, EnumMathOperationType mathOperationType, int modifierValue)
        {
            _modifiedFieldType = modifiedFieldType;
            _mathOperationType = mathOperationType;
            _modifierValue = modifierValue;
        }

        public abstract bool StartModificatorAlgorithm(ModifiableStatus target);

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
