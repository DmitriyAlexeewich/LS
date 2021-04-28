using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models;
using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    /*
    BulletCloneDataModel BulletCloneFlyEffect;
    Transform BulletTransform;

    System.Random Rand = new System.Random((int)DateTime.Now.Ticks);

    public void Construct(BulletCloneDataModel NewBulletCloneFlyEffect, Transform BulletTransformComponent)
    {
        BulletCloneFlyEffect = NewBulletCloneFlyEffect;
        BulletTransform = BulletTransformComponent;
    }

    public IEnumerator GetFlyEffectCoroutine()
    {
        return CloneUpdate();
    }

    IEnumerator CloneUpdate()
    {
        for (int i = 0; i < BulletCloneFlyEffect.CloneAtteptCount; i++)
        {
            var timer = 0f;
            while (timer < BulletCloneFlyEffect.TimeUpdate)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            for (int j = 0; j < BulletCloneFlyEffect.CloneCount; j++)
                SpawnClone();
            timer = 0f;
            yield return null;
        }
    }

    void SpawnClone()
    {
        var bulletTransform = Instantiate(BulletTransform);
        if (BulletCloneFlyEffect.isRangeFormCircle)
            bulletTransform.position = GetSpawnPointFromCircle(GetFloatRandom(0, 390));
        else
            bulletTransform.position = GetSpawnPointFromSquare();
        var bulletComponent = BulletTransform.gameObject.GetComponent<Bullet>();
        var bulletData = bulletComponent.GetCurrentBulletData();
        bulletData.Damage *= BulletCloneFlyEffect.DamageFactor;
        var magicType = bulletComponent.GetMagicType();
        if (BulletCloneFlyEffect.MagicType != EnumMagicType.Nothing)
            magicType = BulletCloneFlyEffect.MagicType;
        var bulletEffectsData = bulletComponent.GetCurrendBulletEffectsData();
        bulletEffectsData.BulletFlyEffect = null;

        bulletComponent = bulletTransform.GetComponent<Bullet>();
        bulletComponent.Construct(bulletData, bulletEffectsData, bulletTransform, magicType);
        Destroy(bulletTransform.gameObject.GetComponent<Clone>());
        bulletComponent.StartFlyBullet();
    }

    Vector3 GetSpawnPointFromCircle(float Angle)
    {

        var direction = new Vector3(Mathf.Cos(Angle), Mathf.Sin(Angle), 0);
        return BulletTransform.position + BulletTransform.TransformDirection(direction) * GetFloatRandom(0, BulletCloneFlyEffect.RangeX);
    }

    Vector3 GetSpawnPointFromSquare()
    {
        var direction = Vector3.right * GetFloatRandom(-BulletCloneFlyEffect.RangeX, BulletCloneFlyEffect.RangeX) + 
                        Vector3.up * GetFloatRandom(-BulletCloneFlyEffect.RangeY, BulletCloneFlyEffect.RangeY);
        return BulletTransform.position + BulletTransform.TransformDirection(direction);
    }

    float GetFloatRandom(float Minimum, float Maximum)
    {
        return (float)Rand.NextDouble() * (Maximum - Minimum) + Minimum;
    }*/
}
