using UnityEngine;
using TMPro;

namespace MyGame
{
    public class Collect : MonoBehaviour
    {
        private int score = 0;
        public TextMeshProUGUI scoreText;
        public LayerMask collectibleLayer;
        public Vector3 collectOffset = new Vector3(0, 0, 1f);
        public Vector3 collectSize = new Vector3(2, 2, 2);
        public PlusFiveEffect popup;

        public void Update()
        {

            Vector3 center = transform.TransformPoint(collectOffset);
            Collider[] collects = Physics.OverlapBox(center, collectSize / 2, transform.rotation, collectibleLayer);

            foreach (Collider c in collects)
            {

                if (c.CompareTag("Jewel"))
                {
                    score += 5;
                    popup.ShowPopup("+5");

                }
                else
                {
                    score++;
                }

                Destroy(c.gameObject);
                scoreText.text = $"{score}";
            }
        }


    }

}