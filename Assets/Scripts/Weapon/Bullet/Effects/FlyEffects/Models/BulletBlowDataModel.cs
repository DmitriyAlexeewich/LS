﻿using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models
{
    [System.Serializable]
    public class BulletBlowDataModel
    {
        public float DamageFactor;
        public float LifeTime;
        public float BlowTime;
        public EnumMagicType MagicType;
        public float EndDiameter;
    }
}