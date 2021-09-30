using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class TimeWaiter
{
    [HideInInspector]
    public Action TimerStarted { get; protected set; }
    [HideInInspector]
    public Action TimerEnded { get; protected set; }
    [HideInInspector]
    public Action<int> TimerChanged { get; protected set; }
    [HideInInspector]
    public Action TimerCanceled { get; protected set; }

    [SerializeField, Min(1)]
    [Tooltip("Time in miliseconds")]
    protected int _waitingTime = 1;

    private bool _isCouting = false;
    private bool _isQueue = false;
    private bool _isCanceled = false;

    public void SetWaitingTime(int waitingTime)
    {
        if (waitingTime >= 0)
            _waitingTime = waitingTime;
        else
            _waitingTime = 1;
    }

    public void ModifyWaitingTime(int modificator, bool isMultiply)
    {
        if (isMultiply)
        {
            if (modificator >= 1)
                _waitingTime *= modificator;
        }
        else if(_waitingTime + modificator >= 1)
            _waitingTime += modificator;
    }

    public void SetIsQueue(bool isQueue)
    {
        _isQueue = isQueue;
    }

    public void SetIsCanceled(bool isCanceled)
    {
        if (_isQueue)
        {
            _isCanceled = isCanceled;
            if (_isCanceled)
                TimerCanceled?.Invoke();
        }
    }

    public void Start()
    {
        if (!_isCouting)
        {
            TimerStarted?.Invoke();
            Counting();
        }
    }

    public void Destroy()
    {
        TimerStarted = null;
        TimerEnded = null;
        TimerChanged = null;
        TimerCanceled = null;
    }

    private async void Counting()
    {
        SetIsCouting(true);
        for (int i = 0; (i < _waitingTime) && (!_isCanceled); i += 10)
        {
            await Task.Delay(10);
            TimerChanged?.Invoke(i);
        }
        if(!_isCanceled)
            TimerEnded?.Invoke();
        SetIsCouting(false);
    }

    private void SetIsCouting(bool isCouting)
    {
        _isCouting = isCouting;
        if (!_isQueue)
            _isCouting = false;

    }
}
