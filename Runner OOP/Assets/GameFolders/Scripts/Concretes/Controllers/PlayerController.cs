using Runner.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _horizantalDirection = 0f;
        [SerializeField] float _movementSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] bool _isJump;

        HorizontalMover _horizontalMover;
        JumpWithRigidbody _jumpWithRigidbody;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jumpWithRigidbody= new JumpWithRigidbody(this);
        }
        private void FixedUpdate()
        {
            if (_horizontalMover != null)
            {
                _horizontalMover.TickFixed(_horizantalDirection, _movementSpeed);
            }

            if (_isJump)
            {
                _jumpWithRigidbody.TickFixed(_jumpForce);
            }
            _isJump = false;
        }
    }
}

