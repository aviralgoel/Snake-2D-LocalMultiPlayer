using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [Tooltip("Amount of size to increases when mass gainer is picked up")]
    public int segmentsPerMassGainer = 1;

    [Tooltip("Amount of size to reduce when mass loser is picked up")]
    public int segmentsPerMassLoser = 1;

    [Tooltip("Amount of time shield is active")]
    public float shieldTime = 3f;

    [Tooltip("Amount of time score boost is active")]
    public float scoreBoostTime = 3f;

    [Tooltip("Amount of time speed up is active")]
    public float speedUpTime = 3f;

    [Tooltip("Amount of score multiplier by default")]
    public int scoreDefaultMultiplier;

    [Tooltip("Amount of score multiplier when score boost is picked")]
    public int scoreBoostMultiplier = 2;

    [Tooltip("Amount of score increased when mass gainer is picked")]
    public int massGainerScore = 1;

    [Tooltip("Amount of score increased when mass loser is picked")]
    public int massLoserScore = 1;

    [Tooltip("Amount of speed of snake when speed up is picked")]
    [Range(3, 6)]
    public float fastMoveSpeed = 3f;

    [Tooltip("Default speed of snake")]
    [Range(3, 6)]
    public float defaultMoveSpeed = 6f;

    private PlayerController controller;
    private float shieldTimeDelta;
    private float scoreBoostTimeDelta;
    private float speedUpTimeDelta;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (shieldTimeDelta > 0)
            shieldTimeDelta -= Time.deltaTime;
        else
            controller.snake.setIsImmune(false); // back to default condition

        if (scoreBoostTimeDelta > 0)
            scoreBoostTimeDelta -= Time.deltaTime;
        else
            controller.snake.ScoreBoostMultiplier = scoreDefaultMultiplier; // // back to default condition

        if (speedUpTimeDelta > 0)
            speedUpTimeDelta -= Time.deltaTime;
        else
        {
            controller.snake.Movespeed = defaultMoveSpeed / 100f;  // back to default condition
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MassGainer"))
        {
            controller.SnakeGrow(segmentsPerMassGainer);
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
            controller.snake.IncreaseScore(massGainerScore);
        }
        else if (collision.CompareTag("MassLoser") && !controller.snake.getIsImmune())
        {
            controller.SnakeDeGrow(segmentsPerMassLoser);
            controller.snake.DecreaseScore(massLoserScore);
            SoundManager.Instance.Play(SoundsNames.NegativeCollectiblePickup);
            if (controller.snake.Score < 0)
            {
                controller.PlayerDead();
            }
        }
        else if (collision.CompareTag("SpeedUp"))
        {
            controller.snake.Movespeed = fastMoveSpeed / 100;
            speedUpTimeDelta = speedUpTime;
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
        }
        else if (collision.CompareTag("Shield"))
        {
            controller.snake.setIsImmune(true);
            shieldTimeDelta = shieldTime;
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
        }
        else if (collision.CompareTag("ScoreBoost"))
        {
            // Increase Score Multiplier
            controller.snake.ScoreBoostMultiplier = scoreBoostMultiplier;
            scoreBoostTimeDelta = scoreBoostTime;
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
        }
    }
}