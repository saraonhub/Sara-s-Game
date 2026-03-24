using UnityEngine;

namespace MyGame
{


    public class PlayerDeath : MonoBehaviour
    {
        public GameManager gm;
        public LayerMask deathLayer;
        public Vector3 deathBoxSize = new Vector3(0.6f, 1f, 0.6f);
        public Vector3 deathOffset = new Vector3(0, 0.3f, 0);
        void Update()
        {
            Vector3 center = transform.TransformPoint(deathOffset);
            Collider[] hitHazars = Physics.OverlapBox(center, deathBoxSize / 2, transform.rotation, deathLayer);

            if (hitHazars.Length > 0)
            {
                int layer = hitHazars[0].gameObject.layer;
                string layerName = LayerMask.LayerToName(layer);

                MessageByLayer(layerName);
            }

        }

        void MessageByLayer(string layerName)
        {
            string message = "Ouch, that's a ruff break";
            if (layerName == "Enemy")
            {
                message = "Too much fluff, not enough tough! That meany isn't looking for friends.";
            }
            else if (layerName == "Obstacle")
            {
                message = "Barking at the obstacles won't make them less dangerous.";
            }
            else if (layerName == "DeathGround")
            {
                message = "Ooh, zoomies gone wrong. Watch your paws buddy!";
            }

            Die(message);
        }

        void Die(string message)
        {
            gameObject.SetActive(false);
            gm.GameOver(message);
        }
    }
}
