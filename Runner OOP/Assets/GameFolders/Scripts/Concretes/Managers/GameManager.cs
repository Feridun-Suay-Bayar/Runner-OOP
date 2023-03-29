using Runner.Abstract.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Managers
{
    public class GameManager : SingletonMonoBehaviourObject<GameManager>
    {
        private void Awake()
        {
            SingletonThisObject(this);
        }
        public void StopGame()
        {
            Time.timeScale = 0;
        }
        public void LoadScene()
        {
            Debug.Log("Start has been clicked.");
        }
        public void ExitGame()
        {
            Debug.Log("Exit has been clicked.");
            Application.Quit();
        }
    }
}

