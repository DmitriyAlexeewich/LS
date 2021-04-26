using Assets.Scripts.Weapon.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    GunShootTrigger GunShootTriggerComponent;

    public void Construct(Transform ScopeTransform, GunDataModel GunData)
    {
        GunShootTriggerComponent = this.gameObject.AddComponent<GunShootTrigger>();
        GunShootTriggerComponent.Construct(GunData.ShootTriggerData);
        
        GunShootTriggerVisualisation gunShootTriggerVisualisation = this.gameObject.AddComponent<GunShootTriggerVisualisation>();
        gunShootTriggerVisualisation.Construct(GunData.GunVisualisationData, GunShootTriggerComponent.GetStartShootEvent());

        var gunShootVisualisations = this.gameObject.GetComponentsInChildren<GunShootVisualisation>();
        for (int i = 0; i < gunShootVisualisations.Length; i++)
        {
            gunShootVisualisations[i].Construct(GunData.GunVisualisationData, GunShootTriggerComponent.GetStartShootEvent(), GunShootTriggerComponent.GetStopShootEvent());
            GunShoot gunShootComponent = gunShootVisualisations[i].gameObject.AddComponent<GunShoot>();
            gunShootComponent.Construct(ScopeTransform, gunShootVisualisations[i].GetBulletSpawnPointTransform(), GunData.GunShootData, GunData.BulletData,
                                        GunShootTriggerComponent.GetStartShootEvent());
        }        
    }

    public void DestroyComponent()
    {
        var gunShootVisualisations = this.gameObject.GetComponentsInChildren<GunShootVisualisation>();
        for (int i = 0; i < gunShootVisualisations.Length; i++)
        {
            gunShootVisualisations[i].DestroyComponent();
            GunShoot gunShootComponent = gunShootVisualisations[i].gameObject.GetComponent<GunShoot>();
            gunShootComponent.DestroyComponent();
        }

        GunShootTriggerVisualisation gunShootTriggerVisualisation = this.gameObject.GetComponent<GunShootTriggerVisualisation>();
        gunShootTriggerVisualisation.DestroyComponent();

        Destroy(this);
    }

    public void StartShoot()
    {
        GunShootTriggerComponent.StartShootCoroutine();
    }

    public void StopShoot()
    {
        GunShootTriggerComponent.StopShootCoroutine();
    }
}
