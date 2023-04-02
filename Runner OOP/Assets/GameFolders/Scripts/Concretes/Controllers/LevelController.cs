using Runner.Managers;
using Runner.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Controllers
{
    public class LevelController : MonoBehaviour
    {
        LevelDifficultyData levelDifficultyData = GameManager.Instance.LevelDifficultyData;

        private void Awake()
        {
            levelDifficultyData = GameManager.Instance.LevelDifficultyData;
        }
        private void Start()
        {
            Instantiate(levelDifficultyData.FloorPrefab);
            Instantiate(levelDifficultyData.SpawnerPrefab);
            RenderSettings.skybox = levelDifficultyData.SkyboxMaterial;
            EnemyManager.Instance.SetMoveSpeed(levelDifficultyData.MoveSpeed);
            EnemyManager.Instance.SetAddDelayTime(levelDifficultyData.AddDelayTime);
        }
    }
}

