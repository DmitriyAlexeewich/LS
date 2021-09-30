using System;
using UnityEngine;

namespace Assets.Scripts.Status.Field
{
    [Serializable]
    public class FieldContainer
    {
        public int FieldValue { get { return _fieldValue; } }
        public int Min { get { return _min; } }
        public int Max { get { return _max; } }

        [SerializeField, Min(0)]
        private int _fieldValue;
        [SerializeField, Min(0)]
        private int _min;
        [SerializeField, Min(1)]
        private int _max;

        public FieldContainer(int fieldValue, int max, int min)
        {
            _fieldValue = fieldValue;
            _min = max;
            _max = min;
        }

        public bool SetFieldValue(int _fieldValue)
        {
            int _fieldValueSettingResult = _fieldValue;
            return ChangesCorrection(_fieldValueSettingResult);
        }

        public bool Add(int added)
        {
            return ChangesCorrection(GetSummationResult(added));
        }

        public bool Subtraction(int subtrahend)
        {
            return ChangesCorrection(GetSubtractionResult(subtrahend));
        }

        public bool Multiplication(int multiplier)
        {
            return ChangesCorrection(GetMultiplicationResult(multiplier));
        }

        public bool Division(int divisor)
        {
            return ChangesCorrection(GetDivisionResult(divisor));
        }

        public bool isMax()
        {
            return _fieldValue >= _max;
        }

        public bool isMin()
        {
            return _fieldValue <= _min;
        }

        public int GetSummationResult(int added)
        {
            int _additionResult = _fieldValue + added;
            return _additionResult;
        }

        public int GetSubtractionResult(int subtrahend)
        {
            int _subtractionResult = _fieldValue - subtrahend;
            return _subtractionResult;
        }

        public int GetMultiplicationResult(int multiplier)
        {
            int _multiplicationResult = _fieldValue * multiplier;
            return _multiplicationResult;
        }

        public int GetDivisionResult(int divisor)
        {
            int _divisionResult = _fieldValue / divisor;
            return _divisionResult;
        }

        protected bool ChangesCorrection(int changesResult)
        {
            if (changesResult >= _max)
            {
                _fieldValue = _max;
                return false;
            }

            if (changesResult <= _min)
            {
                _fieldValue = _min;
                return false;
            }
            _fieldValue = changesResult;
            return true;
        }
    }
}
