using System;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections;

namespace Assets.Extensions
{
    public static class SerializedPropertyExtensions
    {
        public static T GetSerializedObject<T>(this SerializedProperty property)
        {
            var _path = property.propertyPath.Replace(".Array.data[", "[");

            object _object = property.serializedObject.targetObject;
            var _elements = _path.Split('.');
            for (int i = 0; i < _elements.Length; i++)
            {
                var _element = _elements[i];
                if (_element.Contains("["))
                {
                    var _elementName = _element.Substring(0, _element.IndexOf("["));
                    var _index = Convert.ToInt32(_element.Substring(_element.IndexOf("[")).Replace("[", "").Replace("]", ""));
                    _object = GetValue(_object, _elementName, _index);
                }
                else
                {
                    _object = GetValue(_object, _element);
                }
            }

            return (T)_object;
        }

        public static float GetElementsHight(this SerializedProperty property)
        {
            float _height = EditorGUI.GetPropertyHeight(property);

            return _height;
        }

        private static object GetValue(object source, string name)
        {
            if (source == null)
                return null;
            var _type = source.GetType();
            var _field = _type.GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (_field == null)
            {
                var _property = _type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (_property == null)
                    return null;
                return _property.GetValue(source, null);
            }
            return _field.GetValue(source);
        }

        private static object GetValue(object source, string name, int index)
        {
            var _enumerable = GetValue(source, name) as IEnumerable;
            var _enumerator = _enumerable.GetEnumerator();
            while (index-- >= 0)
                _enumerator.MoveNext();
            return _enumerator.Current;
        }
    }
}
