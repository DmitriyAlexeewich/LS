using Assets.Scripts.Effects.Model;
using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Weapon.Bullet.Enumerators;
using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform BulletTransformComponent;


    EnumBulletType BulletType;
    StatusCollection StatusCollectionComponent;
    float Diameter;
    List<Vector3> CheckHitPoints;
    float CheckHitPointsDistance;
    List<BulletEffectsDataModel> BulletEffects;
    EnumMagicType MagicType;
    bool isPhysics;

    IEnumerator FlyBulletCoroutine;

    public void Construct(BulletDataModel BulletData)
    {
        BulletType = BulletData.BulletType;
        Diameter = BulletData.Diameter;
        CheckHitPoints = BulletData.CheckHitPoints;
        CheckHitPointsDistance = BulletData.CheckHitPointsDistance;
        BulletEffects = BulletData.BulletEffects;
        MagicType = BulletData.MagicType;
        StatusCollectionComponent = this.gameObject.AddComponent<StatusCollection>();
        StatusCollectionComponent.Construct(BulletData.StatusesData);
        isPhysics = BulletData.isPhysics;
    }

    public void StartBullet(Vector3 StartPosition, Vector3 DestinationPoint, Transform BulletTransform)
    {
        BulletTransformComponent = BulletTransform;
        switch (BulletType)
        {
            case EnumBulletType.Plasma:
                StatusCollectionComponent.AddStatusModifier(EnumStatusType.Damage, 1.05f, true, true);
                StatusCollectionComponent.AddStatusModifier(EnumStatusType.Speed, 0.95f, true, true);
                break;
            case EnumBulletType.Rocket:
                StatusCollectionComponent.AddStatusModifier(EnumStatusType.LifeTime, 0.95f, true, true);
                StatusCollectionComponent.AddStatusModifier(EnumStatusType.Speed, 1.05f, true, true);
                break;
            default:
                break;
        }
        if (isPhysics)
        {
            BulletTransformComponent.LookAt(DestinationPoint);
            StartFlyBullet();
        }
        else
        {
            BulletTransformComponent.position = DestinationPoint;
            RaycastBullet(StartPosition);
        }
    }

    void StartFlyBullet()
    {
        FlyBulletCoroutine = FlyBullet();
        StartCoroutine(FlyBulletCoroutine);
    }

    void RaycastBullet(Vector3 Start)
    {
        var hit = new RaycastHit();
        isBulletRaycastHit(Start, BulletTransformComponent.position, ref hit);
        BulletHit(hit);
    }

    IEnumerator FlyBullet()
    {
        var lifeTimeStatusComponent = StatusCollectionComponent.GetStatus(EnumStatusType.LifeTime);
        var speedStatusComponent = StatusCollectionComponent.GetStatus(EnumStatusType.Speed);
        if ((lifeTimeStatusComponent != null) && ((speedStatusComponent != null)))
        {
            lifeTimeStatusComponent.AddStatusModifier(1, false, true);
            var hit = new RaycastHit();
            while ((!lifeTimeStatusComponent.isReachedMaxValue()) && (!isBulletPhysicsHit(ref hit)))
            {
                BulletTransformComponent.position += BulletTransformComponent.forward * speedStatusComponent.CurrentValue * Time.deltaTime;
                yield return null;
            }
            BulletHit(hit);
        }
    }

    void BulletHit(RaycastHit Hit)
    {
        if (Hit.collider != null)
        {
            var hitTransform = Hit.transform;
            var enemyComponent = hitTransform.gameObject.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                var damageStatus = StatusCollectionComponent.GetStatus(EnumStatusType.Damage);
                if (damageStatus != null)
                    enemyComponent.AddDamage(MagicType, damageStatus.CurrentValue);
                if (BulletType == EnumBulletType.Arrow)
                {
                    var effect = hitTransform.gameObject.AddComponent<Effect>();
                    effect.Construct(new EffectDataModel(MagicType, EnumStatusType.Damage, 1.01f, 10f, true, true));
                    effect.StartEffectCoroutine();
                }
            }
            else
                Debug.Log(1);
        }
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if(FlyBulletCoroutine != null)
            StopCoroutine(FlyBulletCoroutine);
        Destroy(this.gameObject);
    }

    bool isBulletPhysicsHit(ref RaycastHit Hit)
    {
        for (int i = 0; i < CheckHitPoints.Count; i++ )
        {
            var secondPosition = (BulletTransformComponent.TransformDirection(CheckHitPoints[i]) * CheckHitPointsDistance) + BulletTransformComponent.position;
            if (isBulletRaycastHit(BulletTransformComponent.position, secondPosition, ref Hit))
                return true;
        }
        return false;
    }

    bool isBulletRaycastHit(Vector3 Start, Vector3 End, ref RaycastHit Hit)
    {
        if (Physics.Linecast(Start, End, out Hit))
            return true;
        return false;
    }
}