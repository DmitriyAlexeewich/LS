using System;
using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Models
{
    [Serializable]
    public class BulletDataModel
    {
        public int Distance { get { return _distance; } }

        [SerializeField]
        private int _distance;
    }
}
