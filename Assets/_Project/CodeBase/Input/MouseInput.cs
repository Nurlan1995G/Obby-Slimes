//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Project/CodeBase/Input/MouseInput.inputactions
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

public partial class @MouseInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MouseInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MouseInput"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""15a3bf98-721c-4ca6-ba32-b5ac94e0dae1"",
            ""actions"": [
                {
                    ""name"": ""LeftButtonMouse"",
                    ""type"": ""Value"",
                    ""id"": ""b40041c8-113a-4b72-bf0d-d8dde0946df4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0c09ef62-76c8-46e3-8271-c02062bddb53"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButtonMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_LeftButtonMouse = m_Mouse.FindAction("LeftButtonMouse", throwIfNotFound: true);
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

    // Mouse
    private readonly InputActionMap m_Mouse;
    private List<IMouseActions> m_MouseActionsCallbackInterfaces = new List<IMouseActions>();
    private readonly InputAction m_Mouse_LeftButtonMouse;
    public struct MouseActions
    {
        private @MouseInput m_Wrapper;
        public MouseActions(@MouseInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftButtonMouse => m_Wrapper.m_Mouse_LeftButtonMouse;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void AddCallbacks(IMouseActions instance)
        {
            if (instance == null || m_Wrapper.m_MouseActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MouseActionsCallbackInterfaces.Add(instance);
            @LeftButtonMouse.started += instance.OnLeftButtonMouse;
            @LeftButtonMouse.performed += instance.OnLeftButtonMouse;
            @LeftButtonMouse.canceled += instance.OnLeftButtonMouse;
        }

        private void UnregisterCallbacks(IMouseActions instance)
        {
            @LeftButtonMouse.started -= instance.OnLeftButtonMouse;
            @LeftButtonMouse.performed -= instance.OnLeftButtonMouse;
            @LeftButtonMouse.canceled -= instance.OnLeftButtonMouse;
        }

        public void RemoveCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMouseActions instance)
        {
            foreach (var item in m_Wrapper.m_MouseActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MouseActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IMouseActions
    {
        void OnLeftButtonMouse(InputAction.CallbackContext context);
    }
}
