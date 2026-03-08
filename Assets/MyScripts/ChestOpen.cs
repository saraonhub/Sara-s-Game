using UnityEditorInternal.VersionControl;
using UnityEngine;


namespace MyGame
{
    public class ChestOpen : MonoBehaviour
    {
        public float detectionRadius = 1f;
        private bool isOpen = false;
        public Animator animator;
        public GameObject chestIcon;

        void Start()
        {
            chestIcon.SetActive(false);
        }
        void Update()
        {
            bool isHit = Input.GetKeyDown(KeyCode.X);
            if (isHit && !isOpen)
            {
                Open();
            }
        }

        void Open()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, 1.8f);

            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    animator.SetBool("isOpening", true);
                    isOpen = true;

                    chestIcon.SetActive(true);
                }
            }

        }
    }

}
