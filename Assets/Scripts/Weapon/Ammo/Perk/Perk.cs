using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Ammo.Perk.Condition;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk
{
    [Serializable]
    public abstract class Perk
    {
        public EnumStartOn StartOn { get { return _startOn; } }

        [SerializeField]
        [ReadOnly]
        protected EnumStartOn _startOn;
        [SerializeField]
        [ReadOnly]
        protected EnumStartBy _startBy;
        [SerializeField, Min(1)]
        protected int _perkActivationCount;
        [SerializeReference]
        protected PerkCondition _perkCondition;

        public Perk(EnumStartOn startOn, EnumStartBy startBy, int perkActivationCount, PerkCondition perkCondition)
        {
            _startOn = startOn;
            _startBy = startBy;
            if (perkActivationCount < 1)
                perkActivationCount = 1;
            _perkActivationCount = perkActivationCount;
            _perkCondition = perkCondition;
        }

        public async void StartPerk(BulletEventArgs bulletEventArgs)
        {
            bool _skipDelay = !_perkCondition.GetType().IsSubclassOf(typeof(PerkCondition));
            for (int i = 0; i < _perkActivationCount; i++)
            {
                await _perkCondition.isConditionComplete(bulletEventArgs).ConfigureAwait(false);
                ActivatePerk(bulletEventArgs);
            }
        }

        protected abstract void ActivatePerk(BulletEventArgs bulletEventArgs);
    }
}
