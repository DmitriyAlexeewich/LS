using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Field;
using System;
using UnityEngine;

namespace Assets.Scripts.Stats
{
    [Serializable]
    public abstract class Status
    {
        public EnumStatusType StatusType { get { return _statusType; } }
        public FieldContainer CurrentValue { get { return _currentValue; } }
        public FieldContainer MinValue { get { return _minValue; } }
        public FieldContainer MaxValue { get { return _maxValue; } }
        public Action<ChangedStatusValue> MinValueReached { get; set; }
        public Action<ChangedStatusValue> MaxValueReached { get; set; }
        public Action<ChangedStatusValue> ValueChanged { get; set; }

        [SerializeField]
        [HideInInspector]
        private EnumStatusType _statusType;
        [SerializeField]
        private FieldContainer _currentValue;
        [SerializeField]
        private FieldContainer _minValue;
        [SerializeField]
        private FieldContainer _maxValue;

        public Status(EnumStatusType statusType, FieldContainer currentValue, FieldContainer minValue, FieldContainer maxValue)
        {
            _statusType = statusType;
            _currentValue = currentValue;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public bool AddValue(EnumModifiedFieldType modifiedFieldType, int added)
        {
            FieldContainer _target = GetFieldByModifiedFieldType(modifiedFieldType);
            if (_target != null)
                return ChangesCorrection(modifiedFieldType, _target.GetSummationResult(added), _target);
            return false;
        }

        public bool SubtractValue(EnumModifiedFieldType modifiedFieldType, int subtrahend)
        {
            FieldContainer _target = GetFieldByModifiedFieldType(modifiedFieldType);
            if (_target != null)
                return ChangesCorrection(modifiedFieldType, _target.GetSubtractionResult(subtrahend), _target);
            return false;
        }

        public bool MultiplyValue(EnumModifiedFieldType modifiedFieldType, int multiplier)
        {
            FieldContainer _target = GetFieldByModifiedFieldType(modifiedFieldType);
            if (_target != null)
                return ChangesCorrection(modifiedFieldType, _target.GetMultiplicationResult(multiplier), _target);
            return false;
        }

        public bool DivideValue(EnumModifiedFieldType modifiedFieldType, int divisor)
        {
            FieldContainer _target = GetFieldByModifiedFieldType(modifiedFieldType);
            if (_target != null)
                return ChangesCorrection(modifiedFieldType, _target.GetDivisionResult(divisor), _target);
            return false;
        }

        public bool isMin()
        {
            if (_minValue != null)
                return _currentValue.FieldValue <= _minValue.FieldValue;
            return false;
        }

        public bool isMax()
        {
            if (_maxValue != null)
                return _currentValue.FieldValue >= _maxValue.FieldValue;
            return false;

        }

        private bool ChangesCorrection(EnumModifiedFieldType modifiedFieldType, int changeResult, FieldContainer target)
        {
            if (target.SetFieldValue(changeResult))
            {
                if ((_maxValue != null) && (_currentValue.FieldValue >= _maxValue.FieldValue))
                {
                    MaxValueReached?.Invoke(new ChangedStatusValue(_statusType, modifiedFieldType, _currentValue.FieldValue, _maxValue.FieldValue, _maxValue.FieldValue));
                    _currentValue.SetFieldValue(_maxValue.FieldValue);
                }

                if ((_minValue != null) && (_currentValue.FieldValue <= _minValue.FieldValue))
                {
                    MinValueReached?.Invoke(new ChangedStatusValue(_statusType, modifiedFieldType, _currentValue.FieldValue, _maxValue.FieldValue, _maxValue.FieldValue));
                    _currentValue.SetFieldValue(_minValue.FieldValue);
                }

                ValueChanged?.Invoke(new ChangedStatusValue(_statusType, modifiedFieldType, _currentValue.FieldValue, _maxValue.FieldValue, _maxValue.FieldValue));

                return true;
            }
            return false;
        }

        private FieldContainer GetFieldByModifiedFieldType(EnumModifiedFieldType modifiedFieldType)
        {
            FieldContainer _target = null;
            switch (modifiedFieldType)
            {
                case EnumModifiedFieldType.Current:
                    _target = _currentValue;
                    break;
                case EnumModifiedFieldType.Min:
                    _target = _minValue;
                    break;
                case EnumModifiedFieldType.Max:
                    _target = _maxValue;
                    break;
            }
            return _target;
        }

    }
}
