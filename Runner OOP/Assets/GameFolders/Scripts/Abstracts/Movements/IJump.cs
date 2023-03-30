using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Abstract.Movements
{
    public interface IJump 
    {
        void FixedTick(float jumpForce);
        bool CanJump { get; }
    }
}

