using Assets.Scripts.Stats.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Stats.Model
{
    public class StatusDataModel
    {
        public EnumStatusType StatusType { get { return _StatusType; } }
        public float CurrentValue { get { return _CurrentValue; } }
        public float MaxValue { get { return _MaxValue; } }

        EnumStatusType _StatusType;
        float _CurrentValue;
        float _MaxValue;

        public StatusDataModel(EnumStatusType NewStatusType, float NewCurrentValue, float? NewMaxValue = null)
        {
            _StatusType = NewStatusType;
            _CurrentValue = NewCurrentValue;
            if (NewMaxValue != null)
            {
                if (NewMaxValue.Value > _CurrentValue)
                    _MaxValue = NewMaxValue.Value;
                else
                    _MaxValue = _CurrentValue;
            }
        }
    }
}
