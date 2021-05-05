using UnityEngine;

namespace Assets.Scripts.Stats.Model
{

    [System.Serializable]
    public class PercentageFactorModel
    {
        public int Id { get { return _Id; } }
        public float PercentageFactor { get { return _PercentageFactor; } }
        public float OriginalValue { get { return _OriginalValue; } }
        public bool isMultiplier { get { return _isMultiplier; } }
        public bool isUpdated { get { return _isUpdated; } }

        [SerializeField]
        private int _Id;
        [SerializeField]
        private float _PercentageFactor;
        [SerializeField]
        private float _OriginalValue;
        [SerializeField]
        private bool _isMultiplier;
        [SerializeField]
        private bool _isUpdated;

        public PercentageFactorModel(int NewId, float NewPercentageFactor, float? NewOriginalValue = null, bool isMultiplierFlag = false, bool isUpdatedFlag = false)
        {
            if (NewId >= 0)
                _Id = NewId;
            if (NewPercentageFactor > 0f)
                _PercentageFactor = NewPercentageFactor;
            else
                _PercentageFactor = 1;
            if (NewOriginalValue != null)
                _OriginalValue = NewOriginalValue.Value;
            _isMultiplier = isMultiplierFlag;
            _isUpdated = isUpdatedFlag;
        }
    }
}
