using Assets.Scripts.Status.Enumerators;
using Assets.Scripts.Status.Modificator.Enumerators;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Status.Modificator.Inheritors
{
    [Serializable]
    public class DynamicStepStatusModificator : StatusModificator
    {
        [SerializeField, Min(1)]
        private int _stepTime = 0;
        [SerializeField, Min(1)]
        private int _stepsCount = 0;

        private int _maxTime = 5000;

        public DynamicStepStatusModificator(EnumModifiedFieldType modifiedFieldType, EnumMathOperationType mathOperationType, int modifierValue, int stepTime, int stepsCount) :
            base(modifiedFieldType, mathOperationType, modifierValue)
        {
            if ((stepTime > 0) && (stepsCount > 0))
            {
                _stepTime = stepTime;
                for (int i = 0; i < _stepsCount; i++)
                {
                    if ((i + 1) * _stepTime <= _maxTime)
                        _stepsCount++;
                    else
                        break;
                }
            }
            else
            {
                _stepTime = 1;
                _stepsCount = 1;
            }
        }

        public override bool StartModificator(ModifiableStatus target)
        {
            bool _result = false;
            try
            {
                for (int i = 0; i < _stepsCount; i++)
                {
                    _result = ApplyModifications(target, _modifierValue);
                    Task.Delay(_stepTime);
                }
                target.RemoveModificator(this);
            }
            catch { }
            return _result;
        }
    }
}
