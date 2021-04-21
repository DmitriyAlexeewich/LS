using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Enumerators
{
    public enum EnumFlyEffectType
    {
        Nothing = 0,//All

        GroundPath = 1,//Plasma
        DamageUp = 2,//Plasma
        DangerZone = 3,//Plasma

        BlowByDistancePercent = 4,//Bullet
        Ricochet = 5,//Bullet
        Clone = 6,//Bullet

        FlyPath = 7,//Rocket
        MineByTime = 8,//Rocket
        Link = 9,//Rocket

        IgnoreWall = 10,//Arrow
        ReverseLink = 11,//Arrow
        Dublicate = 12//Arrow        
    }
}
