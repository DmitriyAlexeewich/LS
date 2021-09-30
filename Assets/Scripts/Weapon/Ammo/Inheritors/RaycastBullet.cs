using Assets.Scripts.Weapon.Ammo.Models;
using UnityEngine;

public class RaycastBullet : Bullet
{

    protected override void FlyBullet(Vector3 point)
    {
        RaycastShoot(point);
    }

    private void RaycastShoot(Vector3 destinationPoint)
    {
        RaycastHit _hit;
        if (Physics.Raycast(_startPosition, destinationPoint - _startPosition, out _hit))
        {
            _bulletEventArgs = new BulletEventArgs(_bulletEventArgs.ShootInitializerTransform, _bulletEventArgs.BulletTransform, _hit.point, _hit.collider.transform);
            _onHit?.Invoke(_bulletEventArgs);
        }
        Destroy();
    }
}
