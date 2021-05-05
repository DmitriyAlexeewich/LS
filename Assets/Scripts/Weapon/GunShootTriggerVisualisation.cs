using Assets.Scripts.Weapon.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GunShootTriggerVisualisation : MonoBehaviour
{

    Animator AnimatorComponent;

    public void Construct(GunVisualisationDataModel GunVisualisationData, GunShootTrigger GunShootTriggerComponent)
    {

        List<MeshRenderer> meshesRenderers = new List<MeshRenderer>();
        meshesRenderers.AddRange(this.gameObject.GetComponentsInChildren<MeshRenderer>());
        var parentMeshRender = this.gameObject.GetComponent<MeshRenderer>();
        if (parentMeshRender != null)
            meshesRenderers.Add(parentMeshRender);
        ApplyMaterialData(meshesRenderers, GunVisualisationData.MainGlowColor, GunVisualisationData.GlowSecondaryColor);

        AnimatorComponent = this.gameObject.GetComponent<Animator>();
        if (AnimatorComponent != null)
            GunShootTriggerComponent.StartShootEvent += PlayShootAnimation;
    }

    public void DestroyComponent(GunShootTrigger GunShootTriggerComponent)
    {
        if (AnimatorComponent != null)
            GunShootTriggerComponent.StartShootEvent -= PlayShootAnimation;
        Destroy(this);
    }

    void ApplyMaterialData(List<MeshRenderer> MeshesRendereres, Color MainGlowColor, Color GlowSecondaryColor)
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

    void PlayShootAnimation()
    {
        AnimatorComponent.Play("Shoot");
    }
}
