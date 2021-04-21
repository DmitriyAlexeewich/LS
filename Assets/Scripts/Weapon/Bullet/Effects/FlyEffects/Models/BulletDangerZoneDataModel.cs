using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models
{
    [System.Serializable]
    public class BulletDangerZoneDataModel
    {
        public float DamageFactor;
        public EnumMagicType MagicType;
        public float EndDiameter;
    }
}
