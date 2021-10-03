using UnityEngine;

namespace Assets.Scripts.Player.Model
{
    [System.Serializable]
    public class PlayerWeaponVisualisationDataModel
    {
        public Vector3 Position { get { return _position; } }
        public Quaternion Rotation { get { return _rotation; } }
        public float Weight { get { return _weight; } }
        public float MaxInertiaAmount { get { return _maxInertiaAmount; } }


        [SerializeField]
        private Vector3 _position;
        [SerializeField]
        private Quaternion _rotation;
        [SerializeField]
        private float _weight;
        [SerializeField]
        private float _maxInertiaAmount;

        public PlayerWeaponVisualisationDataModel(Vector3 position, Quaternion rotation, float weight, float maxInertiaAmount)
        {
            _position = position;
            _rotation = rotation;

            if (weight > 0)
                _weight = weight;
            else
                _weight = 0.1f;

            if (maxInertiaAmount > 0f)
                _maxInertiaAmount = maxInertiaAmount;
            else
                _maxInertiaAmount = 0;
        }
    }
}
