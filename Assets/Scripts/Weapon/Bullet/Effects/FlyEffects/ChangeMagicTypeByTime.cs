using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMagicTypeByTime : MonoBehaviour
{
    BulletChangeMagicTypeByTimeDataModel BulletChangeMagicTypeByTimeFlyEffect;
    Bullet BulletComponent;

    public void Construct(BulletChangeMagicTypeByTimeDataModel NewBulletChangeMagicTypeByTimeFlyEffect, Bullet NewBulletComponent)
    {
        BulletChangeMagicTypeByTimeFlyEffect = NewBulletChangeMagicTypeByTimeFlyEffect;
        BulletComponent = NewBulletComponent;
    }

    public IEnumerator GetFlyEffectCoroutine()
    {
        Debug.Break();
        return ChangeMagicTypeByTimeUpdate();
    }

    IEnumerator ChangeMagicTypeByTimeUpdate()
    {
        yield return null;
        for (int i = 0; i <= BulletChangeMagicTypeByTimeFlyEffect.MagicTypes.Count; i ++)
        {
            var changeTimer = 0f;
            while (changeTimer <= BulletChangeMagicTypeByTimeFlyEffect.ChangeTime)
            {
                changeTimer += Time.deltaTime;
                yield return null;
            }
            BulletComponent.SetMagicType(BulletChangeMagicTypeByTimeFlyEffect.MagicTypes[i]);
            yield return null;
        }
    }
}
