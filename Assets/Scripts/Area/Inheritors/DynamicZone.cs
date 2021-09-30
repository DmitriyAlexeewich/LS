using Assets.Scripts.Area.Models;
using Assets.Scripts.Area.Models.Inheritors;
using System.Threading.Tasks;
using UnityEngine;

public class DynamicZone : Zone
{
    protected override void ScaleZone()
    {
        DynamicZoneScale _dynamicZoneScale = (DynamicZoneScale)_zoneScale;
        Vector3 _startScale = new Vector3(_dynamicZoneScale.MinScale, _dynamicZoneScale.MinScale, _dynamicZoneScale.MinScale);
        Vector3 _toScale = new Vector3(_dynamicZoneScale.MaxScale, _dynamicZoneScale.MaxScale, _dynamicZoneScale.MaxScale);

        _transform.localScale = _startScale;
        for (int i = _dynamicZoneScale.ScaleTimeStep; i < _dynamicZoneScale.ScaleTime + _dynamicZoneScale.ScaleTimeStep; i += _dynamicZoneScale.ScaleTimeStep)
        {
            Vector3.Lerp(_startScale, _toScale, i);
            Task.Delay(_dynamicZoneScale.ScaleTimeStep);
        }
        Task.Delay(_lifetime);
    }
}