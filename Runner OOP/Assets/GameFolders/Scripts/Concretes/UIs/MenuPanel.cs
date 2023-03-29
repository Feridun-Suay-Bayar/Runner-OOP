using Runner.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.LoadScene();
        }
        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
        
    }
}

