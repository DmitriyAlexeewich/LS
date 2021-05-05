using Assets.Scripts.Stats.Model;
using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class StaticStat : MonoBehaviour
{
    float CurrentValue;

    List<PercentageFactorModel> PercentageFactors = new List<PercentageFactorModel>();
    List<AddedModel> Addeds = new List<AddedModel>();

    public void Construct(float StartValue)
    {
        CurrentValue = StartValue;
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
        PercentageFactors.RemoveAll(item => item.Id == Id);
    }

    public void RemoveAdded(int Id)
    {
        Addeds.RemoveAll(item => item.Id == Id);
    }
}
