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
        public int Id { get { return _Id; } }
        public GunDataModel GunData { get { return _GunData; } }
        public PlayerWeaponVisualisationDataModel PlayerWeaponVisualisationData { get { return _PlayerWeaponVisualisationData; } }

        [SerializeField]
        private int _Id;
        [SerializeField]
        private GunDataModel _GunData;
        [SerializeField]
        private PlayerWeaponVisualisationDataModel _PlayerWeaponVisualisationData;

        public PlayerWeaponDataModel(int NewId, GunDataModel NewGunData, PlayerWeaponVisualisationDataModel NewPlayerWeaponVisualisationData)
        {
            _Id = NewId;
            _GunData = NewGunData;
            _PlayerWeaponVisualisationData = NewPlayerWeaponVisualisationData;
        }
    }
}
