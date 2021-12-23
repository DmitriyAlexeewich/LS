using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator.ModificatorAlgorithm.Enumerators;
using System;

namespace Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator.ModificatorAlgorithm.Inheritors
{
    [Serializable]
    public class StaticStatusModificator : StatusModificatorAlgorithm
    {

        public StaticStatusModificator(EnumModifiedFieldType modifiedFieldType, EnumMathOperationType mathOperationType, int modifierValue) :
            base(modifiedFieldType, mathOperationType, modifierValue)
        { }

        public override bool StartModificatorAlgorithm(ModifiableStatus target)
        {
            return ApplyModifications(target, _modifierValue);
        }
    }
}