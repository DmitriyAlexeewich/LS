using Assets.Scripts.Stats;
using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Field;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus;
using Assets.Scripts.Stats.Inheritors.NonModifiableStatus;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusesContainer : MonoBehaviour
{
    public List<Status> Statuses { get { return _statuses; } }

    [SerializeReference]
    private List<Status> _statuses = new List<Status>();

    public void AddStatus(EnumStatusType statusType, bool isModifiable)
    {
        if ((_statuses.FirstOrDefault(item => item.StatusType == statusType) == null))
        {
            if (isModifiable)
                _statuses.Add(new ModifiableStatus(statusType, new FieldContainer(), new FieldContainer(), new FieldContainer(), new FieldContainer(), new List<StatusModificator>()));
            else
                _statuses.Add(new NonModifableStatus(statusType, new FieldContainer(), new FieldContainer(), new FieldContainer()));
        }
    }
}
