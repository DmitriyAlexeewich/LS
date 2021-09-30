using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class GunShootPoint : GunShootVectorPoint
{

    [SerializeField]
    private GunShootVectorDirectionPoint _gunShootVectorDirectionPoint;
    [SerializeField]
    private GunShootVectorStartPoint _gunShootVectorStartPoint;

    private int _maxDistance = 90;
    private Transform _characterTransform;

    public void Constructor(Transform characterTransform)
    {
        _characterTransform = characterTransform;
    }

    public void Destroy()
    {
        Destroy(this);
    }

    public void Shoot(Bullet bullet)
    {
        Bullet _bullet = Instantiate(bullet, _gunShootVectorStartPoint.Point.position, new Quaternion());

        RaycastHit _hit;
        Vector3 _direction = _gunShootVectorDirectionPoint.Point.position - _gunShootVectorStartPoint.Point.position;
        if (!Physics.Raycast(_gunShootVectorDirectionPoint.Point.position, _direction, out _hit))
            _hit.point = _direction * _maxDistance;

        _bullet.StartBullet(_hit.point, _characterTransform);
    }
}
