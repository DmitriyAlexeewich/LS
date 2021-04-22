using Assets.Scripts.Weapon.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : MonoBehaviour
{
    BulletSpawnPoint BulletSpawnPointComponent;

    Animator AnimatorComponent;
    List<MeshRenderer> MeshesRendereres;

    Action StartShootEventHandler;

    public void Construct(GunVisualisationDataModel GunVisualisationData, Action StartShootEvent, Action StopShootEvent)
    {
        StartShootEventHandler = StartShootEvent;

        BulletSpawnPointComponent = this.gameObject.GetComponentInChildren<BulletSpawnPoint>();
        BulletSpawnPointComponent.Construct();

        this.gameObject.GetComponentInChildren<GunMuzzleFlashLight>().Construct(GunVisualisationData.GunShootLightData, StartShootEventHandler, StopShootEvent);

        this.gameObject.GetComponentInChildren<GunMuzzleFlashEffect>().Construct(StartShootEventHandler);

        AnimatorComponent = this.gameObject.GetComponent<Animator>();
        if (AnimatorComponent != null)
            StartShootEventHandler += PlayShootAnimation;

        MeshesRendereres.Add(this.gameObject.GetComponent<MeshRenderer>());
        MeshesRendereres.AddRange(this.gameObject.GetComponentsInChildren<MeshRenderer>());
        ApplyMaterialData(GunVisualisationData.MainGlowColor, GunVisualisationData.GlowSecondaryColor);
    }

    public Transform GetBulletSpawnPointTransform()
    {
        return BulletSpawnPointComponent.GetBulletSpawnPointTransform();
    }

    public void DestroyComponent()
    {
        this.gameObject.GetComponentInChildren<GunMuzzleFlashLight>().DestroyComponent();
        this.gameObject.GetComponentInChildren<GunMuzzleFlashEffect>().DestroyComponent();
        if (AnimatorComponent != null)
            StartShootEventHandler -= PlayShootAnimation;
        Destroy(this);
    }

    void PlayShootAnimation()
    {
        AnimatorComponent.Play("Shoot");
    }

    void ApplyMaterialData(Color MainGlowColor, Color GlowSecondaryColor)
    {
        for (int i = 0; i < MeshesRendereres.Count; i++)
        {
            for (int j = 0; j < MeshesRendereres[i].materials.Length; j++)
            {
                if (MeshesRendereres[i].materials[j].shader.name.IndexOf("CorpusUV") != -1)
                {
                    MeshesRendereres[i].materials[j].SetColor("Color_C92A1814", MainGlowColor);
                    MeshesRendereres[i].materials[j].SetColor("Color_27019264", GlowSecondaryColor);
                }
                else if (MeshesRendereres[i].materials[j].shader.name.IndexOf("ManaPBR") != -1)
                {
                    MeshesRendereres[i].materials[j].SetColor("Color_5C3538EE", MainGlowColor);
                    MeshesRendereres[i].materials[j].SetColor("Color_BFC416E9", GlowSecondaryColor);
                }
            }
        }
    }
}
