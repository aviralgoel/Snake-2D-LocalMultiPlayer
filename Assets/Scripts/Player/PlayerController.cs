using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Settings")]
    public PlayerStats snake = new PlayerStats();
    public InputHandler _input;
    public int stepSize = 2;    // unity units the snake covers in one step (bigger steps = more empty space between u-turns)
    private Vector2 _direction = Vector2.left;  // the default moving direction of snake on spawn
    private float moveTimeDelta = 0; // local variable for speed
    private Vector2 snakeDirectionVector; // keeps track of current direction of the snake
    [Header("Prefabs")]
    public Transform snakeBodyPrefab;
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public Transform upSpawnPoint;
    public Transform downSpawnPoint;
    [Header("General Variables")]
    public GameMenuManager gameMenu;
    //public TextMeshProUGUI winLoseText;
    private List<Transform> snakeBodySegments = new List<Transform>();
    public bool gamePaused;
    public float inputTime;
    private float inputTimeDelta;
    

  
    private void Start()
    {
        PlayerSpawn();
    }
    private void Update()
    {   
        if(!gamePaused && !snake.IsDead)
        {
            CheckForWrapAround();
            if (_direction != Vector2.zero)
            {
                snakeDirectionVector = _direction;
            }
            if(inputTimeDelta > 0)
            {
                inputTimeDelta -= Time.deltaTime;
            }
            else
            {
                _direction = _input.GetInput(_direction);
                inputTimeDelta = inputTime;
            }
            if (moveTimeDelta > 0) // how frequently the snake should move
            {
                moveTimeDelta -= Time.deltaTime;
            }
            else
            {
                UpdateSnakeBodyPosition();
                // Checks if  current time less than the future time stamp we are allowed to move, if yes, don't move, wait...
                SnakeMove();
                moveTimeDelta = snake.Movespeed;
            }
        }  
    }

    private void CheckForWrapAround()
    {
        if(transform.position.y > upSpawnPoint.position.y || transform.position.y < downSpawnPoint.position.y || transform.position.x > rightSpawnPoint.position.x || transform.position.x < leftSpawnPoint.position.x)
        {
            SnakeWrapAround();
        }
    }

    // add x number of segments to snake body
    public void SnakeGrow(int _numOfSegments)
    {   
        for(int i = 0; i < _numOfSegments; i++)
        {
            Transform segment = Instantiate(snakeBodyPrefab); // create new segment
            segment.position = snakeBodySegments[snakeBodySegments.Count - 1].position; // set its position at tail
            snakeBodySegments.Add(segment); // add it to transform list
        }
    }
    public void PlayerSpawn()
    {   
        // things we do when player spawn
        snake.IsDead = false;  // - snake object variable IsDead = true
        if(snake.playerID == 2)
        {
            transform.position = new Vector3(5, 5, 0); // set position to 0,0,0
            _direction = Vector2.right; // make snake face left direction 
        }
        else
        {
            transform.position = new Vector3(0, 0, 0); // set position to 0,0,0
            _direction = Vector2.left; // make snake face left direction   
        }
 
        SnakeDeGrow(snakeBodySegments.Count);  // destroy old body of the snake
        snakeBodySegments.Clear();  // clear snake body transform list
        snakeBodySegments.Add(transform); // add back the head of snake to the transform list
        SnakeGrow(snake.getInitialSize()); // fatten up snake to some initial size
        snake.ResetScore(); // reset score
        //Invoke("ActivatePlayerCollider", 3f);

    }
    public void SnakeDeGrow(int _numOfSegments)
    {   
        if(_numOfSegments > snakeBodySegments.Count)
        {
            Debug.Log("You're trying to remove more snake body segments than is present in the snake");
            return;
        }
        // Loop to Destroy the Snake Body Segments Instantiated BUT we check that we do not delete the HEAD
        for(int i = 0; (snakeBodySegments.Count > 1) && (i < _numOfSegments) ; i++)
        {
            Destroy(snakeBodySegments[snakeBodySegments.Count - 1].gameObject); // destroy
            snakeBodySegments.RemoveAt(snakeBodySegments.Count - 1); // remove reference from trasform list
        }
    }
    public void PlayerDead()
    {   // things we do when player dies
        // - snake object variable dead - true
        // enable game over menu
        // disable snake head collider
        snake.IsDead = true;
        gameMenu.ShowGameOverMenu();
        //winLoseText.text = gameObject.transform.name + "Lose";
        //transform.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void UpdateSnakeBodyPosition()
    {
        // except the head, move every segment of the snake body to the position of segment preceding it
        for (int i = snakeBodySegments.Count - 1; i > 0; i--)
        {
            snakeBodySegments[i].position = snakeBodySegments[i - 1].position;
        }
    }

    // move snake in particular direction
    private void SnakeMove()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x) + _direction.x * stepSize, Mathf.Round(transform.position.y) + stepSize * _direction.y, 0f);
    }
    // wrap the snake around the screen, if snake touches the wall collider
    private void SnakeWrapAround()
    {
        // current snake head position
        Vector3 position = transform.position;
        // the direction vector x is 0 when snake is moving horizontally left or right the screen
        if (snakeDirectionVector.x != 0f)
        {
            // snake hit left wall
            if (transform.position.x < 0)
            {
                position.x = rightSpawnPoint.position.x;
            }
            // snake hit right wall
            else
            {
                position.x = leftSpawnPoint.position.x;
            }
        }
        // the direction vector y is 0 when snake is moving horizontally up or down the screen
        else if (snakeDirectionVector.y != 0f)
        {
            // snake hit bottom wall
            if (transform.position.y < 0)
            {
                position.y = upSpawnPoint.position.y;
            }
            // snake hit top wall
            else
            {
                position.y = downSpawnPoint.position.y;
            }
        }
        // new head position will be the intended position (rest body segments will follow the head)
        transform.position = position;
    }
    private void ActivatePlayerCollider()
    {
        transform.GetComponent<BoxCollider2D>().enabled = true; // enable the collider
    }

}
