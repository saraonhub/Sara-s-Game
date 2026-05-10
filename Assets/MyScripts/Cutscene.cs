using MyGame;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public GameObject[] scenes;
    public float timeBetweenFrames = 3f;
    int currentIndex = 0;
    float timer = 0;
    bool finished = false;
    void Start()
    {
        if (scenes.Length == 0 || finished) return;
        foreach (GameObject scene in scenes)
        {
            scene.SetActive(false);
        }

        scenes[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (scenes.Length == 0 || finished) return;

        timer += Time.deltaTime;

        if (timer > timeBetweenFrames)
        {
            PlayCutscene();
            timer = 0;
        }

    }

    void PlayCutscene()
    {
        scenes[currentIndex].SetActive(false);
        currentIndex++;
        if (currentIndex == scenes.Length)
        {
            finished = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }
        scenes[currentIndex].SetActive(true);
    }
}
