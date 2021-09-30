using Assets.Scripts.Status.Enumerators;
using Assets.Scripts.Status.Modificator.Enumerators;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Status.Modificator.Inheritors
{
    [Serializable]
    public class DynamicStatusModificator : StatusModificator
    {
        [SerializeField, Min(1)]
        private int _lifetime;

        public DynamicStatusModificator(EnumModifiedFieldType modifiedFieldType, EnumMathOperationType mathOperationType, int modifierValue, int lifetime) :
            base(modifiedFieldType, mathOperationType, modifierValue)
        {
            _lifetime = lifetime;
        }

        public override bool StartModificator(ModifiableStatus target)
        {
            bool _result = false;
            try
            {
                _result = ApplyModifications(target, _modifierValue);
                Task.Delay(_lifetime);
                target.RemoveModificator(this);
            }
            catch { }
            return _result;
        }
    }
}
