using Assets.Scripts.Weapon.Bullet.Effects.EnemyHitEffects.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Bullet.Effects.EnemyHitEffects.Models
{
    [System.Serializable]
    public class EnemyHitEffectDataModel
    {
        public EnumEnemyHitEffectType EffectType;
        public int Level;

        public EnemyHitEffectDataModel(EnemyHitEffectDataModel Other)
        {
            EffectType = Other.EffectType;
            Level = Other.Level;
        }
    }
}
