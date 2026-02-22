using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Level Finished!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


