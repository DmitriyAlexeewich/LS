using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GunShootProfile : TimeWaiter
{
    [SerializeField]
    private EnumGunShootTriggerType _gunShootTriggerType;
    [SerializeReference]
    private List<Bullet> _bullets;
    [SerializeField]
    private List<GunShootPoint> _gunShootPoints = new List<GunShootPoint>();

    private int _currentBulletIndex = 0;
    private Action<Bullet> _startShoot;

    public void Constructor(Transform characterTransform)
    {
        for (int i = 0; i < _bullets.Count; i++)
            _bullets[i].Construct();

        switch (_gunShootTriggerType)
        {
            case EnumGunShootTriggerType.OnStart:
                TimerStarted += StartShoot;
                break;
            case EnumGunShootTriggerType.OnEnd:
                TimerEnded += StartShoot;
                break;
        }
        for (int i = 0; i < _gunShootPoints.Count; i++)
        {
            _gunShootPoints[i].Constructor(characterTransform);
            _startShoot += _gunShootPoints[i].Shoot;
        }
    }

    public new void Destroy()
    {
        for (int i = 0; i < _bullets.Count; i++)
            _bullets[i].Destroy();
        for (int i = 0; i < _gunShootPoints.Count; i++)
        {
            _startShoot -= _gunShootPoints[i].Shoot;
            _gunShootPoints[i].Destroy();
        }
        _startShoot = null;
        base.Destroy();
    }

    private void StartShoot()
    {
        _startShoot?.Invoke(_bullets[_currentBulletIndex]);
        UpdateCurrentBulletIndex();
    }

    private void UpdateCurrentBulletIndex()
    {
        _currentBulletIndex++;
        if (_currentBulletIndex >= _bullets.Count)
            _currentBulletIndex = 0;
    }
}
