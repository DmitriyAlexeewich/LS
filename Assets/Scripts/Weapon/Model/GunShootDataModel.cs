using Assets.Scripts.Weapon.Bullet.Effects.Models;
using Assets.Scripts.Weapon.Bullet.Effects.NonEnemyHitEffects.Models;
using Assets.Scripts.Weapon.Effects.Enumerators;
using Assets.Scripts.Weapon.Model.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [System.Serializable]
    public class GunShootDataModel
    {
        public float Distance { get { return _Distance; } }
        public int BulletsCountPerOneShoot { get { return _BulletsCountPerOneShoot; } }
        public bool getRangeFormCircle { get { return _getRangeFormCircle; } }
        public float RangeX { get { return _RangeX; } }
        public float RangeY { get { return _RangeY; } }
        public EnumGunShootType GunShootType { get { return _GunShootType; } }


        [SerializeField]
        private float _Distance;
        [SerializeField]
        private int _BulletsCountPerOneShoot;
        [SerializeField]
        private bool _getRangeFormCircle = false;
        [SerializeField]
        private float _RangeX;//Diameter if _isRangeFormCircle = true
        [SerializeField]
        private float _RangeY;
        [SerializeField]
        private EnumGunShootType _GunShootType;


        public GunShootDataModel(float NewLifeTimeModifier, float NewSpeedModifier, float NewDistance,
                                 int NewBulletsCountPerOneShoot, bool NewGetRangeFormCircle, float NewRangeX,
                                 float NewRangeY, EnumGunShootType NewGunShootType)
        {
            if (NewDistance > 0)
                _Distance = NewDistance;
            else
                _Distance = 1;
            if (NewBulletsCountPerOneShoot >= 0)
                _BulletsCountPerOneShoot = NewBulletsCountPerOneShoot;
            else
                _BulletsCountPerOneShoot = 1;
            _getRangeFormCircle = NewGetRangeFormCircle;
            if (NewRangeX > 0)
                _RangeX = NewRangeX;
            else
                _RangeX = 0;
            if (NewRangeY > 0)
                _RangeY = NewRangeY;
            else
                _RangeY = 0;
            _GunShootType = NewGunShootType;
        }
    }
}
