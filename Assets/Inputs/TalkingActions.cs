// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/TalkingActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TalkingActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TalkingActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TalkingActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""205e2b19-562d-45d5-90cc-0222e1aa2bc8"",
            ""actions"": [
                {
                    ""name"": ""Positive"",
                    ""type"": ""Button"",
                    ""id"": ""4b8fe153-6441-4602-b152-3256f4491bb9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CardThrow"",
                    ""type"": ""Button"",
                    ""id"": ""3fadebb4-dc85-4f66-9379-a0164a507649"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a43cc22b-133a-4aab-ae55-97c2bca92b98"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Positive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dd24d26-8b71-4a4c-aeb7-7c2549f6d0f0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CardThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Positive = m_Player.FindAction("Positive", throwIfNotFound: true);
        m_Player_CardThrow = m_Player.FindAction("CardThrow", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Positive;
    private readonly InputAction m_Player_CardThrow;
    public struct PlayerActions
    {
        private @TalkingActions m_Wrapper;
        public PlayerActions(@TalkingActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Positive => m_Wrapper.m_Player_Positive;
        public InputAction @CardThrow => m_Wrapper.m_Player_CardThrow;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Positive.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPositive;
                @Positive.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPositive;
                @Positive.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPositive;
                @CardThrow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardThrow;
                @CardThrow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardThrow;
                @CardThrow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCardThrow;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Positive.started += instance.OnPositive;
                @Positive.performed += instance.OnPositive;
                @Positive.canceled += instance.OnPositive;
                @CardThrow.started += instance.OnCardThrow;
                @CardThrow.performed += instance.OnCardThrow;
                @CardThrow.canceled += instance.OnCardThrow;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPositive(InputAction.CallbackContext context);
        void OnCardThrow(InputAction.CallbackContext context);
    }
}
