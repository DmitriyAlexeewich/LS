using Assets.Scripts.Weapon.Ammo.Perk;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Perk))]
public abstract class PerkDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty _startOnProperty = property.FindPropertyRelative("_startOn");
        SerializedProperty _perkConditionProperty = property.FindPropertyRelative("_perkCondition");

        EnumStartOn _startOn = (EnumStartOn)_startOnProperty.intValue;
        SerializedProperty _activationTime = _perkConditionProperty.FindPropertyRelative("_activationTime");

        string _instantText = " [StartByTime]";
        if (_activationTime == null)
            _instantText = " [Instant]";
        
        PersonalGUI(position, property, label.tooltip, _startOn, _instantText);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property);
    }

    protected abstract void PersonalGUI(Rect position, SerializedProperty property, string tooltip, EnumStartOn startOn, string instantText);
}
