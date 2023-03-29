using Runner.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movements
{
    public class VerticalMover
    {
        EnemyController _enemyController;
        float _moveSpeed = 7;

        public VerticalMover(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _moveSpeed = _enemyController.Speed;
        }
        public void FixedTick(float vertical = 1)
        {
            _enemyController.transform.Translate(Vector3.back * vertical * Time.fixedDeltaTime * _moveSpeed);
        }
        
    }
}

