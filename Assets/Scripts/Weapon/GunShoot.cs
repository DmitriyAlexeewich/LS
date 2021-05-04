﻿using Assets.Scripts.Weapon.Bullet.Enumerators;
using Assets.Scripts.Weapon.Bullet.Models;
using Assets.Scripts.Weapon.Model;
using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    Transform ScopeTransformComponent;
    Transform BulletSpawnPointTransformComponent;

    Transform BulletExample;

    float Distance;
    float BulletsCountPerOneShoot;
    bool getRangeFormCircle;
    float RangeX;
    float RangeY;
    EnumGunShootType GunShootType;
    BulletDataModel BulletData;

    IEnumerator ShootCoroutine;
    System.Random Rand = new System.Random((int)DateTime.Now.Ticks);

    public void Construct(Transform ScopeTransform, Transform BulletSpawnPointTransform, GunShootDataModel GunShootData, BulletDataModel NewBulletData, GunShootTrigger GunShootTriggerComponent)
    {
        ScopeTransformComponent = ScopeTransform;
        BulletSpawnPointTransformComponent = BulletSpawnPointTransform;

        Distance = GunShootData.Distance;
        BulletsCountPerOneShoot = GunShootData.BulletsCountPerOneShoot;
        getRangeFormCircle = GunShootData.getRangeFormCircle;
        RangeX = GunShootData.RangeX;
        RangeY = GunShootData.RangeY;
        GunShootType = GunShootData.GunShootType;
        BulletData = NewBulletData;

        GunShootTriggerComponent.StartShootEvent += StartShoot;

        if (BulletExample != null)
            Destroy(BulletExample.gameObject);
        BulletExample = SpawnBulletExample();
    }

    public void DestroyComponent(GunShootTrigger GunShootTriggerComponent)
    {
        GunShootTriggerComponent.StartShootEvent -= StartShoot;
        Destroy(BulletExample.gameObject);
        Destroy(this);
    }

    void StartShoot()
    {
        ShootCoroutine = Shoot();
        StartCoroutine(ShootCoroutine);
    }

    IEnumerator Shoot()
    {
        yield return null;
        var bulletDestination = GetBulletDestination();
        for (int i = 0; i < BulletsCountPerOneShoot; i++)
        {
            var destinationPoint = GetDestinationPointWithRange(bulletDestination);
            var bulletTransform = SpawnBullet(BulletExample);
            bulletTransform.gameObject.SetActive(true);
            if (bulletTransform != null)
            {
                Bullet bulletComponent = bulletTransform.gameObject.AddComponent<Bullet>();
                bulletComponent.Construct(BulletData);
                bulletComponent.StartBullet(GunShootType, ScopeTransformComponent.position, destinationPoint, bulletTransform);
            }
            yield return null;
        }
    }

    Vector3 GetBulletDestination()
    {
        var result = new Vector3();
        result = ScopeTransformComponent.position + ScopeTransformComponent.forward * Distance;
        return result;
    }

    Vector3 GetDestinationPointWithRange(Vector3 BulletDestinationPoint)
    {
        var result = BulletDestinationPoint;
        if ((RangeX > 0) && (RangeY > 0))
        {
            if (getRangeFormCircle)
                result = GetDestinationRangePointFromCircle(GetFloatRandom(0, 6.283185f), BulletDestinationPoint);
            else
                result = GetDestinationRangePointFromSquare(BulletDestinationPoint);
        }
        return result;
    }

    Vector3 GetDestinationRangePointFromCircle(float Angle, Vector3 BulletDestinationPoint)
    {

        var direction = new Vector3(Mathf.Cos(Angle), Mathf.Sin(Angle), 0);
        return BulletDestinationPoint + ScopeTransformComponent.TransformDirection(direction) * GetFloatRandom(0, RangeX);
    }

    Vector3 GetDestinationRangePointFromSquare(Vector3 BulletDestinationPoint)
    {
        var direction = Vector3.right * GetFloatRandom(-RangeX, RangeX) + Vector3.up * GetFloatRandom(-RangeY, RangeY);
        return BulletDestinationPoint + ScopeTransformComponent.TransformDirection(direction);
    }

    float GetFloatRandom(float Minimum, float Maximum)
    {
        return (float)Rand.NextDouble() * (Maximum - Minimum) + Minimum;
    }

    Transform SpawnBulletExample()
    {
        Transform bulletTransform = GameObject.CreatePrimitive(PrimitiveType.Sphere).GetComponent<Transform>();
        bulletTransform.position = this.gameObject.GetComponent<Transform>().position;
        bulletTransform.localScale = new Vector3(BulletData.Diameter, BulletData.Diameter, BulletData.Diameter);
        bulletTransform.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        bulletTransform.gameObject.GetComponent<Collider>().isTrigger = true;
        bulletTransform.gameObject.SetActive(false);
        return bulletTransform;
    }

    Transform SpawnBullet(Transform BulletGameOject)
    {
        return Instantiate(BulletGameOject, BulletSpawnPointTransformComponent.position, Quaternion.Euler(Vector3.zero)).GetComponent<Transform>();    
    }

}
