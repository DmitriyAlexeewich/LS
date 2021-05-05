using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class StaticStat : MonoBehaviour
{

    public EnumStatusType StatType { get { return _StatType; } }

    EnumStatusType _StatType;
    float CurrentValue;

    List<PercentageFactorModel> PercentageFactors = new List<PercentageFactorModel>();
    List<AddedModel> Addeds = new List<AddedModel>();

    public void Construct(float StartValue, EnumStatusType NewStatType)
    {
        CurrentValue = StartValue;
        _StatType = NewStatType;
    }

    public int AddPercentageFactor(float PercentageFactor)
    {
        var newPercentageFactorId = PercentageFactors.Count;
        PercentageFactors.Add(new PercentageFactorModel(newPercentageFactorId, PercentageFactor, CurrentValue));
        CurrentValue *= PercentageFactor;
        return newPercentageFactorId;
    }

    public int AddAdded(float Added)
    {
        var newPercentageFactorId = Addeds.Count;
        Addeds.Add(new AddedModel(newPercentageFactorId, Added, CurrentValue));
        CurrentValue += Added;
        return newPercentageFactorId;
    }

    public void RemovePercentageFactor(int Id)
    {
        var percentageFactor = PercentageFactors.FirstOrDefault(item => item.Id == Id);
        var enlargedPart = percentageFactor.OriginalValue * percentageFactor.PercentageFactor - percentageFactor.OriginalValue;
        CurrentValue -= enlargedPart;
        PercentageFactors.Remove(percentageFactor);
    }

    public void RemoveAdded(int Id)
    {
        var added = Addeds.FirstOrDefault(item => item.Id == Id);
        CurrentValue -= added.Added;
        Addeds.Remove(added);
    }
}
