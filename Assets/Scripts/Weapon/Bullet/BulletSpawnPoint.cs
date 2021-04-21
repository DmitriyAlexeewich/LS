using UnityEngine;

public class BulletSpawnPoint : MonoBehaviour
{
    Transform BulletSpawnPointTransformComponent;

    public void Construct()
    {
        BulletSpawnPointTransformComponent = this.gameObject.GetComponent<Transform>();
    }

    public Transform GetBulletSpawnPointTransform()
    {
        return BulletSpawnPointTransformComponent;
    }
}
