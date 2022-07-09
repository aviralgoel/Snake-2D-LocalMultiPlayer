//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player1Controller"",
            ""id"": ""6c9b11ad-6d10-461f-9f64-5b099ceca60d"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""4b05d237-afff-4709-96d3-2094b0b68743"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""9e9f9bfe-1f4c-450a-aec2-03dff5774feb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""e9461552-e1b0-4ce1-9548-a6f702e36df0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""3d6f7dc3-b317-46ea-ae9d-8c7bece2b37c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68551751-8bb1-4a73-8263-d47433747cf4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff95f59d-728e-4873-a251-2f2878f407cc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42f6e811-d873-483b-89ba-0ef973ac74b4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc1789f9-8424-49b3-884e-1a1716ee30d3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player2Controller"",
            ""id"": ""a9ab0f76-c768-4544-848c-e66a8b991fd5"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""491e0f43-c647-4326-8d9f-acb2b462b2c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""afb84a4b-0302-4937-ab7b-b34bb6e0e6eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""02f371b1-5c3e-4b9e-9df0-afd55e78c56d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""42f547e4-de36-4e64-aaec-660594f254d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""43dbfdec-db56-4877-a0cc-97e06f07c181"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9abc4da-676a-46f3-b55c-7581df31e48e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c71a0149-b7b5-4785-82bc-b16c86d4b399"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d453b83-e5e3-4a73-bb29-75d05e2abc22"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIController"",
            ""id"": ""329df265-0353-4b41-a00c-0be295f9d38f"",
            ""actions"": [
                {
                    ""name"": ""GamePaused"",
                    ""type"": ""Button"",
                    ""id"": ""a759f452-d57a-4a09-96e8-54744574e188"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": ""Invert"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d0cc2643-82f2-4b5b-a61b-8755d8237078"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GamePaused"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1Controller
        m_Player1Controller = asset.FindActionMap("Player1Controller", throwIfNotFound: true);
        m_Player1Controller_Up = m_Player1Controller.FindAction("Up", throwIfNotFound: true);
        m_Player1Controller_Down = m_Player1Controller.FindAction("Down", throwIfNotFound: true);
        m_Player1Controller_Right = m_Player1Controller.FindAction("Right", throwIfNotFound: true);
        m_Player1Controller_Left = m_Player1Controller.FindAction("Left", throwIfNotFound: true);
        // Player2Controller
        m_Player2Controller = asset.FindActionMap("Player2Controller", throwIfNotFound: true);
        m_Player2Controller_Up = m_Player2Controller.FindAction("Up", throwIfNotFound: true);
        m_Player2Controller_Down = m_Player2Controller.FindAction("Down", throwIfNotFound: true);
        m_Player2Controller_Right = m_Player2Controller.FindAction("Right", throwIfNotFound: true);
        m_Player2Controller_Left = m_Player2Controller.FindAction("Left", throwIfNotFound: true);
        // UIController
        m_UIController = asset.FindActionMap("UIController", throwIfNotFound: true);
        m_UIController_GamePaused = m_UIController.FindAction("GamePaused", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player1Controller
    private readonly InputActionMap m_Player1Controller;
    private IPlayer1ControllerActions m_Player1ControllerActionsCallbackInterface;
    private readonly InputAction m_Player1Controller_Up;
    private readonly InputAction m_Player1Controller_Down;
    private readonly InputAction m_Player1Controller_Right;
    private readonly InputAction m_Player1Controller_Left;
    public struct Player1ControllerActions
    {
        private @InputActions m_Wrapper;
        public Player1ControllerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Player1Controller_Up;
        public InputAction @Down => m_Wrapper.m_Player1Controller_Down;
        public InputAction @Right => m_Wrapper.m_Player1Controller_Right;
        public InputAction @Left => m_Wrapper.m_Player1Controller_Left;
        public InputActionMap Get() { return m_Wrapper.m_Player1Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1ControllerActions instance)
        {
            if (m_Wrapper.m_Player1ControllerActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnDown;
                @Right.started -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_Player1ControllerActionsCallbackInterface.OnLeft;
            }
            m_Wrapper.m_Player1ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
            }
        }
    }
    public Player1ControllerActions @Player1Controller => new Player1ControllerActions(this);

    // Player2Controller
    private readonly InputActionMap m_Player2Controller;
    private IPlayer2ControllerActions m_Player2ControllerActionsCallbackInterface;
    private readonly InputAction m_Player2Controller_Up;
    private readonly InputAction m_Player2Controller_Down;
    private readonly InputAction m_Player2Controller_Right;
    private readonly InputAction m_Player2Controller_Left;
    public struct Player2ControllerActions
    {
        private @InputActions m_Wrapper;
        public Player2ControllerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_Player2Controller_Up;
        public InputAction @Down => m_Wrapper.m_Player2Controller_Down;
        public InputAction @Right => m_Wrapper.m_Player2Controller_Right;
        public InputAction @Left => m_Wrapper.m_Player2Controller_Left;
        public InputActionMap Get() { return m_Wrapper.m_Player2Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2ControllerActions instance)
        {
            if (m_Wrapper.m_Player2ControllerActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnDown;
                @Right.started -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_Player2ControllerActionsCallbackInterface.OnLeft;
            }
            m_Wrapper.m_Player2ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
            }
        }
    }
    public Player2ControllerActions @Player2Controller => new Player2ControllerActions(this);

    // UIController
    private readonly InputActionMap m_UIController;
    private IUIControllerActions m_UIControllerActionsCallbackInterface;
    private readonly InputAction m_UIController_GamePaused;
    public struct UIControllerActions
    {
        private @InputActions m_Wrapper;
        public UIControllerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @GamePaused => m_Wrapper.m_UIController_GamePaused;
        public InputActionMap Get() { return m_Wrapper.m_UIController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIControllerActions set) { return set.Get(); }
        public void SetCallbacks(IUIControllerActions instance)
        {
            if (m_Wrapper.m_UIControllerActionsCallbackInterface != null)
            {
                @GamePaused.started -= m_Wrapper.m_UIControllerActionsCallbackInterface.OnGamePaused;
                @GamePaused.performed -= m_Wrapper.m_UIControllerActionsCallbackInterface.OnGamePaused;
                @GamePaused.canceled -= m_Wrapper.m_UIControllerActionsCallbackInterface.OnGamePaused;
            }
            m_Wrapper.m_UIControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GamePaused.started += instance.OnGamePaused;
                @GamePaused.performed += instance.OnGamePaused;
                @GamePaused.canceled += instance.OnGamePaused;
            }
        }
    }
    public UIControllerActions @UIController => new UIControllerActions(this);
    public interface IPlayer1ControllerActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
    }
    public interface IPlayer2ControllerActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
    }
    public interface IUIControllerActions
    {
        void OnGamePaused(InputAction.CallbackContext context);
    }
}
