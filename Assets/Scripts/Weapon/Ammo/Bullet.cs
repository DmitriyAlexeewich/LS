using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Ammo.Perk;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class Bullet : MonoBehaviour
{

    [SerializeReference]
    protected List<Perk> _perks = new List<Perk>();


    protected Transform _transform;
    protected Vector3 _startPosition;

    protected Action<BulletEventArgs> _onStart;
    protected Action<BulletEventArgs> _onHit;
    protected BulletEventArgs _bulletEventArgs;

    public void Construct()
    {
        for (int i = 0; i < _perks.Count; i++)
        {
            switch (_perks[i].StartOn)
            {
                case EnumStartOn.OnBulletStart:
                    _onStart += _perks[i].StartPerk;
                    break;
                case EnumStartOn.OnBulletHit:
                    _onHit += _perks[i].StartPerk;
                    break;
            }
        }
    }

    public void StartBullet(Vector3 destinationPoint, Transform characterTransform)
    {
        _transform = this.gameObject.GetComponent<Transform>();
        _startPosition = _transform.position;
        _bulletEventArgs = new BulletEventArgs(characterTransform, _transform, destinationPoint);
        _onStart?.Invoke(_bulletEventArgs);
        FlyBullet(destinationPoint);
    }

    public virtual void Destroy()
    {
        _onStart = null;
        _onHit = null;
        Destroy(this.gameObject);
    }

    public void AddPerk(Perk perk)
    {
        if (perk != null)
        {
            _perks.Add(perk);
        }
    }

    protected abstract void FlyBullet(Vector3 point);
}