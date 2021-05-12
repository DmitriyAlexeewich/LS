using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Weapon.Effects.Enumerators;
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
        public HashSet<EnumMagicType> ApplicableMagicTypes { get { return _ApplicableMagicTypes; } }
        public float CurrentValue { get { return _CurrentValue; } }
        public float MaxValue { get { return _MaxValue; } }

        EnumStatusType _StatusType;
        HashSet<EnumMagicType> _ApplicableMagicTypes = new HashSet<EnumMagicType>();
        float _CurrentValue;
        float _MaxValue;

        public StatusDataModel(EnumStatusType NewStatusType, HashSet<EnumMagicType> NewApplicableMagicTypes, float NewCurrentValue, float? NewMaxValue = null)
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
            if (NewApplicableMagicTypes.Count > 0)
                _ApplicableMagicTypes = NewApplicableMagicTypes;
        }
    }
}
