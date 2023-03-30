using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Abstract.Movements
{
    public interface IMover 
    {
        void FixedTick(float direction);
    }

}

