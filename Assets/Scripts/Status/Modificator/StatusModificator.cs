using Assets.Scripts.Status.Enumerators;
using Assets.Scripts.Status.Modificator.ModificatorAlgorithm;
using UnityEngine;

namespace Assets.Scripts.Status.Modificator
{
    public class StatusModificator
    {

        [SerializeField]
        public EnumStatusType StatusType { get; private set; }
        [SerializeReference]
        private StatusModificatorAlgorithm _statusModificatorAlgorithm;

        public StatusModificator(EnumStatusType statusType, StatusModificatorAlgorithm statusModificatorAlgorithm)
        {
            StatusType = statusType;
            if(statusModificatorAlgorithm != null)
                _statusModificatorAlgorithm = statusModificatorAlgorithm;
        }

        public void StartModificator(ModifiableStatus modifiableStatus)
        {
            _statusModificatorAlgorithm.StartModificatorAlgorithm(modifiableStatus);
        }
    }
}
