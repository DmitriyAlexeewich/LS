using Assets.Scripts.Area.Models;
using Assets.Scripts.Area.Models.Inheritors;
using System.Threading.Tasks;
using UnityEngine;

public class StaticZone : Zone
{
    protected override void ScaleZone()
    {
        StaticZoneScale _staticZoneScale = (StaticZoneScale)_zoneScale;
        _transform.localScale = new Vector3(_staticZoneScale.StartScalse, _staticZoneScale.StartScalse, _staticZoneScale.StartScalse);
        Task.Delay(_lifetime);
    }
}