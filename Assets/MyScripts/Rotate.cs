using UnityEngine;

namespace MyGame
{

    public class Rotate : MonoBehaviour
    {
        public Vector3 rotateSpeed = new Vector3(0, 100f, 0);

        void Update()
        {
            transform.Rotate(rotateSpeed * Time.deltaTime);
        }
    }

}