using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.Model
{
    [System.Serializable]
    public class PlayerMovementStatsModel
    {
        public float Speed { get { return _speed; } }
        public float Gravity { get { return _gravity; } }
        public float JumpHeight { get { return _jumpHeight; } }
        public int MaxJumps { get { return _maxJumps; } }
        public float DashDistance { get { return _dashDistance; } }
        public float DashSpeed { get { return _dashSpeed; } }

        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _gravity;
        [SerializeField]
        private float _jumpHeight;
        [SerializeField]
        private int _maxJumps;
        [SerializeField]
        private float _dashDistance;
        [SerializeField]
        private float _dashSpeed;

        public PlayerMovementStatsModel(float speed, float gravity, float jumpHeight, int maxJumps, float dashDistance, float dashSpeed)
        {
            _speed = speed;
            if (_speed < 0f)
                _speed = 0f;
            
            _gravity = gravity;
            
            _jumpHeight = jumpHeight;
            if (_jumpHeight < 0f)
                _jumpHeight = 0f;

            _maxJumps = maxJumps;
            if (_maxJumps < 0)
                _maxJumps = 0;

            _dashDistance = dashDistance;
            if (_dashDistance < 0f)
                _dashDistance = 0f;

            _dashSpeed = dashSpeed;
            if (_dashSpeed < 1f)
                _dashSpeed = 1f;
        }
    }
}
