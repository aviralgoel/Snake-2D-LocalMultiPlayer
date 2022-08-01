using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Purpose: Handle input for players 
public class InputHandler : MonoBehaviour
{
    InputActions inputActions;
    bool WPressed, APressed, SPressed, DPressed;
    // Start is called before the first frame update
    private void Awake()
    {
        inputActions = new InputActions();
        // acvtivate action map depending on which snake the script is
        if (gameObject.name == "Snake2")
        {
            inputActions.Player2Controller.Up.performed += ctx => { WPressed = ctx.ReadValueAsButton(); };
            inputActions.Player2Controller.Down.performed += ctx => { SPressed = ctx.ReadValueAsButton(); };
            inputActions.Player2Controller.Left.performed += ctx => { APressed = ctx.ReadValueAsButton(); };
            inputActions.Player2Controller.Right.performed += ctx => { DPressed = ctx.ReadValueAsButton(); };
        }
        if (gameObject.name == "Snake1")
        {
            inputActions.Player1Controller.Up.performed += ctx => { WPressed = ctx.ReadValueAsButton(); };
            inputActions.Player1Controller.Down.performed += ctx => { SPressed = ctx.ReadValueAsButton(); };
            inputActions.Player1Controller.Left.performed += ctx => { APressed = ctx.ReadValueAsButton(); };
            inputActions.Player1Controller.Right.performed += ctx => { DPressed = ctx.ReadValueAsButton(); };
        }
        
    }
    public Vector2 GetInput(Vector2 snakeDirectionVector)
    {   
        // if W pressed and we are not already moving horizontally
        if (WPressed && snakeDirectionVector.x != 0)
        {
            WPressed = false;
            // Direction to turn
            return Vector2.up;
        }
        // if S pressed and we are not already moving horizontally
        else if (SPressed && snakeDirectionVector.x != 0)
        {
            SPressed = false;
            // Direction to turn
            return Vector2.down;
        }
        // if A pressed and we are not already moving horizontally
        else if (APressed && snakeDirectionVector.y != 0)
        {
            APressed = false;
            // Direction to turn
            return Vector2.left;
        }
        // if D pressed and we are not already moving horizontally
        else if (DPressed && snakeDirectionVector.y != 0)
        {
            DPressed = false;
            // Direction to turn
            return Vector2.right;
        }
        //if no input dectected, continue with current direction
        return snakeDirectionVector;
    }
    private void OnEnable()
    {
        //enabling unity's input system
        if (gameObject.name == "Snake2")
        {
            inputActions.Player2Controller.Enable();
        }
        if (gameObject.name == "Snake1")
        {
            inputActions.Player1Controller.Enable();
        }
            
    }
    private void OnDisable()
    {
        if (gameObject.name == "Snake2")
        {
            inputActions.Player2Controller.Disable();
        }
        if (gameObject.name == "Snake1")
        {
            inputActions.Player1Controller.Disable();
        }
        
    }
}
