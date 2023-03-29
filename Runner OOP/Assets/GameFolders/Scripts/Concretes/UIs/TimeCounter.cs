using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runner.UIs
{
    public class TimeCounter : MonoBehaviour
    {
        TMP_Text text;
        float _currentTime = 0;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }
        private void Update()
        {
            _currentTime+= Time.deltaTime;
            text.text = _currentTime.ToString("0");
        }
    }
}

