using Assets.Scripts.Stats.Inheritors.NonModifiableStatus;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(NonModifableStatus), true)]
public class NonModifableStatusDrawer : StatusDrawer
{
    public override void PersonalGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property);
    }
}
