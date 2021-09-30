using System;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Perk.Model
{
    [Serializable]
    public class StartPerkDirectionModel
    {
        public Vector3 SpawnPoint { get { return _spawnPoint; } }
        public float Distance { get { return _distance; } }
        public int SpawnCount { get { return _spawnCount; } }


        [SerializeField]
        private Vector3 _spawnPoint = Vector3.zero;
        [SerializeField, Min(0)]
        private float _distance = 0f;
        [SerializeField, Min(1)]
        private int _spawnCount = 1;
    }
}
