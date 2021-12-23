using Assets.Scripts.AI.Action.Enumerators;
using System;

namespace Assets.Scripts.AI.Action.StartCondition
{
    public class ActionStartCondition
    {
        public Action<TargetAIAction> ConditionComplete { get; protected set; }
        protected EnumAttackActionType _attackActionType { get; }
        protected EnumMoveActionType _moveActionType { get; }
        protected Tra

        public ActionStartCondition(EnumAttackActionType attackActionType, EnumMoveActionType moveActionType)
        {
            _attackActionType = attackActionType;
            _moveActionType = moveActionType;
        }
    }
}
