using Assets.Scripts.Weapon.Bullet.Effects.EnemyHitEffects.Models;
using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Enumerators;
using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models;
using Assets.Scripts.Weapon.Bullet.Effects.Models;
using Assets.Scripts.Weapon.Bullet.Enumerators;
using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform BulletTransformComponent;


    EnumBulletType BulletType;
    float LifeTime;
    float Damage;
    float Speed;
    float Diameter;
    List<Vector3> CheckHitPoints;
    float CheckHitPointsDistance;
    List<BulletEffectsDataModel> BulletEffects;
    EnumMagicType MagicType;


    IEnumerator FlyBulletCoroutine = null;
    IEnumerator BulletHitCoroutine = null;
    IEnumerator FlyEffectCoroutine = null;

    public void Construct(BulletDataModel BulletData)
    {
        BulletType = BulletData.BulletType;
        LifeTime = BulletData.LifeTime;
        Damage = BulletData.Damage;
        Speed = BulletData.Speed;
        Diameter = BulletData.Diameter;
        CheckHitPoints = BulletData.CheckHitPoints;
        CheckHitPointsDistance = BulletData.CheckHitPointsDistance;
        BulletEffects = BulletData.BulletEffects;
        MagicType = BulletData.MagicType;

        FlyBulletCoroutine = null;
        BulletHitCoroutine = null;
        FlyEffectCoroutine = null;
    }

    public void StartBullet(EnumGunShootType GunShootType, Vector3 StartPosition, Vector3 DestinationPoint, Transform BulletTransform)
    {
        BulletTransformComponent = BulletTransform;
        switch (GunShootType)
        {
            case EnumGunShootType.Physics:
                BulletTransformComponent.LookAt(DestinationPoint);
                StartFlyBullet();
                break;
            case EnumGunShootType.Ray:
                BulletTransformComponent.position = DestinationPoint;
                RaycastBullet(StartPosition);
                break;
            default:
                DestroyBullet();
                break;
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
        var isBulletRaycastHited = isBulletRaycastHit(Start, BulletTransformComponent.position, ref hit);
        StartCoroutine(BulletHit(hit));
    }

    IEnumerator FlyBullet()
    {
        var hit = new RaycastHit();
        //AddFlyEffect();
        while ((LifeTime > 0) && (!isBulletPhysicsHit(ref hit)))
        {
            MoveBullet();
            LifeTime -= Time.deltaTime;
            yield return null;
        }
        BulletHitCoroutine = BulletHit(hit);
        StartCoroutine(BulletHitCoroutine);
    }

    IEnumerator BulletHit(RaycastHit Hit)
    {
        if (Hit.collider != null)
        {
            var hitTransform = Hit.transform;
            if (hitTransform.gameObject.tag == "Enemy")
            {
                hitTransform.gameObject.GetComponent<EnemyStats>().MinusStats(Damage);
                //AddEnemyHitEffectToEnemy(hitTransform);
            }
            else
                Debug.Log(1);
                //SpawnNonEnemyHitEffect(hitTransform);
        }
        yield return null;
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if(FlyBulletCoroutine != null)
            StopCoroutine(FlyBulletCoroutine);
        if (BulletHitCoroutine != null)
            StopCoroutine(BulletHitCoroutine);
        if (FlyEffectCoroutine != null)
            StopCoroutine(FlyEffectCoroutine);
        Destroy(this.gameObject);
    }

    void MoveBullet()
    {
        BulletTransformComponent.position += BulletTransformComponent.forward * Speed * Time.deltaTime;
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
    /*
    void CreateRaycastFlyEffect(RaycastHit Hit, bool isBulletRaycastHited)
    {
        if (isBulletRaycastHited)
        {
            switch (BulletEffectsData.BulletFlyEffect.EffectType)
            {
                case EnumFlyEffectType.BlowByDistancePercent:
                    break;
                case EnumFlyEffectType.Ricochet:
                    break;
                case EnumFlyEffectType.Clone:
                    break;
                case EnumFlyEffectType.IgnoreWall:
                    break;
                case EnumFlyEffectType.ReverseLink:
                    break;
                case EnumFlyEffectType.Dublicate:
                    break;
                default:
                    break;
            }
        }
    }
    */
    void AddFlyEffect(FlyEffectDataModel FlyEffectData)
    {
        switch (FlyEffectData.EffectType)
        {
            case EnumFlyEffectType.GroundPath:
                var groundPathEffectComponent = this.gameObject.AddComponent<Path>();
                groundPathEffectComponent.Construct(FlyEffectData.BulletPathFlyEffect, BulletTransformComponent, true);
                FlyEffectCoroutine = groundPathEffectComponent.GetFlyEffectCoroutine();
                break;
            case EnumFlyEffectType.DamageUp:
                var damageUpEffectComponent = this.gameObject.AddComponent<DamageUp>();
                damageUpEffectComponent.Construct(FlyEffectData.BulletDamageUpFlyEffect, this);
                FlyEffectCoroutine = damageUpEffectComponent.GetFlyEffectCoroutine();
                break;
            case EnumFlyEffectType.DangerZone:
                var dangerZoneEffectComponent = this.gameObject.AddComponent<DangerZone>();
                dangerZoneEffectComponent.Construct(FlyEffectData.BulletDangerZoneFlyEffect, BulletTransformComponent, MagicType);
                FlyEffectCoroutine = dangerZoneEffectComponent.GetFlyEffectCoroutine();
                break;
            case EnumFlyEffectType.FlyPath:
                var flyPathEffectComponent = this.gameObject.AddComponent<Path>();
                flyPathEffectComponent.Construct(FlyEffectData.BulletPathFlyEffect, BulletTransformComponent, false);
                FlyEffectCoroutine = flyPathEffectComponent.GetFlyEffectCoroutine();
                break;
            case EnumFlyEffectType.MineByTime:

                break;
            case EnumFlyEffectType.Link:

                break;
            default:
                break;
        }
        StartCoroutine(FlyEffectCoroutine);
    }
}
