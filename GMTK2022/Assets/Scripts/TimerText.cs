using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimerText : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    public static float _time = 0f;
    private float minutes;
    private float seconds;

    private void Update()
    {
        _time += Time.deltaTime;
        minutes = Mathf.Floor(_time / 60);
        seconds = Mathf.RoundToInt(_time % 60);
        if (seconds < 10)
        {
            _timerText.text = minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            _timerText.text = minutes.ToString() + ":" + seconds.ToString();
        }
    }
}
