using Assets.Scripts.Stats.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DynamicStat : MonoBehaviour
{
    float CurrentValue;
    float MaxValue;

    List<PercentageFactorModel> PercentageFactors = new List<PercentageFactorModel>();
    List<AddedModel> Addeds = new List<AddedModel>();

    IEnumerator ApplyChangesToCurrentValueCoroutine;

    public void Construct(float StartValue)
    {
        CurrentValue = StartValue;
    }

    public int AddPercentageFactor(float PercentageFactor)
    {
        var newPercentageFactorId = PercentageFactors.Count;
        PercentageFactors.Add(new PercentageFactorModel(newPercentageFactorId, PercentageFactor));
        StartApplyChangesToCurrentValueCoroutine();
        return newPercentageFactorId;
    }

    public int AddAdded(float Added)
    {
        var newPercentageFactorId = Addeds.Count;
        Addeds.Add(new AddedModel(newPercentageFactorId, Added));
        StartApplyChangesToCurrentValueCoroutine();
        return newPercentageFactorId;
    }

    public void RemovePercentageFactor(int Id)
    {
        PercentageFactors.RemoveAll(item => item.Id == Id);
        StopApplyChangesToCurrentValueCoroutine();
    }

    public void RemoveAdded(int Id)
    {
        Addeds.RemoveAll(item => item.Id == Id);
        StopApplyChangesToCurrentValueCoroutine();
    }

    public bool isMaxValueReached()
    {
        if (MaxValue < CurrentValue)
            return true;
        return false;
    }

    void StartApplyChangesToCurrentValueCoroutine()
    {
        if (ApplyChangesToCurrentValueCoroutine == null)
        {
            ApplyChangesToCurrentValueCoroutine = ApplyChangesToCurrentValue();
            StartCoroutine(ApplyChangesToCurrentValueCoroutine);
        }
    }

    void StopApplyChangesToCurrentValueCoroutine()
    {

        if ((PercentageFactors.Count < 1) && (Addeds.Count < 1))
        {
            StopCoroutine(ApplyChangesToCurrentValueCoroutine);
            ApplyChangesToCurrentValueCoroutine = null;
        }
    }

    IEnumerator ApplyChangesToCurrentValue()
    {
        while (true)
        {
            float timer = 0;
            while (timer < 1)
                timer += Time.deltaTime;
            for (int i = 0; i < PercentageFactors.Count; i++)
            {
                if (CurrentValue < MaxValue)
                    CurrentValue *= PercentageFactors[i].PercentageFactor;
                else
                    break;
            }
            for (int i = 0; i < Addeds.Count; i++)
            {
                if (CurrentValue < MaxValue)
                    CurrentValue += Addeds[i].Added;
                else
                    break;
            }
        }
    }
}
