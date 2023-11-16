using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdaptiveLearning : MonoBehaviour
{
    public Text difficultyText;
    public Text equationText;
    public float spawnInterval = 2f;

    private float initialSpawnInterval;
    private int playerScore = 0;

    void Start()
    {
        initialSpawnInterval = spawnInterval;
        UpdateDifficultyText();
        GenerateNewEquation();
    }

    void UpdateDifficultyText()
    {
        difficultyText.text = $"Difficulty: {playerScore}";
    }

    public void IncreaseDifficulty()
    {
        playerScore++;
        UpdateDifficultyText();
        spawnInterval *= 0.9f;

        ObstacleGenerator obstacleGenerator = FindObjectOfType<ObstacleGenerator>();
        obstacleGenerator.spawnInterval = spawnInterval;

        // Example: Analyze player performance and adjust difficulty
        AnalyzePlayerPerformance();
    }

    public void DecreaseDifficulty()
    {
        spawnInterval *= 1.1f;

        ObstacleGenerator obstacleGenerator = FindObjectOfType<ObstacleGenerator>();
        obstacleGenerator.spawnInterval = spawnInterval;

        // Example: Implement logic to decrease difficulty
        // This could involve increasing obstacle spawn intervals, reducing complexity, etc.
    }

    void GenerateNewEquation()
    {
        int coefficient = Random.Range(1, 5);
        int constant = Random.Range(1, 10);
        int targetValue = coefficient * Random.Range(5, 15);

        equationText.text = $"{coefficient}x + {constant} = {targetValue}";
    }

    void AnalyzePlayerPerformance()
    {
        // Example: Analyze player performance based on some criteria
        float playerPerformance = Random.Range(0f, 1f);

        // Adjust difficulty based on the analysis results
        if (playerPerformance > 0.8f)
        {
            IncreaseDifficulty();
        }
        else if (playerPerformance < 0.2f)
        {
            DecreaseDifficulty();
        }
    }
}
