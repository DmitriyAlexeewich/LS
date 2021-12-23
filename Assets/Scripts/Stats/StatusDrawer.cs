using Assets.Extensions;
using Assets.Scripts.Stats;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Status))]
public abstract class StatusDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Status _target = property.GetSerializedObject<Status>();        
        string _newlabel = _target.StatusType.ToString();
        if (string.IsNullOrEmpty(_newlabel))
            _newlabel = label.text;

        PersonalGUI(position, property, new GUIContent(_newlabel, label.tooltip));
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property);
    }

    public abstract void PersonalGUI(Rect position, SerializedProperty property, GUIContent label);
}