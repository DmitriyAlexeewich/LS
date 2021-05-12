using Assets.Scripts.Effects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Effects.Area.Model
{
    [System.Serializable]
    public class AreaEffectDataModel
    {

        public EffectDataModel EffectData { get { return _EffectData; } }
        public bool isAddEffectOnEnter { get { return _isAddEffectOnEnter; } }
        public bool isAddEffectOnExit { get { return _isAddEffectOnExit; } }
        public bool isRemoveEffectOnExit { get { return _isRemoveEffectOnExit; } }


        [SerializeField]
        private EffectDataModel _EffectData;
        [SerializeField]
        private bool _isAddEffectOnEnter;
        [SerializeField]
        private bool _isAddEffectOnExit;
        [SerializeField]
        private bool _isRemoveEffectOnExit;


        public AreaEffectDataModel(EffectDataModel NewEffectData, bool isAddEffectOnEnterFlag = false, bool isAddEffectOnExitFlag = false, bool isRemoveEffectOnExitFlag = false)
        {
            _EffectData = NewEffectData;
            _isAddEffectOnEnter = isAddEffectOnEnterFlag;
            _isAddEffectOnExit = isAddEffectOnExitFlag;
            _isRemoveEffectOnExit = isRemoveEffectOnExitFlag;
        }
    }
}
