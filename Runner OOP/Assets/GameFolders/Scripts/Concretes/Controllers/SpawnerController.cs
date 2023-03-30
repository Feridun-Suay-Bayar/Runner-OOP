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
            EnemyController _newEnemy = EnemyManager.Instance.GetPool();
            _newEnemy.transform.parent = this.transform;
            _newEnemy.transform.position = this.transform.position;
            _newEnemy.gameObject.SetActive(true);
            GetRandomMaxTime();
        }
        private void GetRandomMaxTime()
        {
            _maxSpawnTime = Random.Range(_minTime, _maxTime);
        }
    }
}

