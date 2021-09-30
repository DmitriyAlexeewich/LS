using Assets.Scripts.Stats.Child.Model;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Bullet.Models
{
    [System.Serializable]
    public class PhysicsBulletDataModel : BulletDataModel
    {

        public float Diameter { get { return _Diameter; } }
        public LifeTimeDataModel LifeTimeData { get { return _LifeTimeData; } }
        public SpeedDataModel SpeedData { get { return _SpeedData; } }
        public List<Vector3> CheckHitPoints { get { return _CheckHitPoints; } }
        public float CheckHitPointsDistance { get { return _CheckHitPointsDistance; } }


        [SerializeField]
        private float _Diameter;
        [SerializeField]
        private LifeTimeDataModel _LifeTimeData;
        [SerializeField]
        private SpeedDataModel _SpeedData;
        [SerializeField]
        private List<Vector3> _CheckHitPoints = new List<Vector3>();
        [SerializeField]
        private float _CheckHitPointsDistance;


        public PhysicsBulletDataModel(float NewDiameter, float NewDamage, float NewLifeTime, float NewSpeed, EnumMagicType NewMagicType)
            :base(NewDamage, NewMagicType)
        {
            var magicTypes = new HashSet<EnumMagicType>();
            magicTypes.Add(NewMagicType);
            if (NewLifeTime > 0)
                _LifeTimeData = new LifeTimeDataModel(magicTypes, 0f, NewLifeTime);
            else
                _LifeTimeData = new LifeTimeDataModel(magicTypes, 0f, 1f);
            _SpeedData = new SpeedDataModel(magicTypes, NewSpeed);
            if (NewDiameter > 0)
                _Diameter = NewDiameter;
            else
                _Diameter = 1;
            GenerateCheckHitPoints();
        }

        void GenerateCheckHitPoints()
        {
            _CheckHitPointsDistance = Mathf.Sin((float)((Math.PI / 180) * 90)) * (Diameter / 2);
            for (int i = 0; i < 360; i += 90)
            {
                var deltaAngle = (float)((Math.PI / 180) * i);
                CheckHitPoints.Add(new Vector3(Mathf.Cos(deltaAngle), Mathf.Sin(deltaAngle), 1));
            }
        }
    }
}
