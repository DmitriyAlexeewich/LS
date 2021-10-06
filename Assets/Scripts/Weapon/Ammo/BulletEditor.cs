using UnityEngine;
using UnityEditor;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using Assets.Scripts.Weapon.Ammo.Perk.Condition;
using Assets.Scripts.Weapon.Ammo.Perk.Condition.Inheritors;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.CreateObject.Inheritors.CreateBullet;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters;
using Assets.Scripts.Weapon.Ammo.Perk.CreateObject.Inheritors.Inheritors.CreateZone;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.CreateObject.Inheritors.CreateZone.Enumerators;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters.Enumerators;
using System.Collections.Generic;
using Assets.Scripts.Status.Modificator;

[CustomEditor(typeof(Bullet), true)]
public class BulletEditor : Editor
{
    private EnumPerkType _perkType;
    private EnumStartOn _startOn;
    private EnumStartBy _startBy;
    private PerkCondition _perkCondition;

    private Bullet _spawningBullet;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DrawUILine(Color.grey, 1);
        EditorGUILayout.LabelField("Perk constructor");

        var _bullet = (Bullet)target;

        _perkType = (EnumPerkType)EditorGUILayout.EnumPopup("Perk", _perkType);
        _startOn = (EnumStartOn)EditorGUILayout.EnumPopup("Start on", _startOn);
        _startBy = (EnumStartBy)EditorGUILayout.EnumPopup("Start by", _startBy);

        switch (_startBy)
        {
            case EnumStartBy.Distance:
                _perkCondition = new DistancePerkCondition();
                break;
            case EnumStartBy.Time:
                _perkCondition = new TimePerkCondition();
                break;
            default:
                _perkCondition = new NonePerkCondition();
                break;
        }

        switch (_perkType)
        {
            case EnumPerkType.CreateBullet:
                EditorGUILayout.ObjectField(_spawningBullet, typeof(Bullet), false);
                break;
            case EnumPerkType.CreateZone:
                break;
            case EnumPerkType.ModifyParameters:
                break;
            default:
                break;
        }

        if (GUILayout.Button("Add perk"))
        {
            switch (_perkType)
            {
                case EnumPerkType.CreateBullet:
                    _bullet.AddPerk(new CreateBulletPerk(_startOn, _startBy, 1, _perkCondition, null));
                    break;
                case EnumPerkType.CreateZone:
                    _bullet.AddPerk(new CreateZonePerk(_startOn, _startBy, 1, _perkCondition, EnumZoneTargetType.ShootInitializer, null));
                    break;
                case EnumPerkType.ModifyParameters:
                    _bullet.AddPerk(new ModifyParametersPerk(_startOn, _startBy, 1, _perkCondition, EnumTransformTargetType.BulletTransform, new List<StatusModificator>()));
                    break;
                default:
                    break;
            }
        }
    }

    void DrawUILine(Color color, int thickness = 2, int padding = 10)
    {
        Rect _rect = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        _rect.height = thickness;
        _rect.y += padding / 2;
        _rect.x -= 2;
        _rect.width += 6;
        EditorGUI.DrawRect(_rect, color);
    }
}
