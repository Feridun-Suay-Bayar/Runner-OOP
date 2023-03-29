using Runner.Abstract.Inputs;
using Runner.Inputs;
using Runner.Managers;
using Runner.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runner.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _moveBoundary = 4f;
        [SerializeField] float _movementSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] bool _isJump;
        bool _isDead = false;

        HorizontalMover _horizontalMover;
        JumpWithRigidbody _jumpWithRigidbody;

        public float MovementSpeed => _movementSpeed;
        public float MoveBoundary => _moveBoundary;

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
            if (_isDead) return;

            _horizontal = _input.Horizontal;

            if (_input.IsJump)
            {
                _isJump = true;
            }
        }
        private void FixedUpdate()
        {
            if (_horizontalMover != null && !_jumpWithRigidbody.CanJump)
            {
                _horizontalMover.TickFixed(_horizontal);
            }

            if (_isJump)
            {
                _jumpWithRigidbody.TickFixed(_jumpForce);
            }
            _isJump = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
           
        }
        private void OnTriggerEnter(Collider other)
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();

            if (enemyController != null)
            {
                _isDead= true;
                GameManager.Instance.StopGame();
            }
        }
    }
}

