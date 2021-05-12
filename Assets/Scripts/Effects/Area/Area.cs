using Assets.Scripts.Effects.Area.Enumerators;
using Assets.Scripts.Effects.Area.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Area : MonoBehaviour
{
    List<AreaEffectDataModel> AreaEffects = new List<AreaEffectDataModel>();

    Transform TransformComponent;
    List<Effect> RemovableEffects = new List<Effect>();
    IEnumerator ScaleToSizeCoroutine;

    public void Construct(AreaDataModel AreaData)
    {
        TransformComponent = this.gameObject.GetComponent<Transform>();
        AreaEffects = AreaData.AreaEffectsData;
        Collider triggerCollider = null;
        switch (AreaData.AreaType)
        {
            case EnumAreaType.Cube:
                var cubeCollider = this.gameObject.AddComponent<BoxCollider>();
                cubeCollider.size = AreaData.Size;
                triggerCollider = cubeCollider;
                break;
            case EnumAreaType.Sphere:
                var sphereCollider = this.gameObject.AddComponent<SphereCollider>();
                sphereCollider.radius = AreaData.Size.x / 2;
                triggerCollider = sphereCollider;
                break;
            case EnumAreaType.Capsule:
                var capsuleColider = this.gameObject.AddComponent<CapsuleCollider>();
                capsuleColider.radius = AreaData.Size.x;
                capsuleColider.height = AreaData.Size.y;
                triggerCollider = capsuleColider;
                break;
        }
        if(triggerCollider != null)
            triggerCollider.isTrigger = true;
        if (AreaData.isScaleToSize)
            StartScaleToSizeCoroutine();
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        
    }

    void StartScaleToSizeCoroutine()
    {
        ScaleToSizeCoroutine = ScaleToSize();
        StartCoroutine(ScaleToSizeCoroutine);
    }

    IEnumerator ScaleToSize()
    {
        TransformComponent.localScale = Vector3.zero;
        while (TransformComponent.localScale < Vector3.one)
        {
            while
        }
    }
}
