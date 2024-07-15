using Assets._Project.CodeBase.Foods.Interface;
using System;
using UnityEngine;

public abstract class Food : MonoBehaviour, IDestroyFood
{
    [field: SerializeField] public GameObject FoodScale;
    [SerializeField] protected ScoreLevelBarFood ScoreLevelBarFood;

    private Slime _playerView;

    public event Action<Food> FoodDied;

    [field: SerializeField] public TypeFood TypeFood { get; private set; }
    public int ScoreLevel { get; protected set; }

    public void Construct(Slime playerView) =>
        _playerView = playerView;
    
    private void Start()
    {
        ScoreLevelBarFood.ScoreText.text = ScoreLevel.ToString();
    }

    private void Update() =>
        UpdateScoreTextColor();

    public void Destroy()
    {
        FoodDied?.Invoke(this);
        Destroy(gameObject);
    }

    public abstract int WriteScoreLevel(int score);

    private void UpdateScoreTextColor()
    {
        if (_playerView != null)
        {
            if (_playerView.ScoreLevel >= ScoreLevel)
                ScoreLevelBarFood.ScoreText.color = Color.green;
            else
                ScoreLevelBarFood.ScoreText.color = Color.red;
        }
    }
}
