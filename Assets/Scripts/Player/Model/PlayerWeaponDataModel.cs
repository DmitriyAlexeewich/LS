using Assets.Scripts.Weapon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.Model
{
    [System.Serializable]
    public class PlayerWeaponDataModel
    {
        public int Id { get { return _id; } }
        public GunDataModel GunData { get { return _gunData; } }
        public PlayerWeaponVisualisationDataModel PlayerWeaponVisualisationData { get { return _playerWeaponVisualisationData; } }

        [SerializeField]
        private int _id;
        [SerializeField]
        private GunDataModel _gunData;
        [SerializeField]
        private PlayerWeaponVisualisationDataModel _playerWeaponVisualisationData;

        public PlayerWeaponDataModel(int id, GunDataModel gunData, PlayerWeaponVisualisationDataModel playerWeaponVisualisationData)
        {
            _id = id;
            _gunData = gunData;
            _playerWeaponVisualisationData = playerWeaponVisualisationData;
        }
    }
}
