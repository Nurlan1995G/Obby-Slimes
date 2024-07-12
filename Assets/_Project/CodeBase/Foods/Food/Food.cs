using System;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    [field: SerializeField] public GameObject FoodScale;
    [SerializeField] protected ScoreLevelBarFood ScoreLevelBarFish;

    private Slime _playerView;

    public event Action<Food> FoodDied;

    [field: SerializeField] public TypeFood TypeFood { get; private set; }
    public int ScoreLevel { get; protected set; }

    public void Construct(Slime playerView) =>
        _playerView = playerView;
    
    private void Start()
    {
        ScoreLevelBarFish.ScoreText.text = ScoreLevel.ToString();
    }

    private void Update() =>
        UpdateScoreTextColor();

    public void Destroys()
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
                ScoreLevelBarFish.ScoreText.color = Color.green;
            else
                ScoreLevelBarFish.ScoreText.color = Color.red;
        }
    }
}
