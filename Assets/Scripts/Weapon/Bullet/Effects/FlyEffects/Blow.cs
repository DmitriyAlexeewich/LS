using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{

    BulletBlowDataModel BulletBlowFlyEffect;
    Transform BulletTransform;
    EnumMagicType MagicType;

    public void Construct(BulletBlowDataModel NewBulletBlowFlyEffect, Transform BulletTransformComponent, EnumMagicType BulletMagicType)
    {
        BulletBlowFlyEffect = NewBulletBlowFlyEffect;
        BulletTransform = BulletTransformComponent;
        MagicType = NewBulletBlowFlyEffect.MagicType;
        if (MagicType == EnumMagicType.Nothing)
            MagicType = BulletMagicType;
    }

    public IEnumerator GetFlyEffectCoroutine()
    {
        return BlowUpdate();
    }

    IEnumerator BlowUpdate()
    {
        yield return null;
        var timer = 0f;
        while (timer < BulletBlowFlyEffect.LifeTime)
        {
            var blowTimer = 0f;
            while (blowTimer <= BulletBlowFlyEffect.BlowTime)
            {
                blowTimer += Time.deltaTime;
                yield return null;
            }
            var blowSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).GetComponent<Transform>();
            blowSphere.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            blowSphere.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            blowSphere.gameObject.GetComponent<Collider>().isTrigger = true;
            blowSphere.position = BulletTransform.position;
            timer += BulletBlowFlyEffect.BlowTime;
            yield return null;
        }
    }
}
