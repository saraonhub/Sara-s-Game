using UnityEngine;

public class MeleeHit : MonoBehaviour
{
    public Vector3 hitOffset = new Vector3(0, 0, 1f);
    public Vector3 hitSize = new Vector3(0.5f, 0.5f, 0.5f);
    public LayerMask enemyLayer;
    void Update()
    {
        bool isHit = Input.GetKeyDown(KeyCode.X);
        if (isHit)
        {
            Vector3 center = transform.position + hitOffset;
            Collider[] hits = Physics.OverlapBox(center, hitSize / 2, Quaternion.identity, enemyLayer);

            foreach (Collider hit in hits)
            {
                Destroy(hit.gameObject);

            }
        }
    }
}
