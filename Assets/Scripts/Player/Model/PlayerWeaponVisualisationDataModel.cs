using UnityEngine;

namespace Assets.Scripts.Player.Model
{
    [System.Serializable]
    public class PlayerWeaponVisualisationDataModel
    {
        public Vector3 Position { get { return _Position; } }
        public Quaternion Rotation { get { return _Rotation; } }
        public float Weight { get { return _Weight; } }
        public float MaxInertiaAmount { get { return _MaxInertiaAmount; } }


        [SerializeField]
        private Vector3 _Position;
        [SerializeField]
        private Quaternion _Rotation;
        [SerializeField]
        private float _Weight;
        [SerializeField]
        private float _MaxInertiaAmount;

        public PlayerWeaponVisualisationDataModel(Vector3 NewPosition, Quaternion NewRotation, float NewWeight, float NewMaxInertiaAmount)
        {
            _Position = NewPosition;
            _Rotation = NewRotation;

            if (NewWeight > 0)
                _Weight = NewWeight;
            else
                _Weight = 0.1f;

            if (NewMaxInertiaAmount > 0f)
                _MaxInertiaAmount = NewMaxInertiaAmount;
            else
                _MaxInertiaAmount = 0;
        }
    }
}
