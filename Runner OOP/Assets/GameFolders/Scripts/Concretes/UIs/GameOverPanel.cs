using Runner.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.UIs
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.LoadScene("PlayScene");
            Time.timeScale = 1.0f; 
        }
        public void NoButton()
        {
            GameManager.Instance.LoadScene("Menu");
        }
    }
}

