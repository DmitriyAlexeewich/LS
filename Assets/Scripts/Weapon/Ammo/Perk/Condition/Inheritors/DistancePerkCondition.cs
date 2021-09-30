using Assets.Scripts.Weapon.Ammo.Models;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.Condition.Inheritors
{
    [Serializable]
    public class DistancePerkCondition : PerkCondition
    {

        [SerializeField, Min(1)]
        private float _activationDistance;

        public DistancePerkCondition(float activationDistance = 1)
        {
            if (activationDistance < 1)
                _activationDistance = activationDistance;
            else
                _activationDistance = 1;
        }

        public override async Task isConditionComplete(BulletEventArgs bulletEventArgs)
        {
            Vector3 _startPosition = new Vector3(bulletEventArgs.BulletTransform.position.x, bulletEventArgs.BulletTransform.position.y, bulletEventArgs.BulletTransform.position.z);

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500).ConfigureAwait(false);
                if (Vector3.Distance(_startPosition, bulletEventArgs.BulletTransform.position) < _activationDistance)
                    break;
            }
        }
    }
}
