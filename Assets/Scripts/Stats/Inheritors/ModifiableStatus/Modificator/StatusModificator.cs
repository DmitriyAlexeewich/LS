using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator.ModificatorAlgorithm;
using System;
using UnityEngine;

namespace Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator
{
    [Serializable]
    public class StatusModificator
    {
        public EnumStatusType StatusType { get { return _statusType; } }

        [SerializeField]
        private EnumStatusType _statusType;
        [SerializeReference]
        private StatusModificatorAlgorithm _statusModificatorAlgorithm;

        public StatusModificator(EnumStatusType statusType, StatusModificatorAlgorithm statusModificatorAlgorithm)
        {
            _statusType = statusType;
            if(statusModificatorAlgorithm != null)
                _statusModificatorAlgorithm = statusModificatorAlgorithm;
        }

        public void StartModificator(ModifiableStatus modifiableStatus)
        {
            _statusModificatorAlgorithm.StartModificatorAlgorithm(modifiableStatus);
        }
    }
}
