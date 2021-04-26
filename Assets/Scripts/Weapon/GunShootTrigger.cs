using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Model;
using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootTrigger : MonoBehaviour
{
    public event Action StartShootEvent;
    public event Action StopShootEvent;


    EnumGunShootTriggerType GunShootTriggerType;
    float WaitingTime;


    float WaitingTimeStep = 0.001f;
    IEnumerator ShootCoroutine;

    public void Construct(GunShootTriggerDataModel GunShootTriggerData)
    {
        GunShootTriggerType = GunShootTriggerData.GunShootTriggerType;
        WaitingTime = GunShootTriggerData.WaitingTime;
    }

    public void StartShootCoroutine()
    {
        if (ShootCoroutine == null)
        {
            switch (GunShootTriggerType)
            {
                case EnumGunShootTriggerType.Click:
                    ShootCoroutine = ClickShoot(WaitingTime);
                    break;
                case EnumGunShootTriggerType.Press:
                    ShootCoroutine = ClickShoot(WaitingTime);
                    break;
                case EnumGunShootTriggerType.Hold:
                    ShootCoroutine = HoldShoot(WaitingTime);
                    break;
            }
            StartCoroutine(ShootCoroutine);
        }
    }

    public void StopShootCoroutine()
    {
        StopCoroutine(ShootCoroutine);
    }

    public Action GetStartShootEvent()
    {
        return StartShootEvent;
    }
    
    public Action GetStopShootEvent()
    {
        return StopShootEvent;
    }

    IEnumerator Shoot(float WaitingTime)
    {
        var timer = WaitingTime;
        if (GunShootTriggerType != EnumGunShootTriggerType.Hold)
            timer = 0;
        while (timer >= -WaitingTimeStep)
        {
            if (GunShootTriggerType == EnumGunShootTriggerType.Click)
            {
                StartShootEvent?.Invoke();
                break;
            }
            else if(timer <= 0)
            {
                StartShootEvent?.Invoke();
                timer = WaitingTime;
                if (GunShootTriggerType == EnumGunShootTriggerType.Hold)
                    break;
            }
            timer -= WaitingTimeStep;
            if (timer <= WaitingTime * 0.5f)
                StopShootEvent?.Invoke();
            yield return new WaitForSeconds(WaitingTimeStep);
        }
    }

    IEnumerator ClickShoot(float WaitingTime)
    {
        StartShootEvent?.Invoke();
        yield return new WaitForSeconds(WaitingTime);
        ShootCoroutine = null;
    }

    IEnumerator HoldShoot(float WaitingTime)
    {
        yield return new WaitForSeconds(WaitingTime);
        StartShootEvent?.Invoke();
        ShootCoroutine = null;
    }
}
