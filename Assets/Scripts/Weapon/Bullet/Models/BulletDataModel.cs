using Assets.Scripts.Stats.Enumerators;
using Assets.Scripts.Stats.Model;
using Assets.Scripts.Weapon.Bullet.Effects.Models;
using Assets.Scripts.Weapon.Bullet.Enumerators;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapon.Bullet.Models
{
    [System.Serializable]
    public class BulletDataModel
    {

        public EnumBulletType BulletType { get { return _BulletType; } }
        public List<StatusDataModel> StatusesData { get { return _StatusesData; } }
        public float Diameter { get { return _Diameter; } }
        public List<Vector3> CheckHitPoints { get { return _CheckHitPoints; } }
        public float CheckHitPointsDistance { get { return _CheckHitPointsDistance; } }
        public List<BulletEffectsDataModel> BulletEffects { get { return _BulletEffects; } }
        public EnumMagicType MagicType { get { return _MagicType; } }


        [SerializeField]
        private EnumBulletType _BulletType;
        [SerializeField]
        private List<StatusDataModel> _StatusesData = new List<StatusDataModel>();
        [SerializeField]
        private float _Diameter;
        [SerializeField]
        private List<Vector3> _CheckHitPoints = new List<Vector3>();
        [SerializeField]
        private float _CheckHitPointsDistance;
        [SerializeField]
        private List<BulletEffectsDataModel> _BulletEffects = new List<BulletEffectsDataModel>();
        [SerializeField]
        private EnumMagicType _MagicType;

        public BulletDataModel(EnumBulletType NewBulletType, float NewLifeTime, float NewDistance, float NewDamage, 
                               float NewSpeed, float NewDiameter, EnumMagicType NewMagicType)
        {
            _BulletType = NewBulletType;
            if (NewLifeTime > 0)
                StatusesData.Add(new StatusDataModel(EnumStatusType.LifeTime, 0f, NewLifeTime));
            else
                StatusesData.Add(new StatusDataModel(EnumStatusType.LifeTime, 0f, 1));
            StatusesData.Add(new StatusDataModel(EnumStatusType.Damage, NewDamage));
            StatusesData.Add(new StatusDataModel(EnumStatusType.Speed, NewSpeed));
            if (NewDiameter > 0)
                _Diameter = NewDiameter;
            else
                _Diameter = 1;
            _MagicType = NewMagicType;
        }

        public BulletDataModel(BulletDataModel OriginalBullet)
        {
            _BulletType = OriginalBullet.BulletType;
            _StatusesData = OriginalBullet.StatusesData;
            _Diameter = OriginalBullet.Diameter;
            _CheckHitPoints = OriginalBullet.CheckHitPoints;
            _CheckHitPointsDistance = OriginalBullet.CheckHitPointsDistance;
            _BulletEffects = OriginalBullet.BulletEffects;
            _MagicType = OriginalBullet.MagicType;
        }

        public void GenerateCheckHitPoints()
        {
            _CheckHitPointsDistance = Mathf.Sin((float)((Math.PI / 180) * 90)) * (Diameter / 2);
            for (int i = 0; i < 360; i += 90)
            {
                var deltaAngle = (float)((Math.PI / 180) * i);
                CheckHitPoints.Add(new Vector3(Mathf.Cos(deltaAngle), Mathf.Sin(deltaAngle), 1));
            }
        }

        public void AddBulletEffect(BulletEffectsDataModel BulletEffect)
        {
            _BulletEffects.Add(BulletEffect);
        }
    }
}
