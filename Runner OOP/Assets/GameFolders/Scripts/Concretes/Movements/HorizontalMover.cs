using Runner.Abstract.Controllers;
using Runner.Abstract.Movements;
using Runner.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movements
{
    public class HorizontalMover : IMover
    {
        IEntityController _playerController;
        float _moveSpeed;
        float _moveBoundary;

        public HorizontalMover(IEntityController entityController)
        {
            _playerController = entityController;
            _moveSpeed = _playerController.MoveSpeed;
            _moveBoundary = _playerController.MoveBoundary;
        }

        public void FixedTick(float horizontal)
        {
            if (horizontal == 0) return;

            _playerController.transform.Translate(Vector3.right * Time.fixedDeltaTime * horizontal * _moveSpeed);

            float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);
            _playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y);

        }
    }
}

