using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField, Range(0, 500)] private float _mouseRotationSpeed;

    private float _currentRotation = 0;

    private MouseInput _mouseInput;

    private void Awake()
    {
        _mouseInput = new MouseInput();
        _mouseInput.Enable();
    }

    private void Update()
    {
        float mouseX = _mouseInput.Mouse.LeftButtonMouse.ReadValue<float>();

        if (_mouseInput.Mouse.LeftButtonMouse.IsPressed())
            _currentRotation -= _mouseRotationSpeed * mouseX * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, _currentRotation, 0);
    }

    public void Reset()
    {
        _currentRotation = 0;
        transform.rotation = Quaternion.Euler(0, _currentRotation, 0);
    }
}