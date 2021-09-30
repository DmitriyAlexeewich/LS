using UnityEngine;

public class GunShootVectorPoint : MonoBehaviour
{
    public Transform Point { get; private set; }

    private void Start()
    {
        Point = this.gameObject.GetComponent<Transform>();
    }
}