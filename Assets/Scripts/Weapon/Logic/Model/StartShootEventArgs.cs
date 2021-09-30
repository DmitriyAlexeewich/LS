using Assets.Scripts.Weapon.Model.Enumerators;

namespace Assets.Scripts.Weapon.Logic.Model
{
    public class StartShootEventArgs
    {
        public bool isRealize { get; private set; }
        public EnumGunModeType GunModeType { get; private set; }

        public StartShootEventArgs(bool isRealizeFlag, EnumGunModeType gunModeType)
        {
            isRealize = isRealizeFlag;
            GunModeType = gunModeType;
        }
    }
}
