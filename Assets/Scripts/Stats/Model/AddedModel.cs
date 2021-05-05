using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Stats.Model
{
    [System.Serializable]
    public class AddedModel
    {
        public int Id { get { return _Id; } }
        public float Added { get { return _Added; } }


        [SerializeField]
        private int _Id;
        [SerializeField]
        private float _Added;

        public AddedModel(int NewId, float NewPercentageFactor, float? NewOriginalValue = null)
        {
            if (NewId >= 0)
                _Id = NewId;
            if (NewPercentageFactor > 0f)
                _Added = NewPercentageFactor;
            else
                _Added = 0;
        }
    }
}
