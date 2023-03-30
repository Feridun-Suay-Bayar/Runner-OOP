using Runner.Abstract.Controllers;
using Runner.Abstract.Movements;
using Runner.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movements
{
    public class VerticalMover : IMover
    {
        IEntityController _entityController;
        float _moveSpeed = 7;

        public VerticalMover(IEntityController entityController)
        {
            _entityController = entityController;
            //_moveSpeed = _entityController.Speed;
        }
        public void FixedTick(float vertical = 1)
        {
            _entityController.transform.Translate(Vector3.back * vertical * Time.fixedDeltaTime * _moveSpeed);
        }
        
    }
}

