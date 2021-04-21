using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player.Model
{
    [System.Serializable]
    public class PlayerMovementStatsModel
    {
        public float Speed;
        public float Gravity;
        public float JumpHeight;
        public int MaxJumps;
        public float DashDistance;
        public float DashSpeed;
    }
}
