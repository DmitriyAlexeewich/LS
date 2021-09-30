using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon.Model
{
    [System.Serializable]
    public class GunShootPointDataModel
    {

        public int Id { get { return _id; } }
        public float Distance { get { return _distance; } }

        [SerializeField]
        private int _id;
        [SerializeField]
        private float _distance;

        public GunShootPointDataModel(int id, float distance)
        {
            _id = id;
            _distance = distance;
        }
    }
}
