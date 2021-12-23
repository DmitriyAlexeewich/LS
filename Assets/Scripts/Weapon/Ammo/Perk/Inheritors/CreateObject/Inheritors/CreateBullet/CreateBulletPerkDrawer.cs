using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.CreateObject.Inheritors.CreateBullet;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CreateBulletPerk))]
public class CreateBulletPerkDrawer : PerkDrawer
{
    protected override void PersonalGUI(Rect position, SerializedProperty property, string tooltip, EnumStartOn startOn, string instantText)
    {
        EditorGUI.PropertyField(position, property, new GUIContent($"CreateBullet [{startOn}]{instantText}"), true);
    }
}
