using Runner.Abstract.Inputs;
using Runner.Inputs;
using Runner.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

        IInputReader _input;
        float _horizontal;
        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jumpWithRigidbody= new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }
        private void Update()
        {
            _horizontal = _input.Horizontal;
        }
        private void FixedUpdate()
        {
            if (_horizontalMover != null)
            {
                _horizontalMover.TickFixed(_horizontal, _movementSpeed);
            }

            if (_isJump)
            {
                _jumpWithRigidbody.TickFixed(_jumpForce);
            }
            _isJump = false;
        }
    }
}

