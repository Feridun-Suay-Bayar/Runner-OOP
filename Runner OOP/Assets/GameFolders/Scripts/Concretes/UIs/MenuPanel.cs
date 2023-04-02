using Runner.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void SelectAndStartButton(int index)
        {
            GameManager.Instance.LevelDifficultyIndex = index;
            GameManager.Instance.LoadScene("PlayScene");
        }
        public void ExitButton()
        {
            GameManager.Instance.ExitGame();
        }
        
    }
}

