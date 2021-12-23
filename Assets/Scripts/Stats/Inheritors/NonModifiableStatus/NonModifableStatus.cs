using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Field;
using System;

namespace Assets.Scripts.Stats.Inheritors.NonModifiableStatus
{

    [Serializable]
    public class NonModifableStatus : Status
    {
        public NonModifableStatus(EnumStatusType statusType, FieldContainer currentValue, FieldContainer minValue, FieldContainer maxValue)
            : base(statusType, currentValue, minValue, maxValue){}

    }
}
