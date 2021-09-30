using UnityEngine;

namespace Assets.Scripts.Weapon.Ammo.Models
{
    public class BulletEventArgs
    {
        public Transform ShootInitializerTransform { get; private set; }
        public Transform BulletTransform { get; private set; }
        public Transform HitObjectTransform { get; private set; }
        public Vector3 DestinationPoint { get; private set; }

        public BulletEventArgs(Transform shootInitializerTransform, Transform bulletTransform, Vector3 destinationPoint)
        {
            ShootInitializerTransform = shootInitializerTransform;
            BulletTransform = bulletTransform;
            DestinationPoint = destinationPoint;
            HitObjectTransform = null;
        }

        public BulletEventArgs(Transform shootInitializerTransform, Transform bulletTransform, Vector3 destinationPoint, Transform hitObjectTransform)
        {
            ShootInitializerTransform = shootInitializerTransform;
            BulletTransform = bulletTransform;
            DestinationPoint = destinationPoint;
            HitObjectTransform = hitObjectTransform;
        }
    }
}
