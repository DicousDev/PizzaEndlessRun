//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/ScriptableObjects/Input/PlayerKeyboardInputAction.inputactions
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

namespace EndlessRunner.Character.Player.Input.Keyboard
{
    public partial class @PlayerKeyboardInputAction : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerKeyboardInputAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerKeyboardInputAction"",
    ""maps"": [
        {
            ""name"": ""Player Actions"",
            ""id"": ""c0529d60-646c-4d12-8d96-20f5f5403e02"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""10699b85-5112-4af9-8b97-5cd738f2a894"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""86b9047a-58df-4327-b89e-d1685a813157"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cf2b4553-21a9-424c-a77b-6d6054379b4b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b7159d9-6417-480f-8680-c79bdf89e3e0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6206ac51-aabe-4885-8cbc-9900fcc38349"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc86f5c7-1c7b-4835-898c-8c74ee8dd0c1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f538e74-62a6-43c9-92e8-94c87889052a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""id"": ""d233f303-99aa-4d32-9a90-452ed2742ead"",
            ""actions"": [
                {
                    ""name"": ""TouchInput"",
                    ""type"": ""Button"",
                    ""id"": ""7ceb2427-d829-4ce7-90ab-5597c0f94a21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""19d4d701-f5b6-4338-a378-ffd7b336efcf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""992a8814-5589-429b-8fa4-fc18a58a51d7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""686c95de-b1c8-4916-b77d-c3996c6f7e42"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dddb05bb-ed69-49c4-9703-35d3fc937b63"",
                    ""path"": ""<Touchscreen>/primaryTouch/indirectTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""611f2574-bde5-49f9-9db6-3373ef5b378f"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player Actions
            m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
            m_PlayerActions_MoveLeft = m_PlayerActions.FindAction("MoveLeft", throwIfNotFound: true);
            m_PlayerActions_MoveRight = m_PlayerActions.FindAction("MoveRight", throwIfNotFound: true);
            m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
            // Touch
            m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
            m_Touch_TouchInput = m_Touch.FindAction("TouchInput", throwIfNotFound: true);
            m_Touch_TouchPress = m_Touch.FindAction("TouchPress", throwIfNotFound: true);
            m_Touch_TouchPosition = m_Touch.FindAction("TouchPosition", throwIfNotFound: true);
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

        // Player Actions
        private readonly InputActionMap m_PlayerActions;
        private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
        private readonly InputAction m_PlayerActions_MoveLeft;
        private readonly InputAction m_PlayerActions_MoveRight;
        private readonly InputAction m_PlayerActions_Jump;
        public struct PlayerActionsActions
        {
            private @PlayerKeyboardInputAction m_Wrapper;
            public PlayerActionsActions(@PlayerKeyboardInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveLeft => m_Wrapper.m_PlayerActions_MoveLeft;
            public InputAction @MoveRight => m_Wrapper.m_PlayerActions_MoveRight;
            public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
            public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActionsActions instance)
            {
                if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
                {
                    @MoveLeft.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMoveLeft;
                    @MoveRight.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMoveRight;
                    @MoveRight.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMoveRight;
                    @MoveRight.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnMoveRight;
                    @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveLeft.started += instance.OnMoveLeft;
                    @MoveLeft.performed += instance.OnMoveLeft;
                    @MoveLeft.canceled += instance.OnMoveLeft;
                    @MoveRight.started += instance.OnMoveRight;
                    @MoveRight.performed += instance.OnMoveRight;
                    @MoveRight.canceled += instance.OnMoveRight;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

        // Touch
        private readonly InputActionMap m_Touch;
        private ITouchActions m_TouchActionsCallbackInterface;
        private readonly InputAction m_Touch_TouchInput;
        private readonly InputAction m_Touch_TouchPress;
        private readonly InputAction m_Touch_TouchPosition;
        public struct TouchActions
        {
            private @PlayerKeyboardInputAction m_Wrapper;
            public TouchActions(@PlayerKeyboardInputAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @TouchInput => m_Wrapper.m_Touch_TouchInput;
            public InputAction @TouchPress => m_Wrapper.m_Touch_TouchPress;
            public InputAction @TouchPosition => m_Wrapper.m_Touch_TouchPosition;
            public InputActionMap Get() { return m_Wrapper.m_Touch; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
            public void SetCallbacks(ITouchActions instance)
            {
                if (m_Wrapper.m_TouchActionsCallbackInterface != null)
                {
                    @TouchInput.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                    @TouchInput.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                    @TouchInput.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchInput;
                    @TouchPress.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPress.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPress.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress;
                    @TouchPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                    @TouchPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                    @TouchPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition;
                }
                m_Wrapper.m_TouchActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @TouchInput.started += instance.OnTouchInput;
                    @TouchInput.performed += instance.OnTouchInput;
                    @TouchInput.canceled += instance.OnTouchInput;
                    @TouchPress.started += instance.OnTouchPress;
                    @TouchPress.performed += instance.OnTouchPress;
                    @TouchPress.canceled += instance.OnTouchPress;
                    @TouchPosition.started += instance.OnTouchPosition;
                    @TouchPosition.performed += instance.OnTouchPosition;
                    @TouchPosition.canceled += instance.OnTouchPosition;
                }
            }
        }
        public TouchActions @Touch => new TouchActions(this);
        public interface IPlayerActionsActions
        {
            void OnMoveLeft(InputAction.CallbackContext context);
            void OnMoveRight(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface ITouchActions
        {
            void OnTouchInput(InputAction.CallbackContext context);
            void OnTouchPress(InputAction.CallbackContext context);
            void OnTouchPosition(InputAction.CallbackContext context);
        }
    }
}
