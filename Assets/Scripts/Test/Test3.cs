using UnityEngine;

public class Test3 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.contacts[0].otherCollider.gameObject);
    }
}