using Assets.Extensions;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus;
using Assets.Scripts.Stats.Inheritors.ModifiableStatus.Modificator;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ModifiableStatus), true)]
public class ModifiableStatusDrawer : StatusDrawer
{

    private UIModificatorConstructor uIModificatorConstructor = new UIModificatorConstructor();
    private int _height = 200;

    public override void PersonalGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property, new GUIContent(label.text + "  [Modifiable]", label.tooltip), true);

        if (property.isExpanded)
        {
            ModifiableStatus _target = property.GetSerializedObject<ModifiableStatus>();
            uIModificatorConstructor.AddModificator(position, property, _height, _target);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property) + _height;
    }

}
