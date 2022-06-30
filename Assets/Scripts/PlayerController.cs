using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    public Transform snakeBodyPrefab;
    public float speed = 20f;
    public float speedMultiplier = 1f;
    public int stepSize = 2;
    private float nextUpdate;
    private Vector2 snakeDirectionVector;
    InputActions inputActions;
    bool WPressed, APressed, SPressed, DPressed;
    private List<Transform> snakeBodySegments = new List<Transform>();
    public int initialSize = 2;

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
        GetInput();
       
    }
    
    private void FixedUpdate()
    {
        if (_direction != Vector2.zero)
        {
            snakeDirectionVector = _direction;
        }
        for (int i = snakeBodySegments.Count - 1; i > 0; i--)
        {
            snakeBodySegments[i].position = snakeBodySegments[i - 1].position;
        }
        if (Time.time < nextUpdate)
        {
            return;
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x) + _direction.x*stepSize, Mathf.Round(transform.position.y) + stepSize * _direction.y, 0f);
        nextUpdate = Time.time + (1f / (speed * speedMultiplier));
    }

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
    private void SnakeGrow()
    {
        Transform segment = Instantiate(snakeBodyPrefab);
        snakeBodySegments.Add(segment);
        segment.position = snakeBodySegments[snakeBodySegments.Count - 1].position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MassGainer"))
        {
            SnakeGrow();
        }
        else if (collision.CompareTag("Walls"))
        {
            Debug.Log("Collided with Wall");
            Vector3 position = transform.position;

            if (snakeDirectionVector.x != 0f)
            {
                position.x = -collision.transform.position.x + snakeDirectionVector.x;
            }
            else if (snakeDirectionVector.y != 0f)
            {
                position.y = -collision.transform.position.y + snakeDirectionVector.y;
            }
            transform.position = position;
        }
        else if (collision.CompareTag("Player"))
        {
            ResetState();
        }
    }
    public void ResetState()
    {
        _direction = Vector2.right;
        transform.position = Vector3.zero;

        
        for (int i = 1; i < snakeBodySegments.Count; i++)
        {
            Destroy(snakeBodySegments[i].gameObject);
        }

        // Clear the list but add back this as the head
        snakeBodySegments.Clear();
        snakeBodySegments.Add(transform);

        // -1 since the head is already in the list
        for (int i = 0; i < initialSize - 1; i++)
        {
            SnakeGrow();
        }
    }

    private void OnEnable()
    {
        inputActions.Player1Controller.Enable();
    }
    private void OnDisable()
    {
        inputActions.Player1Controller.Disable();

    }

}
