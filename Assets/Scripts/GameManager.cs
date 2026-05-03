using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Data")]
    public int ammoCount = 10;
    public float playerHealth = 100f;

    void Awake()
    {
        // 1. Check if an instance already exists from a previous scene
        if (instance != null && instance != this)
        {
            // If it does, destroy this NEW one immediately so it doesn't reset values
            Destroy(gameObject); 
            return;
        }

        // 2. If this is the FIRST one, set it as the instance and protect it
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
