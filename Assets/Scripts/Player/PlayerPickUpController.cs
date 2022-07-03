using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    PlayerController controller;
    PlayerStats snake;
    public int segmentsPerMassGainer = 1;
    public int segmentsPerMassLoser = 1;
    public float shieldTime = 3f;
    public float scoreBoostTime = 3f;
    public float speedUpTime = 3f;
    public float scoreBoostMultiplier = 2f;
    public float speedMultiplier = 2f;
    public int massGainerScore = 1;
    public int massLoserScore = 1;
    [Range(0.5f, 1.5f)]
    public float moveSpeed;

    private float shieldTimeDelta;
    private float scoreBoostTimeDelta;
    private float speedUpTimeDelta;
    

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        snake = controller.snake;
    }
    private void Update()
    {
        if (shieldTimeDelta > 0)
            shieldTimeDelta -= Time.deltaTime;
        else
        {   
            // back to default condition
            snake.setIsImmune(false);
        }
        if (scoreBoostTimeDelta > 0)
            scoreBoostTimeDelta -= Time.deltaTime;
        else
        {
            // back to default condition
            scoreBoostMultiplier = 1f;
        }
        if (speedUpTimeDelta > 0)
            speedUpTimeDelta -= Time.deltaTime;
        else
        {
            // back to default condition
            snake.MoveSpeed = 1f;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MassGainer"))
        {
            controller.SnakeGrow(segmentsPerMassGainer);
            snake.IncreaseScore(massGainerScore);
            Debug.Log("New Score:" + snake.Score);
            //Increase Score
        }
        else if (collision.CompareTag("MassLoser") && !snake.getIsImmune())
        {   
            // check if player size > segmentsPerMassLoser
            Debug.Log("Decreasing Size");
            controller.SnakeDeGrow(segmentsPerMassLoser);
            snake.DecreaseScore(massLoserScore);
        }
        else if (collision.CompareTag("SpeedUp"))
        {
            // Increase Snake Speed Difficulty
            snake.MoveSpeed = moveSpeed;
            speedUpTimeDelta = speedUpTime;
           
        }
        else if(collision.CompareTag("Shield"))
        {
            snake.setIsImmune(true);
            shieldTimeDelta = shieldTime;
        }
        else if(collision.CompareTag("ScoreBoost"))
        {
            // Increase Score Multiplier x2
            Debug.Log("Score Boost Picked");
            snake.ScoreBoostMultiplier = scoreBoostMultiplier;
            scoreBoostTimeDelta = scoreBoostTime;
        }
        // if player collides with itself and does not have immunity
        else if(collision.CompareTag("Player") && !snake.getIsImmune())
        {
            Debug.Log("Player collided with itself");
            // Reset the game
            controller.ResetState();

            
        }
    }
}
