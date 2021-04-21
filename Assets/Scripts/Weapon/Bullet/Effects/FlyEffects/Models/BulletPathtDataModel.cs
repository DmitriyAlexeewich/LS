using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models
{
    [System.Serializable]
    public class BulletPathtDataModel
    {
        public float DamageFactor;
        public float LifeTime;
        public float TimeUpdate;
        public Vector3 Scale;
        public EnumMagicType MagicType;
    }
}
