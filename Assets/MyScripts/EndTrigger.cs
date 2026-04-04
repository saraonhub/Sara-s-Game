using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame
{
    public class EndTrigger : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            if (GameManager.Instance.enoughStarsCollected)
            {
                GameManager.Instance.LevelFinished();
            }
            else
            {
                GameManager.Instance.GameOver("Stars are there for a reason! Stabilize the portal!");
            }
        }


    }


}