using Assets.Scripts.Player.Model;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerWeaponVisualisation : MonoBehaviour
{

    public int WeaponId { get { return PWeaponId; } }
    public Transform BulletSpawnPoint { get { return PBulletSpawnPoint; } }

    [SerializeField]
    int PWeaponId;
    [SerializeField]
    Transform PBulletSpawnPoint;
    [SerializeField]
    float Weight;
    [SerializeField]
    Animator GunAnimatorController;
    [SerializeField]
    List<MeshRenderer> ChildObjectMeshRenders;
    [SerializeField]
    Light ShootLight;
    [SerializeField]
    VisualEffect MuzzleFlashEffect;


    Transform PlayerWeaponVisualisationTransform;
    Vector3 StartPosition;
    float MaxInertiaAmount = 0.04f;
    float ShootSpeedMultiplier = 1f;

    public void Construct(int Id, PlayerWeaponVisualisationDataModel NewPlayerWeaponVisualisationData, float TriggerWaitingTime)
    {
        PlayerWeaponVisualisationTransform = this.gameObject.GetComponent<Transform>();
        PWeaponId = Id;
        Weight = NewPlayerWeaponVisualisationData.Weight;
        PlayerWeaponVisualisationTransform.localPosition = NewPlayerWeaponVisualisationData.Position;
        PlayerWeaponVisualisationTransform.localRotation = NewPlayerWeaponVisualisationData.Rotation;
        StartPosition = NewPlayerWeaponVisualisationData.Position;
        MaxInertiaAmount = NewPlayerWeaponVisualisationData.MaxInertiaAmount;
        ShootLight.range = NewPlayerWeaponVisualisationData.ShootLightRange;
        for (int i = 0; i < ChildObjectMeshRenders.Count; i++)
        {
            for (int j = 0; j < ChildObjectMeshRenders[i].materials.Length; j++)
            {
                if (ChildObjectMeshRenders[i].materials[j].shader.name.IndexOf("CorpusUV") != -1)
                {
                    ChildObjectMeshRenders[i].materials[j].SetColor("Color_C92A1814", NewPlayerWeaponVisualisationData.MainGlowColor);
                    ChildObjectMeshRenders[i].materials[j].SetColor("Color_27019264", NewPlayerWeaponVisualisationData.GlowSecondaryColor);
                }
                if (ChildObjectMeshRenders[i].materials[j].shader.name.IndexOf("ManaPBR") != -1)
                {
                    ChildObjectMeshRenders[i].materials[j].SetColor("Color_5C3538EE", NewPlayerWeaponVisualisationData.MainGlowColor);
                    ChildObjectMeshRenders[i].materials[j].SetColor("Color_BFC416E9", NewPlayerWeaponVisualisationData.GlowSecondaryColor);
                }
            }
        }
        ShootLight.intensity = NewPlayerWeaponVisualisationData.ShootLightIntensity;
        ShootLight.color = NewPlayerWeaponVisualisationData.ShootLightColor;
        ShootLight.enabled = false;
        if(MuzzleFlashEffect != null)
            MuzzleFlashEffect.Stop();
    }

    public void ShowWeapon()
    {
        PlayerWeaponVisualisationTransform.gameObject.SetActive(true);
    }

    public void HideWeapon()
    {
        PlayerWeaponVisualisationTransform.gameObject.SetActive(false);
    }

    public void PlayShootAnimation()
    {
        GunAnimatorController.Play("Shoot");
        MuzzleFlashEffect.Play();
    }

    public void StartShootEffect()
    {
        ShootLight.enabled = true;
    }

    public void StopShootEffect()
    {
        ShootLight.enabled = false;
    }


    void Update()
    {
        var lerpPosition = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        lerpPosition *= Weight;
        lerpPosition.x = Mathf.Clamp(lerpPosition.x, -MaxInertiaAmount, MaxInertiaAmount);
        lerpPosition.y = Mathf.Clamp(lerpPosition.y, -MaxInertiaAmount, MaxInertiaAmount);
        PlayerWeaponVisualisationTransform.localPosition = Vector3.Lerp(PlayerWeaponVisualisationTransform.localPosition, StartPosition + lerpPosition, Time.deltaTime);
    }
}
