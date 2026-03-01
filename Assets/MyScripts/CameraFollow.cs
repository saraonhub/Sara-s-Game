using UnityEngine;

namespace MyGame
{


    public class CameraFollow : MonoBehaviour
    {
        public Transform player;
        public Vector3 offset;

        void Update()
        {
            if (player != null)
            {
                transform.position = player.position + offset;
                transform.LookAt(player.position + Vector3.up * 1.5f);
            }
        }

    }
}