using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Bullet.Effects.EnemyHitEffects.Enumerators
{
    public enum EnumEnemyHitEffectType
    {
        Nothing = 0,//All
        Poison = 1,//Plasma
        Debuff = 2,//Plasma
        Disorientation = 3,//Plasma
        PhysicsImpulse = 4,//Bullet
        MomentDamageArea = 5,//Bullet
        IgnoreShield = 6,//Bullet
        ClasterBomb = 7,//Rocket
        TimeDamageArea = 8,//Rocket
        OneTurnTurret = 9,//Rocket
        Stop = 10,//Arrow
        Bleeding = 11,//Arrow
        SecondArrowAfterHit = 12//Arrow
    }
}
