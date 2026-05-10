using UnityEngine;

public class Credits : MonoBehaviour
{
    void Update()
    {
        Invoke("QuitGame", 150f);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quit");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
