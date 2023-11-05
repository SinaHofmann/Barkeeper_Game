//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Settings/Player_Controls.inputactions
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

public partial class @Player_Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Controls"",
    ""maps"": [
        {
            ""name"": ""player_movement"",
            ""id"": ""05f253c8-ee65-4a7e-9a98-c3510dc03744"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""16548991-3537-4719-b791-e9e32296cc93"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""02ef8ad2-e1f7-415f-ac5c-de67b6ddeca7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""pickup"",
                    ""type"": ""Button"",
                    ""id"": ""a143c8be-03da-4b4a-85e9-df2f65a69d3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""de8a05eb-8d38-49c6-b3f7-56cb74535ad9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3781cdb3-9aca-450a-aab4-68eed2c2f66f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""342dc78a-db9f-499a-9521-e253e6eedffe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8f321efe-fea9-417b-b779-235bee518bab"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3cf2986e-aa09-401c-82fb-4ca2faaa71b7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9f9cd61e-33c2-437a-b1ab-7dad86fe2397"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f2143a7-975e-4d51-b844-b0305d75ba91"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player_movement
        m_player_movement = asset.FindActionMap("player_movement", throwIfNotFound: true);
        m_player_movement_movement = m_player_movement.FindAction("movement", throwIfNotFound: true);
        m_player_movement_camera = m_player_movement.FindAction("camera", throwIfNotFound: true);
        m_player_movement_pickup = m_player_movement.FindAction("pickup", throwIfNotFound: true);
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

    // player_movement
    private readonly InputActionMap m_player_movement;
    private IPlayer_movementActions m_Player_movementActionsCallbackInterface;
    private readonly InputAction m_player_movement_movement;
    private readonly InputAction m_player_movement_camera;
    private readonly InputAction m_player_movement_pickup;
    public struct Player_movementActions
    {
        private @Player_Controls m_Wrapper;
        public Player_movementActions(@Player_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_player_movement_movement;
        public InputAction @camera => m_Wrapper.m_player_movement_camera;
        public InputAction @pickup => m_Wrapper.m_player_movement_pickup;
        public InputActionMap Get() { return m_Wrapper.m_player_movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_movementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_movementActions instance)
        {
            if (m_Wrapper.m_Player_movementActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnMovement;
                @camera.started -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnCamera;
                @camera.performed -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnCamera;
                @camera.canceled -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnCamera;
                @pickup.started -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnPickup;
                @pickup.performed -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnPickup;
                @pickup.canceled -= m_Wrapper.m_Player_movementActionsCallbackInterface.OnPickup;
            }
            m_Wrapper.m_Player_movementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @camera.started += instance.OnCamera;
                @camera.performed += instance.OnCamera;
                @camera.canceled += instance.OnCamera;
                @pickup.started += instance.OnPickup;
                @pickup.performed += instance.OnPickup;
                @pickup.canceled += instance.OnPickup;
            }
        }
    }
    public Player_movementActions @player_movement => new Player_movementActions(this);
    public interface IPlayer_movementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
    }
}
