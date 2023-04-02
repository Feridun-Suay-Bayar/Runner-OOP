using Runner.Abstract.Utilities;
using Runner.Controllers;
using Runner.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Runner.Managers
{
    public class EnemyManager : SingletonMonoBehaviourObject<EnemyManager>
    {
        [SerializeField] private float _addDelayTime;
        [SerializeField] EnemyController[] _enemyPrefabs;

        float _movementSpeed;

        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();
        public float AddDelayTime => _addDelayTime;

        public int Count => _enemyPrefabs.Length;

        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
            InitializedPool();
        }

        private void InitializedPool()
        {
            Queue<EnemyController> enemyControllers= new Queue<EnemyController>();
            for (int i = 0 ;i<_enemyPrefabs.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i]);
                    newEnemy.gameObject.SetActive(false);
                    newEnemy.transform.parent = this.transform;
                    enemyControllers.Enqueue(newEnemy);
                }
                _enemies.Add((EnemyEnum)i, enemyControllers);
            }
            
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;

            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyEnum];
            enemyControllers.Enqueue(enemyController);
        }

        public EnemyController GetPool(EnemyEnum enemyEnum)
        {
            Queue<EnemyController> enemyControllers = _enemies[enemyEnum];

            if (enemyControllers.Count == 0)
            {
                for(int i = 0; i < 2; i++)
                {
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyEnum]);
                    newEnemy.gameObject.SetActive(false);
                    enemyControllers.Enqueue(newEnemy);
                }
            }
            EnemyController enemyController = enemyControllers.Dequeue();
            enemyController.SetMoveSpeed(_movementSpeed);
            return enemyController;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            _movementSpeed = moveSpeed;
        }
        public void SetAddDelayTime(float addDelayTime)
        {
            _addDelayTime = addDelayTime;
        }
    }
}

