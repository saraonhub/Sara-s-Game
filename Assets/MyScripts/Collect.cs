using UnityEngine;
using TMPro;

namespace MyGame
{
    public class Collect : MonoBehaviour
    {
        private int score = 0;
        public int StarScore { get { return score; } }
        public TextMeshProUGUI scoreText;
        public LayerMask collectibleLayer;
        public Vector3 collectOffset = new Vector3(0, 0, 1f);
        public Vector3 collectSize = new Vector3(2, 2, 2);
        public PlusFiveEffect popup;
        public AudioSource starCollect;


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
                    Inventory.Instance.TotalJewelsCollected();

                }
                else
                {
                    score++;
                    Inventory.Instance.TotalStarsCollected();
                }
                starCollect.Play();
                Destroy(c.gameObject);
                scoreText.text = $"{score}";
                GameManager.Instance.starsCollectedInLevel = score;

            }
        }


    }

}