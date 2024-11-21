using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI Text for displaying score
    public int score = 0;            // Player's current score

    // Method to add points
    public void AddScore(int points)
    {
        score += points;               // Increase the score
        UpdateScoreUI();               // Update the displayed score
    }
    // Update the UI to show the current score
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update UI text
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in the Inspector!");
        }
    }
}
