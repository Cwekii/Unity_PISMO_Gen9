using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;

   [SerializeField] float startTime;
    float timer;
    int minutes;
    int seconds;



    private void Update()
    {
        //timer.text = TimeSpan.FromSeconds(Time.time).ToString(@"hh\:mm\:ss");

       TimeCounter();
    }

    private void TimeCounter()
    {
        timer = startTime - Time.time;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format($"{minutes:00}:{seconds:00}");
    }
}
