using Assets.Scripts.Weapon.Ammo.Models;
using Assets.Scripts.Weapon.Model.Enumerators;
using System.Collections.Generic;

namespace Assets.Scripts.Weapon.Model
{
    public class GunCannonDataModel
    {
        public int Id { get; }
        public EnumGunShootTriggerType GunShootTriggerType { get; }
        public int DelayBetweenShoot { get; }
        public BulletDataModel BulletData { get; }
        public List<GunShootPointDataModel> GunShootPointsData { get; }
        public List<GunCannonDataModel> ChildGunCannonsData { get; }
    }
}
