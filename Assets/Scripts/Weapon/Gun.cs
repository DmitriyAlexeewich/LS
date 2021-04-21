using Assets.Scripts.Weapon.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    Transform GunTransformComponent;
    GunShootTrigger GunShootTriggerComponent;

    public void Construct(Transform GunTransform, Transform ScopeTransform, GunDataModel GunData)
    {
        GunShootTriggerComponent = this.gameObject.AddComponent<GunShootTrigger>();
        GunShootTriggerComponent.Construct(GunData.ShootTriggerData);

        var bulletSpawnPoints = GetComponentsInChildren<BulletSpawnPoint>();
        for (int i=0; i<bulletSpawnPoints.Length; i++)
        {
            GunShoot gunShootComponent = bulletSpawnPoints[i].gameObject.AddComponent<GunShoot>();
            gunShootComponent.Construct(ScopeTransform, bulletSpawnPoints[i].GetBulletSpawnPointTransform(), GunData.GunShootData, GunData.BulletData,
                                        GunShootTriggerComponent.GetStartShootEvent(), GunShootTriggerComponent.GetStopShootEvent());

        }

    }

}
