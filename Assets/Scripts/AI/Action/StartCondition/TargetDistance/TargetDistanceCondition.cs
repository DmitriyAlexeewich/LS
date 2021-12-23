using Assets.Scripts.AI.Action.Enumerators;
using UnityEngine;

namespace Assets.Scripts.AI.Action.StartCondition.TargetDistance
{
    public class TargetDistanceCondition : ActionStartCondition
    {
        private Transform _selfTransform;
        private Transform _targetTransform;
        private int _distance;

        public TargetDistanceCondition(EnumAttackActionType attackActionType, EnumMoveActionType moveActionType, AIAgent selfAiAgent, Transform selfTransform, Transform targetTransform, int distance)
            : base(attackActionType, moveActionType)
        {
            _selfTransform = selfTransform;
            _targetTransform = targetTransform;
            _distance = distance;

            selfAiAgent.Moved += CheckDistance;
        }

        public void CheckDistance()
        {
            if(Vector3.Distance(_selfTransform.position, _targetTransform.position) <= _distance)
                ConditionComplete?.Invoke(new TargetAIAction(_attackActionType, _moveActionType));
        }
    }
}
