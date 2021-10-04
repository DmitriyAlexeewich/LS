using Assets.Scripts.Status;
using Assets.Scripts.Status.Enumerators;
using Assets.Scripts.Status.Modificator.ModificatorAlgorithm;
using Assets.Scripts.Status.Modificator.ModificatorAlgorithm.Enumerators;
using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Modificator.ModificatorAlgorithm.Inheritors
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