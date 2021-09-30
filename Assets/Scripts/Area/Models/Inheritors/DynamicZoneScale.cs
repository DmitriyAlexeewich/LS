using System;
using UnityEngine;

namespace Assets.Scripts.Area.Models.Inheritors
{
    [Serializable]
    public class DynamicZoneScale : ZoneScale
    {
        public int MinScale { get { return _minScale; } }
        public int MaxScale { get { return _maxScale; } }
        public int ScaleTime { get { return _scaleTime; } }

        [SerializeField, Min(0)]
        private int _minScale = 0;
        [SerializeField, Min(1)]
        private int _maxScale = 1;
        [SerializeField, Min(10)]
        private int _scaleTime = 10;

        public DynamicZoneScale(int minScale = 0, int maxScale = 1, int scaleTime = 10)
        {
            _minScale = minScale;
            _maxScale = maxScale;
            _scaleTime = scaleTime;
            if (_maxScale > _maxiableScale)
                _maxScale = _maxiableScale;
            if (_maxScale < _minScale)
                _minScale = _maxScale - 1;
        }
    }
}
