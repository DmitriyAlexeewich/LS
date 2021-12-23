using Assets.Scripts.AI.Action.StartCondition.TargetStatsCondition.Enumerators;
using Assets.Scripts.Stats;
using Assets.Scripts.Stats.Enumerators;

namespace Assets.Scripts.AI.Action.StartCondition.TargetStatsCondition
{
    public class ConditionStatusValue
    {
        public bool isActive { get; private set; } = false;

        private EnumStatusType _statusType;
        private EnumModifiedFieldType _modifiedFieldType;
        private EnumComparsionType _comparsionType;
        private int _comparsionValue;

        public bool SetActive(ChangedStatusValue changedStatusValue)
        {
            if ((changedStatusValue.StatusType == _statusType) && (changedStatusValue.ModifiedFieldType == _modifiedFieldType))
            {
                int _comparsedValue = -1;

                switch (_modifiedFieldType)
                {
                    case EnumModifiedFieldType.Current:
                        _comparsedValue = changedStatusValue.CurrentValue;
                        break;
                    case EnumModifiedFieldType.Min:
                        _comparsedValue = changedStatusValue.MinValue;
                        break;
                    case EnumModifiedFieldType.Max:
                        _comparsedValue = changedStatusValue.MaxValue;
                        break;
                }

                switch (_comparsionType)
                {
                    case EnumComparsionType.Equal:
                        isActive = _comparsedValue == _comparsionValue;
                        break;
                    case EnumComparsionType.GreaterThan:
                        isActive = _comparsedValue < _comparsionValue;
                        break;
                    case EnumComparsionType.SmallerThan:
                        isActive = _comparsedValue > _comparsionValue;
                        break;
                }
            }

            return isActive;
        }
    }
}
