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
    float ShootLoadTime;


    //float WaitingTimeStep = 0.001f;
    IEnumerator ShootCoroutine;

    public void Construct(GunShootTriggerDataModel GunShootTriggerData)
    {
        GunShootTriggerType = GunShootTriggerData.GunShootTriggerType;
        ShootLoadTime = GunShootTriggerData.ShootLoadTime;
    }

    public void StartShootCoroutine()
    {
        if (ShootCoroutine == null)
        {
            switch (GunShootTriggerType)
            {
                case EnumGunShootTriggerType.Press:
                    ShootCoroutine = ClickShoot(ShootLoadTime);
                    break;
                case EnumGunShootTriggerType.Hold:
                    ShootCoroutine = HoldShoot(ShootLoadTime);
                    break;
            }
            StartCoroutine(ShootCoroutine);
        }
    }

    public void StopShootCoroutine()
    {
        if (GunShootTriggerType == EnumGunShootTriggerType.Hold)
        {
            StopCoroutine(ShootCoroutine);
            ShootCoroutine = null;
            StopShootEvent?.Invoke();
        }
    }

    public void DestroyComponent()
    {
        StopShootCoroutine();
        Destroy(this);
    }
    
    /*
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
                    StopShootEvent();
                yield return new WaitForSeconds(WaitingTimeStep);
            }
        }
    */
    
    IEnumerator ClickShoot(float DeltaShootLoadTime)
    {
        yield return null;
        StartShootEvent?.Invoke();
        while (DeltaShootLoadTime > 0)
        {
            DeltaShootLoadTime -= Time.deltaTime;
            yield return null;
        }
        StopShootEvent?.Invoke();
        ShootCoroutine = null;
    }

    IEnumerator HoldShoot(float DeltaShootLoadTime)
    {
        yield return null;
        StopShootEvent?.Invoke();
        while (DeltaShootLoadTime > 0)
        {
            DeltaShootLoadTime -= Time.deltaTime;
            yield return null;
        }
        StartShootEvent?.Invoke();
        ShootCoroutine = null;
    }

}
