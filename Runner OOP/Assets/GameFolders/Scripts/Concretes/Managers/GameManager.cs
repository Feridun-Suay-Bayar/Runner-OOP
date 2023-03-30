using Runner.Abstract.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        public event System.Action OnGameStop;
        private void Awake()
        {
            SingletonThisObject(this);
        }
        public void StopGame()
        {
            Time.timeScale = 0;
            if (OnGameStop != null)
            {
                OnGameStop();
            }
        }
        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        private IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1.0f;
            yield return SceneManager.LoadSceneAsync(sceneName);    
        }
        public void ExitGame()
        {
            Debug.Log("Exit has been clicked.");
            Application.Quit();
        }
    }
}

