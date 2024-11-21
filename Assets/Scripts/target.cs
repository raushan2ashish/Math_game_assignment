using UnityEngine;
using TMPro;

public class target : MonoBehaviour
{
    public int points = 10; // Points awarded for hitting this target

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Check if the object is the ball
        {
            // Find the ScoreManager and add points
            ScoreManager scoreManager = Object.FindAnyObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(points); // Add points for hitting the target

            }


            Destroy(gameObject); // Destroy the target
        }
    }
}
