using Runner.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Movements
{
    public class HorizontalMover
    {
        PlayerController _playerController;
        float _moveSpeed;
        float _moveBoundary;

        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
            _moveSpeed = _playerController.MovementSpeed;
            _moveBoundary = _playerController.MoveBoundary;
        }

        public void TickFixed(float horizontal)
        {
            if (horizontal == 0) return;

            _playerController.transform.Translate(Vector3.right * Time.fixedDeltaTime * horizontal * _moveSpeed);

            float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_moveBoundary, _moveBoundary);
            _playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y);

        }
    }
}

