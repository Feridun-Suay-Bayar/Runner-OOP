using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] EnemyController _enemyPrefab;
        [Range(0.1f,5f)]
        [SerializeField] float _minTime = 0.1f;
        [Range(6f, 15f)]
        [SerializeField] float _maxTime = 15;
        [SerializeField] float _maxSpawnTime = 10;

        float _currentSpawnTime = 0f;

        private void OnEnable()
        {
            GetRandomMaxTime();
        }
        private void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            if(_currentSpawnTime > _maxSpawnTime)
            {
                _currentSpawnTime = 0;
                Spawn();
            }
        }

        private void Spawn()
        {
            EnemyController _newEnemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            _newEnemy.transform.parent = this.transform;

            GetRandomMaxTime();
        }
        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_minTime, _maxTime);
        }
    }
}

