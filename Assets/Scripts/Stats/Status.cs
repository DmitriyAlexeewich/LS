using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Status : MonoBehaviour
{
    public EnumStatusType StatusType { get { return _StatusType; } }

    EnumStatusType _StatusType;
    float CurrentValue;
    float MaxValue;

    List<StatusModifierModel> StatusModifiers = new List<StatusModifierModel>();

    IEnumerator DynamicModifyStatusCoroutine;

    public void Construct(float StartValue, EnumStatusType NewStatusType, float? NewMaxValue = null)
    {
        CurrentValue = StartValue;
        _StatusType = NewStatusType;
        if (NewMaxValue != null)
            MaxValue = NewMaxValue.Value;
    }

    public int AddStatusModifier(float NewModifierValue, bool isMultiplierFlag = false, bool isUpdatedFlag = false)
    {
        var id = StatusModifiers.Count;
        var statusModifier = new StatusModifierModel(id, NewModifierValue, CurrentValue, isMultiplierFlag, isUpdatedFlag);
        StatusModifiers.Add(statusModifier);
        if (isUpdatedFlag)
            StartDynamicModifyStatusCoroutine();
        else
            StaticModifyStatus(statusModifier);
        return id;
    }

    public void RemoveStatusModifier(int Id)
    {
        
    }

    void StaticModifyStatus(StatusModifierModel StatusModifier)
    {
        if (StatusModifier.isMultiplier)
            CurrentValue *= StatusModifier.ModifierValue;
        else
            CurrentValue += StatusModifier.ModifierValue;
    }

    void StartDynamicModifyStatusCoroutine()
    {
        if (DynamicModifyStatusCoroutine == null)
        {
            DynamicModifyStatusCoroutine = DynamicModifyStatus();
            StartCoroutine(DynamicModifyStatusCoroutine);
        }
    }

    void StopDynamicModifyStatusCoroutine()
    {
        StopCoroutine(DynamicModifyStatusCoroutine);
        DynamicModifyStatusCoroutine = null;
    }

    IEnumerator DynamicModifyStatus()
    {
        while (true)
        {
            float timer = 0;
            while (timer < 1)
                timer += Time.deltaTime;
            for (int i = 0; i < StatusModifiers.Count; i++)
            {
                if (StatusModifiers[i].isUpdated)
                {
                    if (CurrentValue < MaxValue)
                    {
                        if (StatusModifiers[i].isMultiplier)
                            CurrentValue *= StatusModifiers[i].ModifierValue;
                        else
                            CurrentValue += StatusModifiers[i].ModifierValue;
                    }
                    else
                        break;
                }
                yield return null;
            }
            yield return null;
        }
    }
}
