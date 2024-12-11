using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GameObject _joystickPanel;
    [SerializeField] private Image _joystick;

    private Vector2 _inputVector;
    public Vector2 InputVector => _inputVector;

    private void Awake()
    {
        HideJoystick();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShowJoystick();
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector2.zero;
        HideJoystick();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystick.rectTransform, eventData.position, eventData.pressEventCamera, out pos);

        pos.x = (pos.x / _joystick.rectTransform.sizeDelta.x);
        pos.y = (pos.y / _joystick.rectTransform.sizeDelta.y);

        _inputVector = new Vector2(pos.x * 2, pos.y * 2);
        _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

        _joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_joystick.rectTransform.sizeDelta.x / 2), _inputVector.y * (_joystick.rectTransform.sizeDelta.y / 2));
    }

    private void ShowJoystick()
    {
        _joystickPanel.SetActive(true);
        _joystick.enabled = true;
    }

    private void HideJoystick()
    {
        _joystickPanel.SetActive(false);
        _joystick.enabled = false;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}
