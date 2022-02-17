using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace FCar.core
{
    public class HomePage : MonoBehaviour
    {
        public static int ScoreData;

        public static int Second;
        public static int CarSelection;
        public TextMeshProUGUI Score;

        [Header("Secong Buttons")]
        public Button _30Sec;
        public Button _60Sec;
        public Color sNoClick;
        public Color sOnClick;

        [Header("Car Selection")]
        public Button _CarID0;
        public Button _CarID1;
        public Button _CarID2;
        public Button _CarID3;
        public Color cNoClick;
        public Color cOnClick;

        private bool CarSelected;
        private bool TimeSelected;

        private void Start()
        {
            CarSelected = false;
            TimeSelected = false;
        }
        private void Update()
        {
            Score.text = ScoreData.ToString();
            ScoreData = PlayerPrefs.GetInt("Score");
        }
        public void CarSelect(int i)
        {
            CarSelected = true;
            CarSelection = i;
            if (i == 0)
            {
                _CarID0.image.color = cOnClick;
                _CarID1.image.color = cNoClick;
                _CarID2.image.color = cNoClick;
                _CarID3.image.color = cNoClick;
            }
            if (i == 1)
            {
                _CarID0.image.color = cNoClick;
                _CarID1.image.color = cOnClick;
                _CarID2.image.color = cNoClick;
                _CarID3.image.color = cNoClick;
            }
            if (i == 2)
            {
                _CarID0.image.color = cNoClick;
                _CarID1.image.color = cNoClick;
                _CarID2.image.color = cOnClick;
                _CarID3.image.color = cNoClick;
            }
            if (i == 3)
            {
                _CarID0.image.color = cNoClick;
                _CarID1.image.color = cNoClick;
                _CarID2.image.color = cNoClick;
                _CarID3.image.color = cOnClick;
            }

        }
        public void SecondData(int i)
        {
            TimeSelected = true;
            Second = i;
            if (i == 30)
            {
                _30Sec.image.color = sOnClick;
                _60Sec.image.color = sNoClick;
            }
            if (i == 60)
            {
                _30Sec.image.color = sNoClick;
                _60Sec.image.color = sOnClick;
            }
        }
        public void loadScene()
        {
            if(TimeSelected&&CarSelected)
                SceneManager.LoadScene(1);
        }
    }
}
