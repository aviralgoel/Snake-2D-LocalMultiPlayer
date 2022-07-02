using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Prefabs")]
    public Transform snakeBodyPrefab;
    [Header("Move Settings")]
    private Vector2 _direction = Vector2.right;
    public PlayerStats snake = new PlayerStats();
    public float moveTimeDelta = 0;

    public int stepSize = 2;
    //public int initialSize = 2;
    private float nextUpdate;
    private Vector2 snakeDirectionVector;
    InputActions inputActions;
    bool WPressed, APressed, SPressed, DPressed;
    private List<Transform> snakeBodySegments = new List<Transform>();
    public float multi;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player1Controller.Up.performed += ctx => { WPressed = ctx.ReadValueAsButton(); };
        inputActions.Player1Controller.Down.performed += ctx => { SPressed = ctx.ReadValueAsButton(); };
        inputActions.Player1Controller.Left.performed += ctx => { APressed = ctx.ReadValueAsButton(); };
        inputActions.Player1Controller.Right.performed += ctx => { DPressed = ctx.ReadValueAsButton(); };
    }
    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (_direction != Vector2.zero)
        {
            snakeDirectionVector = _direction;
        }
        GetInput();
        if(moveTimeDelta > 0)
        {
            moveTimeDelta -= Time.fixedDeltaTime;
        }
        else
        {
            UpdateSnakeBodyPosition();
            // Checks if  current time less than the future time stamp we are allowed to move, if yes, don't move, wait...
            SnakeMove();
            moveTimeDelta = snake.MoveSpeed;
        }
       
    }
    
    /*private void FixedUpdate()
    {
        
       *//* UpdateSnakeBodyPosition();
        // Checks if  current time less than the future time stamp we are allowed to move, if yes, don't move, wait...
        SnakeMove();
*//*
    }
*/
    private void SnakeMove()
    {
       /* if (Time.time < nextUpdate)
        {
            return;
        }*/
        // if current time is more then the future time stamp we are allowed to move, then quickly move and calculate the next future time stamp
        //else
        //{
            transform.position = new Vector3(Mathf.Round(transform.position.x) + _direction.x * stepSize, Mathf.Round(transform.position.y) + stepSize * _direction.y, 0f);
            // next future time stamp = current time + 1/(defaultSpeed * Difficulty)
            //nextUpdate = Time.time + (1f / (10f * multi));
            // if speed or difficulty is higher, then denominator bigger, then 1/D is very small number, so time stamps are closer
            // hence faster movement
        //}
    }

    // simple for loop that moves the snake body segment where the previous in list segment was
    // basically shifting the segments one unit ahead 
    private void UpdateSnakeBodyPosition()
    {
        for (int i = snakeBodySegments.Count - 1; i > 0; i--)
        {
            snakeBodySegments[i].position = snakeBodySegments[i - 1].position;
        }
    }


    // Set player move direction based on user input and snake's current direction
    private void GetInput()
    {
        if(WPressed && snakeDirectionVector.x !=0 )
        {
            _direction = Vector2.up;
            WPressed = false;
        }
        else if(SPressed && snakeDirectionVector.x != 0)
        {
            _direction = Vector2.down;
            SPressed = false;
        }
        else if(APressed && snakeDirectionVector.y != 0)
        {
            _direction = Vector2.left;
            APressed = false;
        }
        else if(DPressed && snakeDirectionVector.y != 0)
        {
            _direction = Vector2.right;
            DPressed = false;
        }
        
    }
    public void SnakeGrow(int _numOfSegments)
    {   
        for(int i = 0; i < _numOfSegments; i++)
        {
            Vector3 segPos = snakeBodySegments[snakeBodySegments.Count - 1].position;
            // instantiate the snake body segment at the end of the snake
            Transform segment = Instantiate(snakeBodyPrefab);
            segment.position = snakeBodySegments[snakeBodySegments.Count - 1].position;
            snakeBodySegments.Add(segment);
        }

    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Walls"))
        {
            SnakeWrapAround(collision);
        }
    }

    // wrap the snake around the screen, if he touches the wall collider
    private void SnakeWrapAround(Collider2D collision)
    {   
        // current snake head position
        Vector3 position = transform.position;
        // the direction vector x is 0 when snake is moving horizontally left or right the screen
        if (snakeDirectionVector.x != 0f) 
        {   
            // new intended position will be mirror position of where the snake hit + 1 unit extra towards the left/right.
            position.x = -collision.transform.position.x + snakeDirectionVector.x;
        }
        // the direction vector y is 0 when snake is moving horizontally up or down the screen
        else if (snakeDirectionVector.y != 0f) 
        {
            // new intended position will be mirror position of where the snake hit + 1 unit extra towards the left/right.
            position.y = -collision.transform.position.y + snakeDirectionVector.y;
        }
        // new head position will be the intended position (rest body segments will follow the head)
        transform.position = position;
    }

    public void ResetState()
    {

        transform.position = Vector3.zero; // begin from original (centre of the screen)
        _direction = Vector2.right; // Initial direction snake start to move
        // Call to destroy all the snakebody segments game Objects.
        // Remove all transform references from the snake body segment list, then
        SnakeDeGrow(snakeBodySegments.Count);
        snakeBodySegments.Clear();
        //  add Head transform back.
        snakeBodySegments.Add(transform);

        // add snake segments to the snake body based on initial size value.      
        //SnakeGrow(initialSize);
        SnakeGrow(snake.getInitialSize());
        // Reset Score

    }

    public void SnakeDeGrow(int _numOfSegments)
    {   
        if(_numOfSegments > snakeBodySegments.Count)
        {
            Debug.Log("You're trying to remove more snake body segments than is present in the snake");
            // Player Dead
            return;
        }
        // Loop to Destroy the Snake Body Segments Instantiated BUT we check that we do not delete the HEAD
        for(int i = 0; (snakeBodySegments.Count > 1) && (i < _numOfSegments) ; i++)
        {
            Destroy(snakeBodySegments[snakeBodySegments.Count - 1].gameObject);
            snakeBodySegments.RemoveAt(snakeBodySegments.Count - 1);
        }
              
        
    }

    // Enable Unity's new input system
    private void OnEnable()
    {
        inputActions.Player1Controller.Enable();
    }
    // Then Disable Unity's new input system
    private void OnDisable()
    {
        inputActions.Player1Controller.Disable();

    }

}
