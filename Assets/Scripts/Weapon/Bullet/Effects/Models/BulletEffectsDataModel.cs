using Assets.Scripts.Weapon.Bullet.Effects.EnemyHitEffects.Models;
using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Bullet.Effects.Models
{
    [System.Serializable]
    public class BulletEffectsDataModel
    {
        public FlyEffectDataModel BulletFlyEffect = null;
        public EnemyHitEffectDataModel EnemyHitEffect;
    }
}
