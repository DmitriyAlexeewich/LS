using Assets.Scripts.Weapon.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(GunMeshRenderer))]

public class GunShootTriggerVisualisation : MonoBehaviour
{

    private Animator _animatorComponent;

    public void Construct(GunShootTriggerVisualisationDataModel gunShootTriggerVisualisationData, UnityEvent startShootEvent)
    {

        List<GunMeshRenderer> gunMeshesRenderers = new List<GunMeshRenderer>();
        gunMeshesRenderers.AddRange(this.gameObject.GetComponentsInChildren<GunMeshRenderer>());
        var parentMeshRender = this.gameObject.GetComponent<GunMeshRenderer>();
        if (parentMeshRender != null)
            gunMeshesRenderers.Add(parentMeshRender);
        for (int i = 0; i < gunMeshesRenderers.Count; i++)
            gunMeshesRenderers[i].Construct(gunShootTriggerVisualisationData.MainGlowColor, gunShootTriggerVisualisationData.GlowSecondaryColor);

        _animatorComponent = this.gameObject.GetComponent<Animator>();
        if (_animatorComponent != null)
            startShootEvent.AddListener(PlayShootAnimation);
    }

    public void DestroyComponent()
    {
        Destroy(this);
    }

    private void PlayShootAnimation()
    {
        _animatorComponent.Play("Shoot");
    }
}
