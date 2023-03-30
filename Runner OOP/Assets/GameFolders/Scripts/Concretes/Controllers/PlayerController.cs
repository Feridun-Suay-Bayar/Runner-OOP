using Runner.Abstract.Controllers;
using Runner.Abstract.Inputs;
using Runner.Abstract.Movements;
using Runner.Inputs;
using Runner.Managers;
using Runner.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner.Controllers
{
    public class PlayerController : MyCharacterController, IEntityController
    {
        
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] bool _isJump;
        bool _isDead = false;

        IMover _mover;
        IJump _jumpWithRigidbody;



        IInputReader _input;


        float _horizontal;
        private void Awake()
        {
            _mover = new HorizontalMover(this);
            _jumpWithRigidbody= new JumpWithRigidbody(this);
            _input = new InputReader(GetComponent<PlayerInput>());
        }
        private void Update()
        {
            if (_isDead) return;

            _horizontal = _input.Horizontal;

            if (_input.IsJump)
            {
                _isJump = true;
            }
        }
        private void FixedUpdate()
        {
            if (_mover != null && !_jumpWithRigidbody.CanJump)
            {
                _mover.FixedTick(_horizontal);
            }

            if (_isJump)
            {
                _jumpWithRigidbody.FixedTick(_jumpForce);
            }
            _isJump = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
           
        }
        private void OnTriggerEnter(Collider other)
        {
            IEntityController entityController = other.GetComponent<IEntityController>();

            if (entityController != null)
            {
                _isDead= true;
                GameManager.Instance.StopGame();
            }
        }
    }
}

