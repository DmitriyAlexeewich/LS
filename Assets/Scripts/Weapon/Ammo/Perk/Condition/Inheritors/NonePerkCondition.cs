﻿using Assets.Scripts.Weapon.Ammo.Models;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapon.Ammo.Perk.Condition.Inheritors
{
    public class NonePerkCondition : PerkCondition
    {
        public override async Task isConditionComplete(BulletEventArgs bulletEventArgs)
        {
        }
    }
}
