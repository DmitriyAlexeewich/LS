using UnityEngine;

public class GunMuzzleFlashLight : MonoBehaviour
{
    Light ShootLightComponent;

    public void Construct()
    {
        ShootLightComponent = this.gameObject.GetComponent<Light>();
    }

    public Light GetShootLight()
    {
        return ShootLightComponent;
    }
}
