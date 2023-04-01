using Runner.Abstract.Utilities;
using Runner.Controllers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Runner.Managers
{
    public class EnemyManager : SingletonMonoBehaviourObject<EnemyManager>
    {
        [SerializeField] EnemyController[] _enemyPrefabs;

        Queue<EnemyController> _enemies = new Queue<EnemyController>();

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
            for(int i = 0; i < 10; i++)
            {
                EnemyController newEnemy = Instantiate(_enemyPrefabs[Random.Range(0,_enemyPrefabs.Length)]);
                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.parent = this.transform;
                _enemies.Enqueue(newEnemy);
            }
        }

        public void SetPool(EnemyController enemyController)
        {
            enemyController.gameObject.SetActive(false);
            enemyController.transform.parent = this.transform;
            _enemies.Enqueue(enemyController);
        }

        public EnemyController GetPool()
        {
            if(_enemies.Count == 0)
            {
                InitializedPool();
            }
            return _enemies.Dequeue();
        }

    }
}

