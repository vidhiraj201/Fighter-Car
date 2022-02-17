using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

namespace FCar.core
{
    public class GameManager : MonoBehaviour
    {
        public TextMeshProUGUI TurretsUI;        
        public TextMeshProUGUI TimerUI;
        public TextMeshProUGUI DestroyTurretsCount;
        public GameObject GameOverPanal;

        public int KilledTurretCount;
        public int MaxTimeLimit;

        public bool GameOver;


        public Color HalfTime;
        public Color CriticalTime;
        private int startMinutes;

        float currentTime;
        private int killedScore;
        void Start()
        {
            killedScore = PlayerPrefs.GetInt("Score");

            GameOverPanal.SetActive(false);
            startMinutes = HomePage.Second;
            currentTime = startMinutes;
            Application.targetFrameRate = 60;
        }

        // Update is called once per frame
        void Update()
        {
            TurretsUI.text = KilledTurretCount.ToString();

            if (currentTime <= 0)
            {
                if (KilledTurretCount > killedScore)
                {
                    PlayerPrefs.SetInt("Score", KilledTurretCount);
                    HomePage.ScoreData += PlayerPrefs.GetInt("Score");
                }

                DestroyTurretsCount.text = KilledTurretCount.ToString();
                GameOverPanal.SetActive(true);
                GameOver = true;
            }

            if(currentTime>0 && !GameOver)
                Timer();
        }

        public void Timer()
        {
            currentTime = currentTime - Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            TimerUI.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
            if(currentTime <= (startMinutes) / 2 && currentTime > (startMinutes) / 4)
            {
                TimerUI.color = HalfTime;
            }
            else if(currentTime <= (startMinutes) / 4)
            {
                TimerUI.color = CriticalTime;
            }
            else
            {
                TimerUI.color = Color.black;
            }
        }
        public void BackHomePage()
        {
            SceneManager.LoadScene(0);
        }
    }
}
