using Assets.Project.CodeBase.Player.UI;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject _screenStick;

    private PlayerInput _input;
    private PlayerData _playerData;
    private BoostButtonUI _boostButtonUI;
    private bool _isBoosting;
    private float _boostTimeRemaining;

    private void Awake() =>
        _input = new PlayerInput();

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Boost.started += OnBoostInputStarted;
        _input.Player.Boost.canceled += OnBoostInputCanceled;
    }

    private void Update()
    {
        if (Application.isMobilePlatform)
        {
            _screenStick.gameObject.SetActive(true);
            _boostButtonUI.gameObject.SetActive(true);
        }

        Vector2 moveDirection = _input.Player.Move.ReadValue<Vector2>();
        MoveAgent(moveDirection);

        CheckDelayBoost();
    }


    private void OnDisable()
    {
        _input.Disable();
        _input.Player.Boost.started -= OnBoostInputStarted;
        _input.Player.Boost.canceled -= OnBoostInputCanceled;
    }

    public void Construct(PlayerData playerData, BoostButtonUI boostButtonUI)
    {
        _playerData = playerData;
        _boostButtonUI = boostButtonUI;

        _boostButtonUI.Initialize(this);
    }

    public void AgentEnable() =>
        _agent.enabled = true;

    public void AgentDisable() =>
        _agent.enabled = false;

    public void OnBoostStarted()
    {
        if (_boostTimeRemaining > 0)
            _isBoosting = true;
    }

    public void OnBoostCanceled() =>
        _isBoosting = false;

    private void MoveAgent(Vector2 direction)
    {
        Vector3 newDirection = new Vector3(direction.x, 0, direction.y);
        Quaternion cameraRotationY = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        MoveCharacter(newDirection, cameraRotationY);
        RotateCharacter(newDirection, cameraRotationY);
    }

    private void MoveCharacter(Vector3 moveDirection, Quaternion cameraRotation)
    {
        Vector3 finalDirection = (cameraRotation * moveDirection).normalized;
        float currentSpeed = _isBoosting ? _playerData.MoveSpeed * _playerData.BoostMultiplier : _playerData.MoveSpeed;

        _agent.Move(finalDirection * currentSpeed * Time.deltaTime);
    }

    private void RotateCharacter(Vector3 moveDirection, Quaternion cameraRotation)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 finalDirection = (cameraRotation * moveDirection).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(finalDirection);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _playerData.RotateSpeed * Time.deltaTime);
        }
    }
    
    private void CheckDelayBoost()
    {
        if (_isBoosting)
        {
            _boostTimeRemaining -= Time.deltaTime;

            if (_boostTimeRemaining <= 0)
            {
                _isBoosting = false;
                _boostTimeRemaining = 0;
            }
        }
        else if (_boostTimeRemaining < _playerData.BoostDuration)
            _boostTimeRemaining += Time.deltaTime / _playerData.BoostRecoveryTime * _playerData.BoostDuration;
    }

    private void OnBoostInputStarted(UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        OnBoostStarted();

    private void OnBoostInputCanceled(UnityEngine.InputSystem.InputAction.CallbackContext context) =>
        OnBoostCanceled();
}
