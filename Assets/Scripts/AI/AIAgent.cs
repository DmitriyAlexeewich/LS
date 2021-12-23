using Assets.Scripts.AI.Action.StartCondition;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(StatusesContainer)]
public class AIAgent : MonoBehaviour
{
    [HideInInspector]
    public Action Moved;
    public Transform SelfTransform { get { return _selfTransform; } }
    public StatusesContainer SelfStatusesContainer { get { return _statusesContainer; } }

    [SerializeReference]
    private List<ActionStartCondition> _actionStartConditions = new List<ActionStartCondition>();
    [SerializeField]
    private Transform _targetTransform;

    private StatusesContainer _statusesContainer;
    private Transform _selfTransform;

    private void Start()
    {
        _statusesContainer = this.gameObject.GetComponent<StatusesContainer>();
        _selfTransform = this.gameObject.GetComponent<Transform>();
    }

    public void Construct()
    {
        
    }
}
