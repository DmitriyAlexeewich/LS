using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Model;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(StatusCollection))]
public class Status : MonoBehaviour
{
    public EnumStatusType StatusType { get { return _StatusType; } }
    public float CurrentValue { get { return _CurrentValue; } }


    EnumStatusType _StatusType;
    float _CurrentValue;
    float MaxValue;
    HashSet<EnumMagicType> ApplicableMagicTypes;


    List<StatusModifierDataModel> StatusModifiers = new List<StatusModifierDataModel>();


    IEnumerator DynamicModifyStatusCoroutine;


    public void Construct(StatusDataModel StatusData)
    {
        _CurrentValue = StatusData.CurrentValue;
        _StatusType = StatusData.StatusType;
        MaxValue = StatusData.MaxValue;
        ApplicableMagicTypes = StatusData.ApplicableMagicTypes;
    }

    public int AddStatusModifier(EnumMagicType MagicType, float NewModifierValue, bool isMultiplierFlag = false, bool isUpdatedFlag = false)
    {
        var id = -1;
        if (ApplicableMagicTypes.Contains(MagicType))
        {
            id = 0;
            if (StatusModifiers.Count > 0)
                id = StatusModifiers[StatusModifiers.Count - 1].Id + 1;
            var statusModifier = new StatusModifierDataModel(id, NewModifierValue, isMultiplierFlag, isUpdatedFlag, CurrentValue);
            StatusModifiers.Add(statusModifier);
            if (isUpdatedFlag)
                StartDynamicModifyStatusCoroutine();
            else
                AddStaticModifyStatus(statusModifier);
        }
        return id;
    }

    public void RemoveStatusModifier(int Id)
    {
        var statusModifier = StatusModifiers.FirstOrDefault(item => item.Id == Id);
        if (statusModifier != null)
        {
            if (statusModifier.isUpdated)
                StopDynamicModifyStatusCoroutine(statusModifier);
            else
                SubtractStaticModifyStatus(statusModifier);
            StatusModifiers.Remove(statusModifier);
        }
    }

    public bool isReachedMaxValue()
    {
        return CurrentValue >= MaxValue;
    }

    void AddStaticModifyStatus(StatusModifierDataModel StatusModifierData)
    {
        if (StatusModifierData.isMultiplier)
            _CurrentValue *= StatusModifierData.ModifierValue;
        else
            _CurrentValue += StatusModifierData.ModifierValue;
    }

    void SubtractStaticModifyStatus(StatusModifierDataModel StatusModifierData)
    {
        if (StatusModifierData.isMultiplier)
            _CurrentValue -= StatusModifierData.ModifierValue * StatusModifierData.OriginalValue - StatusModifierData.OriginalValue;
        else
            _CurrentValue -= StatusModifierData.ModifierValue;
    }

    void StartDynamicModifyStatusCoroutine()
    {
        if (DynamicModifyStatusCoroutine == null)
        {
            DynamicModifyStatusCoroutine = DynamicModifyStatus();
            StartCoroutine(DynamicModifyStatusCoroutine);
        }
    }

    void StopDynamicModifyStatusCoroutine(StatusModifierDataModel StatusModifierData)
    {
        if (StatusModifiers.FirstOrDefault(item => item.isUpdated && item != StatusModifierData) == null)
        {
            StopCoroutine(DynamicModifyStatusCoroutine);
            DynamicModifyStatusCoroutine = null;
        }
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
                            _CurrentValue *= StatusModifiers[i].ModifierValue;
                        else
                            _CurrentValue += StatusModifiers[i].ModifierValue;
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
