using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObject : MonoBehaviour
{
    float LifeTime;

    IEnumerator TimerCoroutine;

    public void Construct(float NewLifeTime)
    {
        LifeTime = NewLifeTime;
    }

    public void StartTimerCoroutine()
    {
        TimerCoroutine = Timer();
        StartCoroutine(TimerCoroutine);
    }

    IEnumerator Timer()
    {
        while (LifeTime > 0)
        {
            LifeTime -= Time.deltaTime;
            yield return null;
        }
        DestroyObject();
    }

    void DestroyObject()
    {
        StopCoroutine(TimerCoroutine);
        Destroy(this.gameObject);
    }
}
