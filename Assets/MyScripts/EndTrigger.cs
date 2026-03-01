using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame
{


    public class EndTrigger : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {

            Debug.Log("Level Finished!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


}