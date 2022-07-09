using TMPro;
using UnityEngine;

public class MultiplayerGameStats : MonoBehaviour
{
    [Header("UI Prefabs Player1")]
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI shieldText1;
    public TextMeshProUGUI scoreMultiplierText1;
    public TextMeshProUGUI speedText1;
    public PlayerController controller1;
    [Header("UI Prefabs Player2")]
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI shieldText2;
    public TextMeshProUGUI scoreMultiplierText2;
    public TextMeshProUGUI speedText2;
    public PlayerController controller2;

    private void Update()
    {
        updateStats1();
        updateStats2();
    }
    public void updateStats1()
    {
        scoreText1.text = "Score: " + controller1.snake.Score;
        scoreMultiplierText1.text = "Score Multiplier: " + controller1.snake.ScoreBoostMultiplier;
        speedText1.text = "Speed: " + (int)(controller1.snake.DefaultSpeed / controller1.snake.Movespeed);
        shieldText1.text = "Shield:" + (controller1.snake.getIsImmune() ? "On" : "Off");
    }
    public void updateStats2()
    {
        scoreText2.text = "Score: " + controller2.snake.Score;
        scoreMultiplierText2.text = "Score Multiplier: " + controller2.snake.ScoreBoostMultiplier;
        speedText2.text = "Speed: " + (int)(controller2.snake.DefaultSpeed / controller2.snake.Movespeed);
        shieldText2.text = "Shield:" + (controller2.snake.getIsImmune() ? "On" : "Off");
    }
}
