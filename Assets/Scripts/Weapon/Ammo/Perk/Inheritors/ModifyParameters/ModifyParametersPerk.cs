using Assets.Scripts.Status.Modificator;
using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Ammo.Perk.Condition;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters
{
    [Serializable]
    public class ModifyParametersPerk : Perk
    {

        [SerializeField]
        private List<StatusModificatorAlgorithm> _modificators;

        public ModifyParametersPerk(EnumStartOn startOn, EnumStartBy startBy, int perkActivationCount, PerkCondition perkCondition) : base(startOn, startBy, perkActivationCount, perkCondition)
        {
        }

        protected override void ActivatePerk(BulletEventArgs bulletEventArgs)
        {
        }


    }
}
