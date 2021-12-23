using Assets.Scripts.AI.Action.Enumerators;

namespace Assets.Scripts.AI.Action.StartCondition
{
    public class TargetAIAction
    {
        public EnumAttackActionType AttackActionType { get; }
        public EnumMoveActionType MoveActionType { get; }

        public TargetAIAction(EnumAttackActionType attackActionType, EnumMoveActionType moveActionType)
        {
            AttackActionType = attackActionType;
            MoveActionType = moveActionType;
        }
    }
}
