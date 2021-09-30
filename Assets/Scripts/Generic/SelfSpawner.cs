using UnityEngine;

public class SelfSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject _object;


    public void SpawnItselfByPoint(Vector3 point)
    {
        Instantiate(_object, point, new Quaternion());
    }

}
