using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimeBehavior : MonoBehaviour
{
    public static event Action OnGameFinished = delegate { };
    public UnityEvent Finished;
    public UnityEvent Restart;



    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI countDownText;


    public float timer = 60f;
    public  float lapse = 10f;

    private float restartTimer=5f; 




    void Update()
    {
        timerText.text = $"{System.Math.Round(timer, 0)}";
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            lapse -= Time.deltaTime;

            if (lapse < 0f)
            {
                OnGameFinished();
                lapse = 10f;
            }
        }
        else
        {
            Time.timeScale = 0;
            Finished.Invoke();            
            
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        timer = 60f;
        lapse= 10f;
        Debug.Log("Se reseteaaaa :DD");
        Restart.Invoke();

    }
    public void CountDownToRestartGame()
    {
        countDownText.text = $" Play Again in: {System.Math.Round(restartTimer, 0)}";
        restartTimer -= Time.deltaTime;
    }
}
