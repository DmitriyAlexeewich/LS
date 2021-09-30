using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]
public class GunMuzzleFlashEffect : MonoBehaviour
{

    private VisualEffect _muzzleFlashEffectComponent;

    public void Construct(UnityEvent startShootEvent)
    {

        _muzzleFlashEffectComponent = this.gameObject.GetComponent<VisualEffect>();
        _muzzleFlashEffectComponent.Stop();

        startShootEvent.AddListener(PlayMuzzleFlashEffect);
    }

    public void DestroyComponent()
    {
        Destroy(this);
    }

    private void PlayMuzzleFlashEffect()
    {
        _muzzleFlashEffectComponent.Play();
    }

}
