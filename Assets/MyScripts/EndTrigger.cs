using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyGame
{
    public class EndTrigger : MonoBehaviour
    {
        public GameManager gm;

        void OnTriggerEnter(Collider other)
        {
            if (gm.enoughStarsCollected)
            {
                gm.LevelFinished();
            }
            else
            {
                gm.GameOver("Stars are there for a reason! Stabilize the portal!");
            }
        }


    }


}