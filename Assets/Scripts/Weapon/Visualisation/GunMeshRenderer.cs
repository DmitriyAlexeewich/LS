using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class GunMeshRenderer : MonoBehaviour
{

    private MeshRenderer _meshRenderer;

    public void Construct(Color? mainGlowColor = null, Color? glowSecondaryColor = null)
    {
        _meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        if ((mainGlowColor != null) && (glowSecondaryColor != null))
            SetGlowColor(mainGlowColor.Value, glowSecondaryColor.Value);
    }

    public void SetGlowColor(Color mainGlowColor, Color glowSecondaryColor)
    {
        for (int i = 0; i < _meshRenderer.materials.Length; i++)
        {
            if (_meshRenderer.materials[i].shader.name.IndexOf("CorpusUV") != -1)
            {
                _meshRenderer.materials[i].SetColor("Color_C92A1814", mainGlowColor);
                _meshRenderer.materials[i].SetColor("Color_27019264", glowSecondaryColor);
            }
            else if (_meshRenderer.materials[i].shader.name.IndexOf("ManaPBR") != -1)
            {
                _meshRenderer.materials[i].SetColor("Color_5C3538EE", mainGlowColor);
                _meshRenderer.materials[i].SetColor("Color_BFC416E9", glowSecondaryColor);
            }
        }
    }
}
