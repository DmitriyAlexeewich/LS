using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Stats.Model
{
    [System.Serializable]
    public class AddedModel
    {
        public int Id { get { return _Id; } }
        public float Added { get { return _Added; } }
        public float OriginalValue { get { return _OriginalValue; } }


        [SerializeField]
        private int _Id;
        [SerializeField]
        private float _Added;
        [SerializeField]
        private float _OriginalValue;

        public AddedModel(int NewId, float NewPercentageFactor, float? NewOriginalValue = null)
        {
            if (NewId >= 0)
                _Id = NewId;
            if (NewPercentageFactor > 0f)
                _Added = NewPercentageFactor;
            else
                _Added = 0;
            if (NewOriginalValue != null)
                _OriginalValue = NewOriginalValue.Value;
        }
    }
}
