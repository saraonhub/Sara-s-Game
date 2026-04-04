using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    // TOTALS
    public static int totalStars = 0;
    public static int totalJewles = 0;
    public static int totalChests = 0;
    public static int totalTreats = 0;

    //UI
    public GameObject inventoryUI;
    public TextMeshProUGUI starCounter;
    public TextMeshProUGUI jewelCounter;
    public TextMeshProUGUI chestCounter;

    public GameObject pauseSprite;
    public GameObject resumeSprite;

    bool isPaused = false;

    private void Start()
    {
        if (Instance != this) return;
        Time.timeScale = 1f;
        inventoryUI.SetActive(false);
        pauseSprite.SetActive(true);
        resumeSprite.SetActive(false);
        isPaused = false;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // Kill this duplicate
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("Inventory created. totalStars: " + totalStars);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();

        }
    }

    public void ToggleInventory()
    {
        if (!isPaused)
        {
            starCounter.text = totalStars.ToString();
            jewelCounter.text = totalJewles.ToString();
            chestCounter.text = totalChests.ToString();

            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        inventoryUI.SetActive(false);
        pauseSprite.SetActive(true);
        resumeSprite.SetActive(false);
        isPaused = false;

    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        inventoryUI.SetActive(true);
        pauseSprite.SetActive(false);
        resumeSprite.SetActive(true);
        isPaused = true;
    }
    public void TotalStarsCollected()
    {
        totalStars++;
        starCounter.text = totalStars.ToString();
        Debug.Log(totalStars);
    }

    public void TotalJewelsCollected()
    {
        totalJewles++;
        jewelCounter.text = totalJewles.ToString();
    }
    public void TotalChestsCollected()
    {
        totalChests++;
        chestCounter.text = totalChests.ToString();
    }
    public void TotalTreatsCollected()
    {
        totalTreats++;
    }



}
