using UnityEngine;
using TMPro;

namespace MyGame
{


    public class GameManager : MonoBehaviour
    {
        float timer = 0;
        bool isTimerRunning = false;
        public TextMeshProUGUI timerUI;

        void Start()
        {
            isTimerRunning = true;
        }

        void Update()
        {
            if (isTimerRunning)
            {
                timer += Time.deltaTime;
                int minutes = Mathf.FloorToInt(timer / 60);
                int seconds = Mathf.FloorToInt(timer % 60);

                timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }

        }
    }

}
