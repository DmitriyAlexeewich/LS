using Assets.Scripts.Stats;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator;
using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Ammo.Perk.Condition;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters.Enumerators;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters
{
    [Serializable]
    public class ModifyParametersPerk : Perk
    {

        private EnumTransformTargetType _transformTargetType;
        [SerializeField]
        private List<StatusModificator> _modificators;

        public ModifyParametersPerk(EnumStartOn startOn, int perkActivationCount, PerkCondition perkCondition, EnumTransformTargetType transformTargetType, 
            List<StatusModificator> modificators) : 
            base(startOn, perkActivationCount, perkCondition)
        {
            _transformTargetType = transformTargetType;
            if (modificators != null)
                _modificators = modificators;
        }

        protected override void ActivatePerk(BulletEventArgs bulletEventArgs)
        {
            Transform _targetTransform = null;
            switch (_transformTargetType)
            {
                case EnumTransformTargetType.ShootInitializerTransform:
                    _targetTransform = bulletEventArgs.ShootInitializerTransform;
                    break;
                case EnumTransformTargetType.BulletTransform:
                    _targetTransform = bulletEventArgs.BulletTransform;
                    break;
                case EnumTransformTargetType.HitObjectTransform:
                    _targetTransform = bulletEventArgs.HitObjectTransform;
                    break;
                default:
                    break;
            }

            if (_targetTransform != null)
            {
                StatusesContainer _targetStatusesContainer = _targetTransform.GetComponent<StatusesContainer>();
                if (_targetStatusesContainer != null)
                {
                    for (int i = 0; i < _modificators.Count; i++)
                    {
                        Status _targetStatus = _targetStatusesContainer.Statuses.FirstOrDefault(item => item.StatusType == _modificators[i].StatusType);
                        ModifiableStatus _modifiableStatus = (ModifiableStatus)_targetStatus;
                        StatusModificator _modificator = _modifiableStatus.AddStatusModificator(_modificators[i]);
                        _modificator.StartModificator(_modifiableStatus);
                    }
                }
            }
        }

        public void AddStatusModificator(StatusModificator statusModificator)
        {
            _modificators.Add(statusModificator);
        }
    }
}
