using TMPro;
using UnityEngine;

public class ScoreLevelBar : MonoBehaviour
{
    [field: SerializeField] public TextMeshProUGUI ScoreText;
    [field: SerializeField] public RectTransform CanvasRectTransform; 
    [SerializeField] private float _height = 0.1f;
    [SerializeField] private float _positionY = 3f;

    private void Start()
    {
        SetInitialPositionY();
    }

    public void SetInitialPositionY()
    {
        Vector2 newPosition = CanvasRectTransform.anchoredPosition;
        newPosition.y = _positionY;
        CanvasRectTransform.anchoredPosition = newPosition;
    }

    public void SetScore(int score)
    {
        ScoreText.text = score.ToString();
    }

    public void IncreasePositionY()
    {
        Vector2 newPosition = CanvasRectTransform.anchoredPosition;
        newPosition.y += _height;
        CanvasRectTransform.anchoredPosition = newPosition;
    }
}
