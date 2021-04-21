using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour
{
    float DamagePerMilliseconds;
    IEnumerator DebuffCoroutine;

    public void Construct(float NewDamagePerMilliseconds)
    {
        DamagePerMilliseconds = NewDamagePerMilliseconds;
    }

    public void StartDebuffCoroutine()
    {
        DebuffCoroutine = StartDebuff();
        StartCoroutine(DebuffCoroutine);
    }

    IEnumerator StartDebuff()
    {
        yield return null;
    }

    public void SetDamageValueByPercent(float Percent)
    {
        DamagePerMilliseconds = DamagePerMilliseconds * Percent;
    }
}
