// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Player
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GameMap"",
            ""id"": ""ca799e60-3795-47b6-b23f-4ad3d995e288"",
            ""actions"": [
                {
                    ""name"": ""Player1Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b4843d17-ba91-4ab9-b4a6-c2dd2eaa5dee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Player2Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""abba807d-304b-412e-8159-c5534d34f7ea"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LaunchBall"",
                    ""type"": ""Button"",
                    ""id"": ""27f810c9-a793-4d1e-8ea6-0ac05198024e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d9b2d8cc-5fb7-4ac1-9509-49fc9901936d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""de34239d-2b43-439b-97e9-58ff6bf8b3fb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2c8ee578-3455-4d5a-aa3f-f71b78077a52"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ad388fa9-fae7-4458-ad7c-4ce50015fba1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""855734e3-7199-4da9-b863-c80199d6ac1f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f8592644-5799-4db0-9a33-4bac53decbb5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player2Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""177d17fa-0068-4d32-8f28-005e2818288b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player2Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bc7fc384-be05-4a0d-98f9-bc81e0cb0840"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player2Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0faf993f-1450-45a8-8d05-0159590d70c2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player2Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0b691666-3266-4abd-8533-c9435675566a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player2Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f078747a-c05a-41d4-98b3-40de46008fe6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LaunchBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // GameMap
            m_GameMap = asset.FindActionMap("GameMap", throwIfNotFound: true);
            m_GameMap_Player1Move = m_GameMap.FindAction("Player1Move", throwIfNotFound: true);
            m_GameMap_Player2Move = m_GameMap.FindAction("Player2Move", throwIfNotFound: true);
            m_GameMap_LaunchBall = m_GameMap.FindAction("LaunchBall", throwIfNotFound: true);
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

        // GameMap
        private readonly InputActionMap m_GameMap;
        private IGameMapActions m_GameMapActionsCallbackInterface;
        private readonly InputAction m_GameMap_Player1Move;
        private readonly InputAction m_GameMap_Player2Move;
        private readonly InputAction m_GameMap_LaunchBall;
        public struct GameMapActions
        {
            private @PlayerControls m_Wrapper;
            public GameMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Player1Move => m_Wrapper.m_GameMap_Player1Move;
            public InputAction @Player2Move => m_Wrapper.m_GameMap_Player2Move;
            public InputAction @LaunchBall => m_Wrapper.m_GameMap_LaunchBall;
            public InputActionMap Get() { return m_Wrapper.m_GameMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameMapActions set) { return set.Get(); }
            public void SetCallbacks(IGameMapActions instance)
            {
                if (m_Wrapper.m_GameMapActionsCallbackInterface != null)
                {
                    @Player1Move.started -= m_Wrapper.m_GameMapActionsCallbackInterface.OnPlayer1Move;
                    @Player1Move.performed -= m_Wrapper.m_GameMapActionsCallbackInterface.OnPlayer1Move;
                    @Player1Move.canceled -= m_Wrapper.m_GameMapActionsCallbackInterface.OnPlayer1Move;
                    @Player2Move.started -= m_Wrapper.m_GameMapActionsCallbackInterface.OnPlayer2Move;
                    @Player2Move.performed -= m_Wrapper.m_GameMapActionsCallbackInterface.OnPlayer2Move;
                    @Player2Move.canceled -= m_Wrapper.m_GameMapActionsCallbackInterface.OnPlayer2Move;
                    @LaunchBall.started -= m_Wrapper.m_GameMapActionsCallbackInterface.OnLaunchBall;
                    @LaunchBall.performed -= m_Wrapper.m_GameMapActionsCallbackInterface.OnLaunchBall;
                    @LaunchBall.canceled -= m_Wrapper.m_GameMapActionsCallbackInterface.OnLaunchBall;
                }
                m_Wrapper.m_GameMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Player1Move.started += instance.OnPlayer1Move;
                    @Player1Move.performed += instance.OnPlayer1Move;
                    @Player1Move.canceled += instance.OnPlayer1Move;
                    @Player2Move.started += instance.OnPlayer2Move;
                    @Player2Move.performed += instance.OnPlayer2Move;
                    @Player2Move.canceled += instance.OnPlayer2Move;
                    @LaunchBall.started += instance.OnLaunchBall;
                    @LaunchBall.performed += instance.OnLaunchBall;
                    @LaunchBall.canceled += instance.OnLaunchBall;
                }
            }
        }
        public GameMapActions @GameMap => new GameMapActions(this);
        public interface IGameMapActions
        {
            void OnPlayer1Move(InputAction.CallbackContext context);
            void OnPlayer2Move(InputAction.CallbackContext context);
            void OnLaunchBall(InputAction.CallbackContext context);
        }
    }
}
