using Assets.Scripts.Status;
using Assets.Scripts.Status.Enumerators;
using Assets.Scripts.Status.Modificator;
using Assets.Scripts.Status.Modificator.Enumerators;
using System;

namespace Assets.Scripts.Modificator.Inheritors
{
    [Serializable]
    public class StaticStatusModificator : StatusModificator
    {

        public StaticStatusModificator(EnumModifiedFieldType modifiedFieldType, EnumMathOperationType mathOperationType, int modifierValue) :
            base(modifiedFieldType, mathOperationType, modifierValue)
        { }

        public override bool StartModificator(ModifiableStatus target)
        {
            return ApplyModifications(target, _modifierValue);
        }
    }
}