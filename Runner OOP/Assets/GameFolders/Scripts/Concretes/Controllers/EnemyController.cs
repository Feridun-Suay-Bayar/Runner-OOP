using Runner.Abstract.Controllers;
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

        VerticalMover verticalMover;
        float _currentLifeTime = 0f;


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
            verticalMover.FixedTick();
        }
        private void KillYourself()
        {
            EnemyManager.Instance.SetPool(this);
        }
    }
}

