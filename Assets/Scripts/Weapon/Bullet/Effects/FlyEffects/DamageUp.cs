using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUp : MonoBehaviour
{
    BulletDamageDataModel BulletDamageUpFlyEffect;
    Bullet BulletComponent;


    public void Construct(BulletDamageDataModel NewBulletDamageUpFlyEffect, Bullet ParentBulletComponent)
    {
        BulletDamageUpFlyEffect = NewBulletDamageUpFlyEffect;
        BulletComponent = ParentBulletComponent;
    }

    public IEnumerator GetFlyEffectCoroutine()
    {
        return DamageUpUpdate();
    }

    IEnumerator DamageUpUpdate()
    {
        var timer = 0f;
        while (true)
        {
            while (timer < BulletDamageUpFlyEffect.Time)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            //BulletComponent.AddDamage(BulletDamageUpFlyEffect.DamageFactor);
            timer = 0f;
            yield return null;
        }
    }
}