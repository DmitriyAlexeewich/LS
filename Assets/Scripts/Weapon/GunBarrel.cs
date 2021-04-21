using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : MonoBehaviour
{
    BulletSpawnPoint BulletSpawnPointComponent;
    Animator AnimatorComponent;
    List<MeshRenderer> ChildObjectMeshRenders;

    public void Construct()
    {
        BulletSpawnPointComponent = this.gameObject.GetComponentInChildren<BulletSpawnPoint>();
        BulletSpawnPointComponent.Construct();

        AnimatorComponent = this.gameObject.GetComponent<Animator>();
        
    }

    public BulletSpawnPoint GetBulletSpawnPoint()
    {
        return BulletSpawnPointComponent;
    }
}
