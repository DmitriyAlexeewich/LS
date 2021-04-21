using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    BulletDangerZoneDataModel BulletDangerZoneFlyEffect;
    Transform BulletTransform;
    EnumMagicType MagicType;

    public void Construct(BulletDangerZoneDataModel NewBulletDangerZoneFlyEffect, Transform BulletTransformComponent, EnumMagicType BulletMagicType)
    {
        BulletDangerZoneFlyEffect = NewBulletDangerZoneFlyEffect;
        BulletTransform = BulletTransformComponent;
        MagicType = NewBulletDangerZoneFlyEffect.MagicType;
        if (MagicType == EnumMagicType.Nothing)
            MagicType = BulletMagicType;
    }

    public IEnumerator GetFlyEffectCoroutine()
    {
        return DangerZoneUpdate();
    }

    IEnumerator DangerZoneUpdate()
    {
        var dangerZoneSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).GetComponent<Transform>();
        dangerZoneSphere.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        dangerZoneSphere.gameObject.GetComponent<Collider>().isTrigger = true;
        dangerZoneSphere.parent = BulletTransform;
        dangerZoneSphere.localPosition = new Vector3(0f, 0f, 0f);
        dangerZoneSphere.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        yield return null;
        while (dangerZoneSphere.localScale.x <= BulletDangerZoneFlyEffect.EndDiameter)
        {
            dangerZoneSphere.localScale = Vector3.Lerp(dangerZoneSphere.localScale, new Vector3(1, 1, 1) * BulletDangerZoneFlyEffect.EndDiameter, Time.deltaTime);
            yield return null;
        }
    }
}
