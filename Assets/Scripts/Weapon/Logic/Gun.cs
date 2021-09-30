using Assets.Scripts.Weapon.Logic.Model;
using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private List<EnumGunModeType> _gunModeTypes;
    [Space(10)]
    [SerializeField]
    private List<GunMode> _gunModes;

    private int _currentGunModeType = 0;
    private Action<StartShootEventArgs> _startShoot;

    public void Construct(Transform characterTransform)
    {
        for (int i = 0; i < _gunModes.Count; i++)
        {
            _startShoot += _gunModes[i].StartShootLoad;
            _gunModes[i].Construct(characterTransform);
        }
    }

    public void Destroy()
    {
        for (int i = 0; i < _gunModes.Count; i++)
        {
            _startShoot -= _gunModes[i].StartShootLoad;
            _gunModes[i].Destroy();
        }
        _startShoot = null;
    }

    public void StartShootLoad(bool isRealize)
    {
        _startShoot?.Invoke(new StartShootEventArgs(isRealize, _gunModeTypes[_currentGunModeType]));
    }

    public void SwitchGunModeType()
    {
        if (_currentGunModeType + 1 >= _gunModeTypes.Count)
            _currentGunModeType = 0;
        else
            _currentGunModeType++;
    }
}