using UnityEngine;
using TMPro;


namespace MyGame
{

    public class PlusFiveEffect : MonoBehaviour
    {
        public float effectSpeed = 50f;
        public float effectLife = 1f;
        public TextMeshProUGUI textMesh;
        private float timer = 0f;

        void Awake()
        {
            gameObject.SetActive(false);
        }

        public void ShowPopup(string text)
        {
            gameObject.SetActive(true);
            textMesh.text = text;
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            textMesh.alpha = 1f;
            timer = 0f;
        }

        void Update()
        {
            if (!gameObject.activeSelf)
            {
                return;
            }
            transform.localPosition += Vector3.up * effectSpeed * Time.deltaTime;
            transform.localScale += Vector3.one * Time.deltaTime;
            textMesh.alpha -= Time.deltaTime / effectLife;
            timer += Time.deltaTime;
            if (timer >= effectLife)
            {
                gameObject.SetActive(false);
            }


        }
    }
}