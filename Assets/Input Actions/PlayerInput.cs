// GENERATED AUTOMATICALLY FROM 'Assets/Input Actions/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""371b7449-47e5-463b-81b4-2e2c06794577"",
            ""actions"": [
                {
                    ""name"": ""Swipe"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8afaa6c1-790c-4ae7-958e-30fdedf46529"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""SwipePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1dc7bd45-198f-4290-ba9c-385530235b3c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""39029159-988e-49f1-9b48-09759a9d9415"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gameplay"",
                    ""action"": ""Swipe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68e49759-c167-4771-b924-c6741c6050ff"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwipePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gameplay"",
            ""bindingGroup"": ""Gameplay"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Swipe = m_Main.FindAction("Swipe", throwIfNotFound: true);
        m_Main_SwipePosition = m_Main.FindAction("SwipePosition", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Swipe;
    private readonly InputAction m_Main_SwipePosition;
    public struct MainActions
    {
        private @PlayerInput m_Wrapper;
        public MainActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Swipe => m_Wrapper.m_Main_Swipe;
        public InputAction @SwipePosition => m_Wrapper.m_Main_SwipePosition;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Swipe.started -= m_Wrapper.m_MainActionsCallbackInterface.OnSwipe;
                @Swipe.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnSwipe;
                @Swipe.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnSwipe;
                @SwipePosition.started -= m_Wrapper.m_MainActionsCallbackInterface.OnSwipePosition;
                @SwipePosition.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnSwipePosition;
                @SwipePosition.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnSwipePosition;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Swipe.started += instance.OnSwipe;
                @Swipe.performed += instance.OnSwipe;
                @Swipe.canceled += instance.OnSwipe;
                @SwipePosition.started += instance.OnSwipePosition;
                @SwipePosition.performed += instance.OnSwipePosition;
                @SwipePosition.canceled += instance.OnSwipePosition;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    private int m_GameplaySchemeIndex = -1;
    public InputControlScheme GameplayScheme
    {
        get
        {
            if (m_GameplaySchemeIndex == -1) m_GameplaySchemeIndex = asset.FindControlSchemeIndex("Gameplay");
            return asset.controlSchemes[m_GameplaySchemeIndex];
        }
    }
    public interface IMainActions
    {
        void OnSwipe(InputAction.CallbackContext context);
        void OnSwipePosition(InputAction.CallbackContext context);
    }
}
