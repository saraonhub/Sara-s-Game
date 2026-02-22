using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public LayerMask deathLayer;
    public Vector3 deathBoxSize = new Vector3(0.6f, 1f, 0.6f);
    public Vector3 deathOffset = new Vector3(0, 0.3f, 0);
    void Update()
    {
        Vector3 center = transform.TransformPoint(deathOffset);
        Collider[] hitHazars = Physics.OverlapBox(center, deathBoxSize / 2, transform.rotation, deathLayer);

        if (hitHazars.Length > 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("PLAYER DIED!");
        gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
