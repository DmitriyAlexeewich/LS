using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeReference]
    private List<TestT> _tests = new List<TestT>();

    public void Add(TestT adding)
    {
        _tests.Add(adding);
    }
}



[CustomEditor(typeof(Test2), true)]
public class Test2Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var _target = (Test2)target;
        if (GUILayout.Button("Add TestT"))
            _target.Add(new TestT());
        if (GUILayout.Button("Add TestTInhiritor"))
            _target.Add(new TestTInhiritor());
    }
}

[Serializable]
public class TestT
{
    [SerializeField]
    protected int _test;
}

[CustomEditor(typeof(TestT), true)]
public class TestTEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }
}

[Serializable]
public class TestTInhiritor : TestT
{
    [SerializeField]
    protected int _test2;
}

[CustomPropertyDrawer(typeof(TestTInhiritor), true)]
public class TestTInhiritorEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height = 20;
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label);

        EditorGUI.BeginProperty(position, label, property);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        if (property.isExpanded)
        {

            var test1Rect = new Rect(position.x, position.y + 20f, position.width, EditorGUIUtility.singleLineHeight);
            var test2Rect = new Rect(position.x, position.y + 40f, position.width, EditorGUIUtility.singleLineHeight);

            var test1 = property.FindPropertyRelative("_test");
            var test2 = property.FindPropertyRelative("_test2");

            test1.intValue = EditorGUI.IntField(test1Rect, "test1", test1.intValue);
            test2.intValue = EditorGUI.IntField(test2Rect, "test2", test2.intValue);

        }

        position.height = EditorGUI.GetPropertyHeight(property, label, true) + 1000; 
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }
}