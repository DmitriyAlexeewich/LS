using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Gun _gun;

    private Action<bool> _startShootLoad;
    private Action _switchGunModeType;

    private void Start()
    {
        _startShootLoad += _gun.StartShootLoad;
        _switchGunModeType += _gun.SwitchGunModeType;
        _gun.Construct(this.transform);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
            _startShootLoad?.Invoke(true);
        if (Input.GetMouseButtonUp(0))
            _startShootLoad?.Invoke(false);
        if (Input.GetMouseButtonDown(1))
            _switchGunModeType?.Invoke();
    }
}
