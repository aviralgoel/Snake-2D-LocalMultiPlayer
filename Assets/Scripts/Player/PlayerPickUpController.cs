using UnityEngine;

public class PlayerPickUpController : MonoBehaviour
{
    PlayerController controller;
    public int segmentsPerMassGainer = 1;
    public int segmentsPerMassLoser = 1;
    public float shieldTime = 3f;
    public float scoreBoostTime = 3f;
    public float speedUpTime = 3f;
    public int scoreBoostMultiplier = 2;
    public int massGainerScore = 1;
    public int massLoserScore = 1;
    [Range(3,6)]
    public float FastmoveSpeed = 3;

    private float shieldTimeDelta;
    private float scoreBoostTimeDelta;
    private float speedUpTimeDelta;
    

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        
    }
    private void Start()
    {   

    }
    private void Update()
    {   

        // back to non immune
        if (shieldTimeDelta > 0)
            shieldTimeDelta -= Time.deltaTime;
        else
        {   
            // back to default condition
            controller.snake.setIsImmune(false);
        }

        // back to normal scoring
        if (scoreBoostTimeDelta > 0)
            scoreBoostTimeDelta -= Time.deltaTime;
        else
        {
            // back to default condition
            controller.snake.ScoreBoostMultiplier = 1;
        }

        // Back to normal speed
        if (speedUpTimeDelta > 0)
            speedUpTimeDelta -= Time.deltaTime;
        else
        {
            // back to default condition
            controller.snake.Movespeed = 0.06f;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("MassGainer"))
        {
            controller.SnakeGrow(segmentsPerMassGainer);
            controller.snake.IncreaseScore(massGainerScore);
         
        }
        else if (collision.CompareTag("MassLoser") && !controller.snake.getIsImmune())
        {   
            controller.SnakeDeGrow(segmentsPerMassLoser);
            controller.snake.DecreaseScore(massLoserScore);
        }
        else if (collision.CompareTag("SpeedUp"))
        {
            // Increase Snake Speed Difficulty
            Debug.Log("SpeedUp Picked");
            controller.snake.Movespeed = FastmoveSpeed/100;
            speedUpTimeDelta = speedUpTime;
           
        }
        else if(collision.CompareTag("Shield"))
        {
            controller.snake.setIsImmune(true);
            shieldTimeDelta = shieldTime;
        }
        else if(collision.CompareTag("ScoreBoost"))
        {
            // Increase Score Multiplier
            controller.snake.ScoreBoostMultiplier = scoreBoostMultiplier;
            scoreBoostTimeDelta = scoreBoostTime;
        }
        // if player collides with itself and does not have immunity
        else if(collision.CompareTag("Player") && !controller.snake.getIsImmune())
        {
           controller.PlayerDead();
        }
    }
}
