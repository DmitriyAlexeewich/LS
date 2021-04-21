using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GunVisualisation : MonoBehaviour
{
    [SerializeField]
    Transform BulletSpawnPointTransformComponent;
    [SerializeField]
    Animator GunAnimatorController;
    [SerializeField]
    List<MeshRenderer> ChildObjectMeshRenders;
    [SerializeField]
    Light ShootLight;
    [SerializeField]
    VisualEffect MuzzleFlashEffect;


    Transform GunTransformComponent;
    Vector3 StartPosition;
    float MaxInertiaAmount = 0.04f;
    float ShootSpeedMultiplier = 1f;
    float Weight;

}
