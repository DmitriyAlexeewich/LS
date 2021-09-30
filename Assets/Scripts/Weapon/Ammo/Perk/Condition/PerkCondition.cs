using Assets.Scripts.Weapon.Ammo.Models;
using System;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Ammo.Perk.Condition
{
    [Serializable]
    public abstract class PerkCondition
    {

        public abstract Task isConditionComplete(BulletEventArgs bulletEventArgs);
    }
}
