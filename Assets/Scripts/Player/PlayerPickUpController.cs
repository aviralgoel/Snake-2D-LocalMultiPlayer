using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPickUpController : MonoBehaviour
{   

    [Header("Pickup Settings")] 
    public int segmentsPerMassGainer = 1;
    public int segmentsPerMassLoser = 1;
    public float shieldTime = 3f;
    public float scoreBoostTime = 3f;
    public float speedUpTime = 3f;
    public int scoreDefaultMultiplier;
    public int scoreBoostMultiplier = 2;
    public int massGainerScore = 1;
    public int massLoserScore = 1;
    [Range(3,6)]
    public float fastMoveSpeed = 3f;
    [Range(3, 6)]
    public float defaultMoveSpeed = 6f;

    PlayerController controller;
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
            controller.snake.Movespeed = defaultMoveSpeed/100f;  // back to default condition
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("MassGainer"))
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
            if(controller.snake.Score < 0)
            {
                controller.PlayerDead();
            }
        }
        else if (collision.CompareTag("SpeedUp"))
        {
            controller.snake.Movespeed = fastMoveSpeed/100;
            speedUpTimeDelta = speedUpTime;
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
        }
        else if(collision.CompareTag("Shield"))
        {
            controller.snake.setIsImmune(true);
            shieldTimeDelta = shieldTime;
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
        }
        else if(collision.CompareTag("ScoreBoost"))
        {
            // Increase Score Multiplier
            controller.snake.ScoreBoostMultiplier = scoreBoostMultiplier;
            scoreBoostTimeDelta = scoreBoostTime;
            SoundManager.Instance.Play(SoundsNames.PositiveCollectiblePickup);
        }
        // if player collides with itself and does not have immunity
 /*       if (collision.CompareTag(transform.gameObject.tag) && !controller.snake.getIsImmune())
        {
            SoundManager.Instance.Play(SoundsNames.NegativeCollectiblePickup);
            controller.PlayerDead();
            Debug.Log("Snake Collided with itself");
        }*/
        


    }

}
