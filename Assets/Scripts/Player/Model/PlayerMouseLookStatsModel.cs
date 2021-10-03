using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.Model
{
    [System.Serializable]
    public class PlayerMouseLookStatsModel
    {
        public float MouseSensitivity { get { return _mouseSensitivity; } }

        [SerializeField]
        private float _mouseSensitivity;

        public PlayerMouseLookStatsModel(float mouseSensitivity)
        {
            if (mouseSensitivity < 0.1f)
                _mouseSensitivity = 0.1f;
            else
                _mouseSensitivity = mouseSensitivity;
        }
    }
}
