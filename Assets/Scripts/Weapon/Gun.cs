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

        var gunBarrels = this.gameObject.GetComponentsInChildren<GunBarrel>();
        for (int i = 0; i < gunBarrels.Length; i++)
        {
            gunBarrels[i].Construct(GunData.GunVisualisationData, GunShootTriggerComponent.GetStartShootEvent(), GunShootTriggerComponent.GetStopShootEvent());
            GunShoot gunShootComponent = gunBarrels[i].GetBulletSpawnPointTransform().gameObject.AddComponent<GunShoot>();
            gunShootComponent.Construct(ScopeTransform, gunBarrels[i].GetBulletSpawnPointTransform(), GunData.GunShootData, GunData.BulletData,
                                        GunShootTriggerComponent.GetStartShootEvent(), GunShootTriggerComponent.GetStopShootEvent());
        }

    }

}
