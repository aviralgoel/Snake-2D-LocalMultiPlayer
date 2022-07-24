using System.Collections.Generic;
using UnityEngine;

// Purpose: Bring together the game logic of snake movement, input, snake model...

public class PlayerController : MonoBehaviour
{
    [Header("Snake Class")]
    public PlayerStats snake = new PlayerStats();

    [Header("Controller Properties")]
    public bool gamePaused;
    public int stepSize = 2;    // unity units the snake covers in one step (bigger steps = more empty space between u-turns)
    public float inputTime; // how frequently should the user input be registered ( value of 0 means user can turn thrice in one frame, ideal value = 0.75 )
    private Vector2 _direction = Vector2.left;  // the default moving direction of snake on spawn
    private float moveTimeDelta = 0; // local countdown variable for  movement speed
    private float inputTimeDelta;
    private Vector2 snakeDirectionVector; // keeps track of current direction of the snake
    private InputHandler _input; // referene for Unity's new Input System Script
    private List<Transform> snakeBodySegments = new List<Transform>();

    [Header("Prefabs")]
    public Transform snakeBodyPrefab; // one body prefab is added when snake eats one MassGainer
    public GameMenuManager gameMenu;

    // transform coordinates to specficy from where exactly should the snake wrap around on the screen
    [Header("Wrap Around Spawn Points")]
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public Transform upSpawnPoint;
    public Transform downSpawnPoint;
    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }
    private void Start()
    {
        PlayerSpawn();
    }

    private void Update()
    {   
        if (!gamePaused && !snake.IsDead)
        {
            CheckForWrapAround();
            // update current direction
            if (_direction != Vector2.zero)
            {
                snakeDirectionVector = _direction;
            }
            // check for user input to determine snake direction with the frequency of input time
            if (inputTimeDelta > 0)
            {
                inputTimeDelta -= Time.deltaTime;
            }
            else
            {
                _direction = _input.GetInput(_direction);
                inputTimeDelta = inputTime;
            }
            // move snake ahead with the frequency of movespeed
            if (moveTimeDelta > 0)
            {
                moveTimeDelta -= Time.deltaTime;
            }
            else
            {
                UpdateSnakeBodyPosition(); //move body
                SnakeMove(); // move head
                moveTimeDelta = snake.Movespeed; // move snake ahead with the frequency of movespeed
            }
        }
    }
    private void CheckForWrapAround()
    {
        // if snake goes out of screen then enter it from the opposide side
        if (transform.position.y > upSpawnPoint.position.y || transform.position.y < downSpawnPoint.position.y || transform.position.x > rightSpawnPoint.position.x || transform.position.x < leftSpawnPoint.position.x)
        {
            SnakeWrapAround();
        }
    }

    // add x number of segments to snake body at its tail
    public void SnakeGrow(int _numOfSegments)
    {
        for (int i = 0; i < _numOfSegments; i++)
        {
            Transform segment = Instantiate(snakeBodyPrefab); // create new segment
            segment.position = snakeBodySegments[snakeBodySegments.Count - 1].position; // set its position at tail
            snakeBodySegments.Add(segment); // add it to transform list
        }
    }

    // logic of what should happen when snake is spawned or respawned
    public void PlayerSpawn()
    {
        // things we do when player spawn
        snake.IsDead = false;
        // based on what is the PlayerID of snake assign it a direction to move towards
        if (snake.playerID == 2) // red snake
        {
            transform.position = new Vector3(5, 5, 0); // set position to 0,0,0
            _direction = Vector2.right; // make snake face left direction
        }
        else // blue snake
        {
            transform.position = new Vector3(0, 0, 0); // set position to 0,0,0
            _direction = Vector2.left; // make snake face left direction
        }

        SnakeDeGrow(snakeBodySegments.Count);  // old body of the snake destroyed
        snakeBodySegments.Clear();  // clear snake body transform list
        snakeBodySegments.Add(transform); // add back the head of snake to the transform list
        SnakeGrow(snake.getInitialSize()); // fatten up snake to some initial size
        snake.ResetScore(); // reset score
    }

    // reduce the size of snake by x amount
    public void SnakeDeGrow(int _numOfSegments)
    {
        if (_numOfSegments > snakeBodySegments.Count) // not enough body segments to remove
        {
            // Debug.Log("You're trying to remove more snake body segments than is present in the snake");
            return;
        }
        // Loop to Destroy the Snake Body Segments Instantiated BUT we check that we do not delete the HEAD
        for (int i = 0; (snakeBodySegments.Count > 1) && (i < _numOfSegments); i++)
        {
            Destroy(snakeBodySegments[snakeBodySegments.Count - 1].gameObject); // destroy
            snakeBodySegments.RemoveAt(snakeBodySegments.Count - 1); // remove reference from trasform list
        }
    }

    public void PlayerDead()
    {   
        // things we do when player dies        
        snake.IsDead = true;
        gameMenu.ShowGameOverMenu();
    }

    private void UpdateSnakeBodyPosition()
    {
        // except the head, move every segment of the snake body to the position of segment preceding it
        for (int i = snakeBodySegments.Count - 1; i > 0; i--)
        {
            snakeBodySegments[i].position = snakeBodySegments[i - 1].position;
        }
    }

    // move snake in particular direction, in whole unit steps (1, 2, 3) to maintain the grid integrity
    private void SnakeMove()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x) + _direction.x * stepSize, Mathf.Round(transform.position.y) + stepSize * _direction.y, 0f);
    }

    // wrap the snake around the screen based on where it exited from
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

/*    private void ActivatePlayerCollider()
    {
        transform.GetComponent<BoxCollider2D>().enabled = true; // enable the collider
    }*/
}