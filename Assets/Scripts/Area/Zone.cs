using Assets.Scripts.Area.Models;
using UnityEngine;

public abstract class Zone : MonoBehaviour
{
    [SerializeReference]
    protected ZoneScale _zoneScale;
    [SerializeField]
    protected int _lifetime;

    protected Transform _transform;

    public void StartZone()
    {
        _transform = this.gameObject.GetComponent<Transform>();
        ScaleZone();
    }

    public virtual void Destroy()
    {

    }

    protected abstract void ScaleZone();

}
