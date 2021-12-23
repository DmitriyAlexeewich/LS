using Assets.Extensions;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator;
using Assets.Scripts.Weapon.Ammo.Perk.Inheritors.ModifyParameters;
using Assets.Scripts.Weapon.Ammo.Perk.Model.Enumerators;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ModifyParametersPerk))]
public class ModifyParameterPerkDrawer : PerkDrawer
{

    private UIModificatorConstructor uIModificatorConstructor = new UIModificatorConstructor();
    private int _height = 180;

    protected override void PersonalGUI(Rect position, SerializedProperty property, string tooltip, EnumStartOn startOn, string instantText)
    {
        EditorGUI.PropertyField(position, property, new GUIContent($"ModifyParameterPerk [{startOn}]{instantText}"), true);

        if (property.isExpanded)
        {
            ModifyParametersPerk _target = property.GetSerializedObject<ModifyParametersPerk>();
            uIModificatorConstructor.AddModificator(position, property, _height, _target);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property) + _height;
    }
}
