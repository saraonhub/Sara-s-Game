using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

namespace MyGame
{


    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;
        float timer = 0;
        bool isTimerRunning = false;
        public int starsToPass = 5;
        public int starsCollectedInLevel;
        public bool enoughStarsCollected = false;
        public TextMeshProUGUI timerUI;
        public GameObject portalOpened;

        public GameObject gameOver;
        public GameObject levelCompleted;
        public TextMeshProUGUI failReason;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        void Start()
        {
            isTimerRunning = true;
            portalOpened.SetActive(false);

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

            if ((starsCollectedInLevel >= starsToPass) && !enoughStarsCollected)
            {
                portalOpened.SetActive(true);
                enoughStarsCollected = true;
                Invoke("HideSign", 5f);
            }


        }

        void HideSign()
        {
            portalOpened.SetActive(false);
        }

        public void GameOver(string reason)
        {
            gameOver.SetActive(true);
            failReason.text = reason;
            Invoke("RestartLevel", 4f);

        }

        void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LevelFinished()
        {
            levelCompleted.SetActive(true);
            Invoke("LoadNextLevel", 4f);
        }


        void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }

}
