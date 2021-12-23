using Assets.Scripts.Weapon.Ammo.Perk.CreateObject.Inheritors.Inheritors.CreateZone;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CreateZonePerk))]
public class CreateZonePerkDrawer : PerkDrawer
{
    protected override void PersonalGUI(Rect position, SerializedProperty property, string tooltip, EnumStartOn startOn, string instantText)
    {
        EditorGUI.PropertyField(position, property, new GUIContent($"CreateZonePerk [{startOn}]{instantText}"), true);
    }
}
