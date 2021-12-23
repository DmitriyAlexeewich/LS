using Assets.Scripts.AI.Action.Enumerators;
using Assets.Scripts.AI.Action.StartCondition.TargetStatsCondition.Enumerators;
using Assets.Scripts.Stats;
using Assets.Scripts.Stats.Enumerators;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.AI.Action.StartCondition.TargetStatsCondition
{
    public class TargetStatusCondition : ActionStartCondition
    {

        private List<ConditionStatusValue> _conditionStatusValues = new List<ConditionStatusValue>();

        public TargetStatusCondition(EnumAttackActionType attackActionType, EnumMoveActionType moveActionType, EnumStatusChangedEventType statusChangedEventType, EnumStatusType statusType, StatusesContainer statusesContainer, List<ConditionStatusValue> conditionStatusValues)
            : base(attackActionType, moveActionType)
        {
            if(conditionStatusValues != null)
                _conditionStatusValues = conditionStatusValues;

            Status _status = statusesContainer.Statuses.FirstOrDefault(item => item.StatusType == statusType);

            if (_status != null)
            {
                switch (statusChangedEventType)
                {
                    case EnumStatusChangedEventType.MinValueReached:
                        _status.MinValueReached += ReceiveStatusChanges;
                        break;
                    case EnumStatusChangedEventType.MaxValueReached:
                        _status.MaxValueReached += ReceiveStatusChanges;
                        break;
                    case EnumStatusChangedEventType.ValueChanged:
                        _status.ValueChanged += ReceiveStatusChanges;
                        break;
                }
            }
        }

        private void ReceiveStatusChanges(ChangedStatusValue changedStatusValue)
        {
            int _activeCount = 0;
            for (int i = 0; i < _conditionStatusValues.Count; i++)
            {
                _conditionStatusValues[i].SetActive(changedStatusValue);
                if (_conditionStatusValues[i].isActive)
                    _activeCount++;
            }
            if (_activeCount == _conditionStatusValues.Count)
                ConditionComplete?.Invoke(new TargetAIAction(_attackActionType, _moveActionType));
        }
    }
}
