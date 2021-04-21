using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Bullet.Effects.NonEnemyHitEffects.Enumerators
{
    public enum EnumAlternativeHitEffectType
    {
        PoisonArea = 1,//Plasma
        DangerPlatform = 2,//Plasma
        DebuffArea = 3,//Plasma
        Shield = 4,//Bullet
        Trap = 5,//Bullet
        HitFromPoint = 6,//Bullet
        Turret = 7,//Rocket
        HitArea = 8,//Rocket
        DarkHole = 9,//Rocket
        Mine = 10,//Arrow
        ScareCrow = 11,//Arrow
        MoveObjectLink = 12//Arrow
    }
}
