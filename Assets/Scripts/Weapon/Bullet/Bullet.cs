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


    IEnumerator FlyBulletCoroutine;

    public void Construct(BulletDataModel BulletData)
    {
        BulletType = BulletData.BulletType;
        Diameter = BulletData.Diameter;
        CheckHitPoints = BulletData.CheckHitPoints;
        CheckHitPointsDistance = BulletData.CheckHitPointsDistance;
        BulletEffects = BulletData.BulletEffects;
        MagicType = BulletData.MagicType;
        for (int i = 0; i < BulletData.StatusesData.Count; i++)
        {
            var status = this.gameObject.AddComponent<Status>();
            status.Construct(BulletData.StatusesData[i]);
        }
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
        isBulletRaycastHit(Start, BulletTransformComponent.position, ref hit);
        if (hit.collider != null)
        {
            
        }
        BulletHit(hit);
    }

    IEnumerator FlyBullet()
    {
        var hit = new RaycastHit();
        //AddFlyEffect();
        while ((LifeTime > 0) && (!isBulletPhysicsHit(ref hit)))
        {
            BulletTransformComponent.position += BulletTransformComponent.forward * Speed * Time.deltaTime;
            LifeTime -= Time.deltaTime;
            yield return null;
        }
        BulletHit(hit);
    }

    void BulletHit(RaycastHit Hit)
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