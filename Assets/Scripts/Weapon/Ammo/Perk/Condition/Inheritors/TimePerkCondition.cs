using Assets.Scripts.Weapon.Ammo.Models;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.Condition.Inheritors
{
    [Serializable]
    public class TimePerkCondition : PerkCondition
    {

        [SerializeField, Range(500, 5000)]
        private int _activationTime;

        public TimePerkCondition(int activationTime = 500)
        {
            if (activationTime <= 5000)
                _activationTime = activationTime;
            else
                _activationTime = 5000;

            if (activationTime < 500)
                _activationTime = 500;
        }

        public override async Task isConditionComplete(BulletEventArgs bulletEventArgs)
        {
            await Task.Delay(_activationTime).ConfigureAwait(false);
        }
    }
}
