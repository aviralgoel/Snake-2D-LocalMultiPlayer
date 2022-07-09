using TMPro;
using UnityEngine;

public class SinglePlayerStats : MonoBehaviour
{
    [Header("UI Prefabs")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI shieldText;
    public TextMeshProUGUI scoreMultiplierText;
    public TextMeshProUGUI speedText;
    
    public PlayerController controller;

    private void Update()
    {
        updateStats();
    }
    public void updateStats()
    {
        scoreText.text = "Score: " + controller.snake.Score;
        scoreMultiplierText.text = "Score Multiplier: " + controller.snake.ScoreBoostMultiplier;
        speedText.text = "Speed: " + (int)(controller.snake.DefaultSpeed / controller.snake.Movespeed);
        shieldText.text = "Shield:" + (controller.snake.getIsImmune() ? "On" : "Off");
    }
}
