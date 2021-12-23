using Assets.Scripts.Stats.Enumerators;

namespace Assets.Scripts.Stats
{
    public class ChangedStatusValue
    {
        public EnumStatusType StatusType { get; }
        public EnumModifiedFieldType ModifiedFieldType { get; }
        public int CurrentValue { get; }
        public int MinValue { get; }
        public int MaxValue { get; }

        public ChangedStatusValue(EnumStatusType statusType, EnumModifiedFieldType modifiedFieldType, int currentValue, int minValue, int maxValue)
        {
            StatusType = statusType;
            ModifiedFieldType = modifiedFieldType;
            CurrentValue = currentValue;
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}
