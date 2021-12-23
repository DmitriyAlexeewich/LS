using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator.ModificatorAlgorithm.Enumerators;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator.ModificatorAlgorithm.Inheritors
{
    [Serializable]
    public class DynamicStatusModificatorAlgorithm : StatusModificatorAlgorithm
    {
        [SerializeField, Min(1)]
        private int _lifetime;

        public DynamicStatusModificatorAlgorithm(EnumModifiedFieldType modifiedFieldType, EnumMathOperationType mathOperationType, int modifierValue, int lifetime) :
            base(modifiedFieldType, mathOperationType, modifierValue)
        {
            _lifetime = lifetime;
        }

        public override bool StartModificatorAlgorithm(ModifiableStatus target)
        {
            bool _result = false;
            try
            {
                _result = ApplyModifications(target, _modifierValue);
                Task.Delay(_lifetime);
            }
            catch { }
            return _result;
        }
    }
}
