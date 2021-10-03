using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(RangeExAttribute))]
internal sealed class RangeExDrawer : PropertyDrawer
{
    private float _value;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var rangeAttribute = (RangeExAttribute)base.attribute;

        if (property.propertyType == SerializedPropertyType.Integer)
        {
            _value = EditorGUI.Slider(position, label, _value, rangeAttribute.Min, rangeAttribute.Max);

            _value = (_value / rangeAttribute.Step) * rangeAttribute.Step;
            property.floatValue = _value;
        }
        else
        {
            EditorGUI.LabelField(position, label.text, "Use Range with float or int.");
        }
    }
}