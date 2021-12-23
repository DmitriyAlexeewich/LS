using Assets.Scripts.Stats.Enumerators;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StatusesContainer), true)]
public class StatusesContainerEditor : Editor
{

    private EnumStatusType _statusType;
    private bool _isModifiable = true;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        StatusesContainer _statusesContainer = (StatusesContainer)target;

        _statusType = (EnumStatusType)EditorGUILayout.EnumPopup("Status type", _statusType);
        _isModifiable = EditorGUILayout.Toggle("Is Modifiable", _isModifiable);

        if (GUILayout.Button("Add status"))
            _statusesContainer.AddStatus(_statusType, _isModifiable);
    }
}
