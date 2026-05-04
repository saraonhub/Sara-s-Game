using UnityEngine;

public class ObjectivePopUp : MonoBehaviour
{
    public GameObject objective;
    bool isClosed = false;
    void Start()
    {
        objective.SetActive(true);
    }


    void Update()
    {
        if (isClosed) return;
        bool isSpace = Input.GetKeyDown(KeyCode.Space);
        if (isSpace)
        {
            objective.SetActive(false);
            isClosed = false;
        }

    }
}
