using Assets.Scripts.Effects.Model;
using Assets.Scripts.Stats.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Effect : MonoBehaviour
{

    EnumStatusType StatusType;
    int ModifierId = -1;
    IEnumerator EffectLifeCoroutine = null;


    StatusCollection StatusCollection = null;


    public void Construct(EffectDataModel EffectData)
    {
        StatusType = EffectData.TargetStatusType;
        StatusCollection = this.GetComponent<StatusCollection>();
        if (StatusCollection != null)
        {
            ModifierId = StatusCollection.AddStatusModifier(EffectData.TargetStatusType, EffectData.MagicType, EffectData.EffectValue, EffectData.isMultiplier, EffectData.isUpdated);
            if (ModifierId == -1)
                Destroy(this);
            else
            {
                if (EffectData.LifeTime > 0)
                    StartEffectLifeCoroutine(EffectData.LifeTime);
            }
        }
    }

    public void DestroyComponent()
    {
        RemoveEffectStatusModifier();
        StopEffectLifeCoroutine();
        Destroy(this);
    }

    void StartEffectLifeCoroutine(float LifeTime)
    {
        EffectLifeCoroutine = EffectLife(LifeTime);
        StartCoroutine(EffectLifeCoroutine);
    }

    IEnumerator EffectLife(float LifeTime)
    {
        yield return new WaitForSeconds(LifeTime);
        DestroyComponent();
    }

    void StopEffectLifeCoroutine()
    {
        if (EffectLifeCoroutine != null)
            StopCoroutine(EffectLifeCoroutine);
        EffectLifeCoroutine = null;
    }

    void RemoveEffectStatusModifier()
    {
        if ((StatusCollection != null) && (ModifierId != -1))
            StatusCollection.RemoveStatusModifier(StatusType, ModifierId);
    }
}
