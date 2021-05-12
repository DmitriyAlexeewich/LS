using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class StatusCollection : MonoBehaviour
{

    List<Status> Statuses = new List<Status>();

    public void Construct(List<StatusDataModel> NewStatuses)
    {
        for (int i = 0; i < NewStatuses.Count; i++)
        {
            var status = this.gameObject.AddComponent<Status>();
            status.Construct(NewStatuses[i]);
            Statuses.Add(status);
        }
    }

    public int AddStatusModifier(EnumStatusType StatusType, float NewModifierValue, bool isMultiplierFlag = false, bool isUpdatedFlag = false)
    {
        var status = Statuses.FirstOrDefault(item => item.StatusType == StatusType);
        if (status != null)
            return status.AddStatusModifier(NewModifierValue, isMultiplierFlag, isUpdatedFlag);
        return -1;
    }

    public void RemoveStatusModifier(EnumStatusType StatusType, int Id)
    {
        var status = Statuses.FirstOrDefault(item => item.StatusType == StatusType);
        if (status != null)
            status.RemoveStatusModifier(Id);
    }

    public Status GetStatus(EnumStatusType StatusType)
    {
        return Statuses.FirstOrDefault(item => item.StatusType == StatusType);
    }
}