using UnityEngine;

namespace MyGame
{

    public class MeleeHit : MonoBehaviour
    {
        public Vector3 hitOffset = new Vector3(0, 0, 1f);
        public Vector3 hitSize = new Vector3(0.5f, 0.5f, 0.5f);
        public LayerMask enemyLayer;
        public AudioSource bark;
        void Update()
        {
            bool isHit = Input.GetKeyDown(KeyCode.X);
            if (isHit)
            {
                bark.Play();
                Attack();

            }
        }

        void Attack()
        {
            Vector3 center = transform.TransformPoint(hitOffset);
            Collider[] hits = Physics.OverlapBox(center, hitSize / 2, transform.rotation, enemyLayer);

            foreach (Collider hit in hits)
            {
                Destroy(hit.gameObject);
            }
        }
    }
}