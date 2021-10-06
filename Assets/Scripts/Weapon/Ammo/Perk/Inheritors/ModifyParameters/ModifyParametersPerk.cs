using Assets.Scripts.Status;
using Assets.Scripts.Status.Modificator;
using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Ammo.Perk.Condition;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters.Enumerators;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters
{
    [Serializable]
    public class ModifyParametersPerk : Perk
    {

        private EnumTransformTargetType _transformTargetType;
        [SerializeField]
        private List<StatusModificator> _modificators;

        public ModifyParametersPerk(EnumStartOn startOn, EnumStartBy startBy, int perkActivationCount, PerkCondition perkCondition, EnumTransformTargetType transformTargetType, 
            List<StatusModificator> modificators) : 
            base(startOn, startBy, perkActivationCount, perkCondition)
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
                StatusCollections _targetStatusCollections = _targetTransform.GetComponent<StatusCollections>();
                if (_targetStatusCollections != null)
                {
                    for (int i = 0; i < _modificators.Count; i++)
                    {
                        for (int j = 0; j < _targetStatusCollections.Statuses.Count; j++)
                        {
                            if (_targetStatusCollections.Statuses[j].StatusType == _modificators[i].StatusType)
                            {
                                ModifiableStatus _modifiableStatus = (ModifiableStatus)_targetStatusCollections.Statuses[j];
                                StatusModificator _modificator = _modifiableStatus.AddStatusModificator(_modificators[i]);
                                _modificator.StartModificator(_modifiableStatus);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
