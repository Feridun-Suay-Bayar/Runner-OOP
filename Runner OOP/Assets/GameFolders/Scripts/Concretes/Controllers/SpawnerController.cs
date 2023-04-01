using Runner.Enum;
using Runner.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        
        [Range(0.1f,5f)]
        [SerializeField] float _minTime = 0.1f;
        [Range(6f, 15f)]
        [SerializeField] float _maxTime = 15;
        [SerializeField] float _maxSpawnTime = 10;

        float _currentSpawnTime = 0f;

        int _index = 0;
        float _maxAddEnemyTime;

        public bool CanIncrease => _index < EnemyManager.Instance.Count;

        private void OnEnable()
        {
            GetRandomMaxTime();
        }
        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            if(_currentSpawnTime > _maxSpawnTime)
            {
                Spawn();
            }

            if (!CanIncrease) return;

            if(_maxAddEnemyTime < Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instance.AddDelayTime;
                IncreaseIndex();
            }
        }

        private void Spawn()
        {
            EnemyController _newEnemy = EnemyManager.Instance.GetPool((EnemyEnum)Random.Range(0,4));
            _newEnemy.transform.parent = this.transform;
            _newEnemy.transform.position = this.transform.position;
            _newEnemy.gameObject.SetActive(true);

            _currentSpawnTime = 0f;
            GetRandomMaxTime();
        }
        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_minTime, _maxTime);
        }
        private void IncreaseIndex()
        {
            if (CanIncrease)
            {
                _index++;
            }
        }
    }
}

