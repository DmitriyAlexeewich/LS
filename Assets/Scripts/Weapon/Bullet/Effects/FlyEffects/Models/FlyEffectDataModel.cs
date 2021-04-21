using Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Enumerators;

namespace Assets.Scripts.Weapon.Bullet.Effects.FlyEffects.Models
{
    [System.Serializable]
    public class FlyEffectDataModel
    {
        public EnumFlyEffectType EffectType;
        public float TimeUpdate;

        public BulletPathtDataModel BulletPathFlyEffect;
        public BulletDamageDataModel BulletDamageUpFlyEffect;
        public BulletDangerZoneDataModel BulletDangerZoneFlyEffect;

        public BulletBlowDataModel BulletBlowFlyEffect;
        public BulletChangeMagicTypeByTimeDataModel BulletChangeMagicTypeByTimeEffect;
        public BulletCloneDataModel BulletCloneFlyEffect;



        public FlyEffectDataModel(FlyEffectDataModel Other)
        {
            EffectType = Other.EffectType;
            BulletPathFlyEffect = Other.BulletPathFlyEffect;
            BulletDamageUpFlyEffect = Other.BulletDamageUpFlyEffect;
            BulletCloneFlyEffect = Other.BulletCloneFlyEffect;
            BulletBlowFlyEffect = Other.BulletBlowFlyEffect;
            BulletDangerZoneFlyEffect = Other.BulletDangerZoneFlyEffect;
            BulletChangeMagicTypeByTimeEffect = Other.BulletChangeMagicTypeByTimeEffect;
        }
    }
}
