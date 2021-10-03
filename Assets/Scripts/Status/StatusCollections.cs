using Assets.Scripts.Status;
using System.Collections.Generic;
using UnityEngine;

public class StatusCollections : MonoBehaviour
{

    [SerializeField]
    public List<Status> Statuses { get; private set; } = new List<Status>();

}
