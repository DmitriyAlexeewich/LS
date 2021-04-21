using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models
{
    [System.Serializable]
    public class BulletChangeMagicTypeByTimeDataModel
    {
        public float ChangeTime;
        public List<EnumMagicType> MagicTypes = new List<EnumMagicType>();
    }
}
