using Assets.Scripts.Stats.Field;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FieldContainer), true)]
public class FieldContainerDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        int _indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;


        Rect _fieldValueNameRect = new Rect(position.x, position.y, 45, position.height);
        Rect _fieldValueRect = new Rect(position.x + 50, position.y, 60, position.height);

        Rect _minNameRect = new Rect(position.x + 115, position.y, 25, position.height);
        Rect _minRect = new Rect(position.x + 145, position.y, 60, position.height);

        Rect _maxNameRect = new Rect(position.x + 210, position.y, 25, position.height);
        Rect _maxRect = new Rect(position.x + 240, position.y, 60, position.height);

        SerializedProperty _fieldValueProperty = property.FindPropertyRelative("_fieldValue");
        SerializedProperty _minProperty = property.FindPropertyRelative("_min");
        SerializedProperty _maxProperty = property.FindPropertyRelative("_max");

        EditorGUI.LabelField(_fieldValueNameRect, "Current");
        EditorGUI.PropertyField(_fieldValueRect, _fieldValueProperty, GUIContent.none);

        EditorGUI.LabelField(_minNameRect, "Min");
        EditorGUI.PropertyField(_minRect, _minProperty, GUIContent.none);

        EditorGUI.LabelField(_maxNameRect, "Max");
        EditorGUI.PropertyField(_maxRect, _maxProperty, GUIContent.none);



        EditorGUI.indentLevel = _indent;

        EditorGUI.EndProperty();
    }
}
