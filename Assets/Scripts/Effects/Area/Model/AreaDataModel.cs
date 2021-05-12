using Assets.Scripts.Effects.Area.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Effects.Area.Model
{
    [System.Serializable]
    public class AreaDataModel
    {
        public Vector3 Size { get { return _Size; } }
        public EnumAreaType AreaType { get { return _AreaType; } }
        public List<AreaEffectDataModel> AreaEffectsData { get { return _AreaEffectsData; } }
        public bool isScaleToSize { get { return _isScaleToSize; } }


        [SerializeField]
        private Vector3 _Size;
        [SerializeField]
        private EnumAreaType _AreaType;
        [SerializeField]
        private List<AreaEffectDataModel> _AreaEffectsData;
        [SerializeField]
        private bool _isScaleToSize;

        public AreaDataModel(Vector3 NewSize, EnumAreaType NewAreaType, List<AreaEffectDataModel> NewAreaEffectsData, bool isScaleToSizeFlag = false)
        {
            if (NewSize != Vector3.zero)
                _Size = NewSize;
            else
                _Size = Vector3.one;
            _AreaType = NewAreaType;
            _AreaEffectsData = NewAreaEffectsData;
            _isScaleToSize = isScaleToSizeFlag;
        }
    }
}
