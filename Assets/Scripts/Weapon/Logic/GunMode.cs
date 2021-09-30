using Assets.Scripts.Weapon.Logic.Model;
using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GunMode : TimeWaiter
{
    [SerializeField]
    private EnumGunModeType _gunModeType;
    [SerializeField]
    private EnumGunShootTriggerType _gunShootTriggerType;
    [Space(20)]
    [SerializeField]
    private List<GunShootProfile> _gunShootProfiles = new List<GunShootProfile>();

    public void Construct(Transform characterTransform)
    {
        for (int i = 0; i < _gunShootProfiles.Count; i++)
            _gunShootProfiles[i].Constructor(characterTransform);

        SetIsQueue(true);

        for (int i = 0; i < _gunShootProfiles.Count; i++)
        {
            switch (_gunShootTriggerType)
            {
                case EnumGunShootTriggerType.OnStart:
                    TimerStarted += _gunShootProfiles[i].Start;
                    break;
                case EnumGunShootTriggerType.OnEnd:
                    TimerEnded += _gunShootProfiles[i].Start;
                    break;
                default:
                    break;
            }
        }
    }

    public new void Destroy()
    {
        for (int i = 0; i < _gunShootProfiles.Count; i++)
            _gunShootProfiles[i].Destroy();
        base.Destroy();
    }

    public void StartShootLoad(StartShootEventArgs startShootEventArgs)
    {
        if (_gunModeType == startShootEventArgs.GunModeType)
        {
            if (_gunShootTriggerType == EnumGunShootTriggerType.OnEnd)
                SetIsCanceled(!startShootEventArgs.isRealize);
            if (startShootEventArgs.isRealize)
                Start();
        }
    }

    /*
     * 3 - визуал
    */

    /*
    private GunShootTrigger gunShootTriggerComponent;

    public void Construct(Transform scopeTransform, GunDataModel gunData)
    {
        gunShootTriggerComponent = this.gameObject.AddComponent<GunShootTrigger>();
        gunShootTriggerComponent.Construct(gunData.ShootTriggerData);

        var gunShootVisualisations = this.gameObject.GetComponentsInChildren<GunShootVisualisation>();
        for (int i = 0; i < gunShootVisualisations.Length; i++)
        {
            GunShoot gunShootComponent = gunShootVisualisations[i].gameObject.AddComponent<GunShoot>();
            gunShootComponent.Construct(scopeTransform, gunData.GunShootData, gunData.BulletData, gunShootTriggerComponent.StartShootEvent, gunShootVisualisations[i]);
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

        gunShootTriggerComponent.DestroyComponent();

        Destroy(this);
    }

    public void StartShoot()
    {
        gunShootTriggerComponent.StartShoot();
    }*/
}
