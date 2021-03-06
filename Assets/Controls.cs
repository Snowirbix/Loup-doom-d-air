// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""FreeMovement"",
            ""id"": ""52059206-6a15-42c4-b2a2-acbde8f9a09a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""910c9106-0796-4f8c-aadd-93e5f5ed9d2f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d28c37a7-887b-4a4c-b384-1048bcc9603f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""33a8cd74-ca02-48ca-8cd7-f829e6d2f9b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""08746ba1-b65b-4e24-9b3a-c834b9593d60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Continue"",
                    ""type"": ""Button"",
                    ""id"": ""3037ce8e-ca9a-4353-a40c-8903154d7cfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""69354e46-801e-4b98-839e-4aa0569b9035"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e4c48b38-13d5-4575-b2c8-f9bb5cf051b7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ef645848-8e85-46f8-a3a1-5674fa21a310"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""67c2be29-c5db-4284-8408-a810591e36ab"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2a60148d-c2b1-4bcc-93a2-bd106b38292a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ARROWS"",
                    ""id"": ""fac18bae-ab54-4c7a-a0e3-aa8a25e6bc38"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6f69aef1-5d74-4e90-be1b-47724a229195"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5d48a320-dae8-4ba3-880e-78e715935e71"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f28bb23-07c9-4997-b5ed-635d0ee0b78c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6b7f701a-36f9-456f-a40f-13e0dd7e75a3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0360a657-4753-487c-bf9c-5dbf1859d9f3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0663a15c-4b91-4e07-b0b3-e0fa8a8f33e1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e784af62-5e18-4cd9-9ac1-76c7f0da608e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5326b980-be98-4bbe-b4c7-6196aea6a612"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a503fa9e-f723-488c-b024-9cfae9bc1619"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f3da2a6-dc6d-4986-ae2c-b4154530e7f9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0168f578-df73-42cb-982e-5eb9af1477e4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13e407a7-10c0-4401-9216-7232d9e5258d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48c4c714-fe49-4245-a39d-6016814325e4"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Continue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fad002ef-72db-4ecc-92f4-9f5887e6c0d1"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Continue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // FreeMovement
        m_FreeMovement = asset.FindActionMap("FreeMovement", throwIfNotFound: true);
        m_FreeMovement_Move = m_FreeMovement.FindAction("Move", throwIfNotFound: true);
        m_FreeMovement_Attack = m_FreeMovement.FindAction("Attack", throwIfNotFound: true);
        m_FreeMovement_Jump = m_FreeMovement.FindAction("Jump", throwIfNotFound: true);
        m_FreeMovement_Dash = m_FreeMovement.FindAction("Dash", throwIfNotFound: true);
        m_FreeMovement_Continue = m_FreeMovement.FindAction("Continue", throwIfNotFound: true);
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

    // FreeMovement
    private readonly InputActionMap m_FreeMovement;
    private IFreeMovementActions m_FreeMovementActionsCallbackInterface;
    private readonly InputAction m_FreeMovement_Move;
    private readonly InputAction m_FreeMovement_Attack;
    private readonly InputAction m_FreeMovement_Jump;
    private readonly InputAction m_FreeMovement_Dash;
    private readonly InputAction m_FreeMovement_Continue;
    public struct FreeMovementActions
    {
        private @Controls m_Wrapper;
        public FreeMovementActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_FreeMovement_Move;
        public InputAction @Attack => m_Wrapper.m_FreeMovement_Attack;
        public InputAction @Jump => m_Wrapper.m_FreeMovement_Jump;
        public InputAction @Dash => m_Wrapper.m_FreeMovement_Dash;
        public InputAction @Continue => m_Wrapper.m_FreeMovement_Continue;
        public InputActionMap Get() { return m_Wrapper.m_FreeMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FreeMovementActions set) { return set.Get(); }
        public void SetCallbacks(IFreeMovementActions instance)
        {
            if (m_Wrapper.m_FreeMovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnAttack;
                @Jump.started -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnJump;
                @Dash.started -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnDash;
                @Continue.started -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnContinue;
                @Continue.performed -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnContinue;
                @Continue.canceled -= m_Wrapper.m_FreeMovementActionsCallbackInterface.OnContinue;
            }
            m_Wrapper.m_FreeMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Continue.started += instance.OnContinue;
                @Continue.performed += instance.OnContinue;
                @Continue.canceled += instance.OnContinue;
            }
        }
    }
    public FreeMovementActions @FreeMovement => new FreeMovementActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IFreeMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnContinue(InputAction.CallbackContext context);
    }
}
