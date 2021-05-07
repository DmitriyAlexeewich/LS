using Assets.Scripts.Effects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Effect : MonoBehaviour
{
    Status targetStatus;

    public void Construct(EffectDataModel EffectData)
    {
        var statuses = this.gameObject.GetComponents<Status>();
        for (int i = 0; i < statuses.Length; i++)
        {
            
        }
    }

}
