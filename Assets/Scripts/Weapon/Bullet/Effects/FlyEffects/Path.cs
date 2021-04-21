using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    float DamageFactor;
    float LifeTime;
    float TimeUpdate;
    Vector3 Scale;
    EnumMagicType MagicType;
    bool isGrounded;

    Transform PathTransform;
    Vector3 LastPosition;

    public void Construct(BulletPathtDataModel NewBulletPathFlyEffectData, Transform BulletTransform, bool isGroundedValue)
    {
        DamageFactor = NewBulletPathFlyEffectData.DamageFactor;
        LifeTime = NewBulletPathFlyEffectData.LifeTime;
        Scale = NewBulletPathFlyEffectData.Scale;
        MagicType = NewBulletPathFlyEffectData.MagicType;
        PathTransform = BulletTransform;
        LastPosition = PathTransform.position;
        isGrounded = isGroundedValue;
    }

    public IEnumerator GetFlyEffectCoroutine()
    {
        return PathCoroutine();
    }

    IEnumerator PathCoroutine()
    {
        var timer = 0f;
        while (true)
        {
            while (timer < TimeUpdate)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            if (isGrounded)
                PathGround();
            else
                PathFly();
            yield return null;
        }
    }

    void PathGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(PathTransform.position, Vector3.down, out hit))
        {
            var bufferDistance = GetGroundDistance(hit.point, LastPosition);
            if (bufferDistance > Scale.z)
            {
                var pathBlockTransform = CreatePathBlock(false);
                pathBlockTransform.position = hit.point - (hit.point - LastPosition) * ((bufferDistance - Scale.z) / 2);
                pathBlockTransform.position = new Vector3(pathBlockTransform.position.x, hit.point.y, pathBlockTransform.position.z);
                LastPosition = pathBlockTransform.position;
                pathBlockTransform.rotation = Quaternion.Euler(0, PathTransform.rotation.eulerAngles.y, 0);
                pathBlockTransform.localScale = Scale;
            }
        }
        else
            LastPosition = new Vector3(PathTransform.position.x, LastPosition.y, PathTransform.position.z);
    }

    void PathFly()
    {
        var bufferDistance = Vector3.Distance(PathTransform.position, LastPosition);
        if (bufferDistance > Scale.z * 2)
        {
            var pathBlockTransform = CreatePathBlock(false);
            pathBlockTransform.position = PathTransform.position - (PathTransform.position - LastPosition) * (bufferDistance - Scale.z * 2);
            pathBlockTransform.rotation = Quaternion.Euler(PathTransform.rotation.eulerAngles.x + 90, PathTransform.rotation.eulerAngles.y, PathTransform.rotation.eulerAngles.z);
            pathBlockTransform.localScale = Scale;
            LastPosition = pathBlockTransform.position;
        }
    }
    
    float GetGroundDistance(Vector3 A, Vector3 B)
    {
        return Mathf.Pow(A.x - B.x, 2) + Mathf.Pow(A.z - B.z, 2);
    }

    Transform CreatePathBlock(bool isCylinder)
    {
        Transform pathBlockTransform;
        if (isCylinder)
        {
            pathBlockTransform = GameObject.CreatePrimitive(PrimitiveType.Cylinder).GetComponent<Transform>();
            Destroy(pathBlockTransform.gameObject.GetComponent<CapsuleCollider>());
            var collider = pathBlockTransform.gameObject.AddComponent<MeshCollider>();
            collider.convex = true;
        }
        else
            pathBlockTransform = GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<Transform>();
        pathBlockTransform.gameObject.layer = 2;
        var timeObjectComponent = pathBlockTransform.gameObject.AddComponent<TimeObject>();
        timeObjectComponent.Construct(LifeTime);
        timeObjectComponent.StartTimerCoroutine();
        return pathBlockTransform;
    }
}
