using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(CustomListItemNameAttribute))]
public class CustomListItemName : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    protected virtual CustomListItemNameAttribute Atribute
    {
        get { return (CustomListItemNameAttribute)attribute; }
    }
    SerializedProperty _titleNameProp;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string _fullPathName = property.propertyPath + "." + Atribute.Varname;
        _titleNameProp = property.serializedObject.FindProperty(_fullPathName);
        string _newlabel = GetTitle();
        if (string.IsNullOrEmpty(_newlabel))
            _newlabel = label.text;

        EditorGUI.PropertyField(position, property, new GUIContent(_newlabel, label.tooltip), true);
    }
    private string GetTitle()
    {
        switch (_titleNameProp.propertyType)
        {
            case SerializedPropertyType.Generic:
                break;
            case SerializedPropertyType.Integer:
                return _titleNameProp.intValue.ToString();
            case SerializedPropertyType.Boolean:
                return _titleNameProp.boolValue.ToString();
            case SerializedPropertyType.Float:
                return _titleNameProp.floatValue.ToString();
            case SerializedPropertyType.String:
                return _titleNameProp.stringValue;
            case SerializedPropertyType.Color:
                return _titleNameProp.colorValue.ToString();
            case SerializedPropertyType.ObjectReference:
                return _titleNameProp.objectReferenceValue.ToString();
            case SerializedPropertyType.LayerMask:
                break;
            case SerializedPropertyType.Enum:
                return _titleNameProp.enumNames[_titleNameProp.enumValueIndex];
            case SerializedPropertyType.Vector2:
                return _titleNameProp.vector2Value.ToString();
            case SerializedPropertyType.Vector3:
                return _titleNameProp.vector3Value.ToString();
            case SerializedPropertyType.Vector4:
                return _titleNameProp.vector4Value.ToString();
            case SerializedPropertyType.Rect:
                break;
            case SerializedPropertyType.ArraySize:
                break;
            case SerializedPropertyType.Character:
                break;
            case SerializedPropertyType.AnimationCurve:
                break;
            case SerializedPropertyType.Bounds:
                break;
            case SerializedPropertyType.Gradient:
                break;
            case SerializedPropertyType.Quaternion:
                break;
            default:
                break;
        }
        return "";
    }
}
