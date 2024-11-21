using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject targetPrefab;      // Reference to the Target prefab
    public float spawnInterval = 3f;     // Time interval for the target to stay visible
    public Vector2 screenBounds;         // Screen bounds for random positioning

    private GameObject activeTarget;     // Currently active target
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start the spawn routine
        InvokeRepeating("SpawnTarget", 0f, spawnInterval + 1f); // 1-second gap between spawns
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnTarget()
    {
        // Destroy the current target if it exists
        if (activeTarget != null)
        {
            Destroy(activeTarget);
        }

        // Generate a random position within the screen bounds
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Instantiate a new target at the random position
        activeTarget = Instantiate(targetPrefab, randomPosition, Quaternion.identity);

        // Destroy the target after 2 seconds
        Destroy(activeTarget, spawnInterval);
    }
}
