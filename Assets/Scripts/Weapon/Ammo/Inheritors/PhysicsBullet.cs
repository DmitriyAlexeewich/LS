using Assets.Scripts.Weapon.Ammo.Models;
using System.Threading.Tasks;
using UnityEngine;

public class PhysicsBullet : Bullet
{

    [SerializeField]
    [ReadOnly]
    private int _speed;
    [SerializeField, Min(1)]
    [Tooltip("Time in miliseconds")]
    private int _lifeTime;

    private int _timeStep = 10;
    private bool _isHitted = false; 

    protected override void FlyBullet(Vector3 point)
    {
        BulletMovement(point);
    }

    private async void BulletMovement(Vector3 point)
    {
        while ((_lifeTime > 0) && (!_isHitted))
        {
            await Task.Delay(_timeStep);
            _lifeTime -= _timeStep;
            _transform.position = Vector3.MoveTowards(_transform.position, point, _speed * _timeStep / 1000f);
        }
        Destroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isHitted)
        {
            _bulletEventArgs = new BulletEventArgs(_bulletEventArgs.ShootInitializerTransform, _bulletEventArgs.BulletTransform, _bulletEventArgs.DestinationPoint, other.transform);
            _onHit?.Invoke(_bulletEventArgs);
            _isHitted = true;
        }
    }
}
