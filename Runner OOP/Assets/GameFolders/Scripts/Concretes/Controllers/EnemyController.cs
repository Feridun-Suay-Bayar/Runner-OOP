using Runner.Abstract.Controllers;
using Runner.Enum;
using Runner.Managers;
using Runner.Movements;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        [SerializeField] float _maxLifeTime = 10f;
        [SerializeField] EnemyEnum _enemyEnum;

        VerticalMover verticalMover;
        float _currentLifeTime = 0f;

        public EnemyEnum EnemyEnum => _enemyEnum;

        private void Awake()
        {
            verticalMover = new VerticalMover(this);
        }
        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if(_currentLifeTime > _maxLifeTime)
            {
                _currentLifeTime = 0f;
                KillYourself();
            }
        }

        private void FixedUpdate()
        {
            verticalMover.FixedTick(1f);
        }
        private void KillYourself()
        {
            EnemyManager.Instance.SetPool(this);
        }
        public void SetMoveSpeed(float movementSpeed)
        {
            if (_movementSpeed > movementSpeed) return;

            _movementSpeed = movementSpeed;
        }
        
    }
}

