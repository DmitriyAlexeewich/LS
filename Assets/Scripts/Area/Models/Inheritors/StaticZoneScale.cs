using System;
using UnityEngine;

namespace Assets.Scripts.Area.Models.Inheritors
{
    [Serializable]
    public class StaticZoneScale : ZoneScale
    {
        public int StartScalse { get { return _startScale; } }

        [SerializeField, Min(1)]
        private int _startScale = 1;

        public StaticZoneScale(int startScale = 1)
        {
            if (startScale > _maxiableScale)
                _startScale = _maxiableScale;
            else
                _startScale = startScale;
        }
    }
}
