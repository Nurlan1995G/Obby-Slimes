using System;
using UnityEngine;

public abstract class Food : MonoBehaviour
{
    [SerializeField] protected ScoreLevelBarFood ScoreLevelBarFish;
    [field: SerializeField] public GameObject FoodScale;

    private Slime _playerView;

    public event Action<Food> FishDied;

    public int ScoreLevel { get; protected set; }

    private void Start()
    {
        //WriteScoreLevel();
        ScoreLevelBarFish.ScoreText.text = ScoreLevel.ToString();
    }

    private void Update()
    {
        UpdateScoreTextColor();
    }

    public void Construct(Slime playerView)
    {
        _playerView = playerView;
    }

    public void Destroys()
    {
        FishDied?.Invoke(this);
        Destroy(gameObject);
    }

    public abstract int WriteScoreLevel(int score);

    private void UpdateScoreTextColor()
    {
        if (_playerView != null)
        {
            if (_playerView.ScoreLevel >= ScoreLevel)
            {
                ScoreLevelBarFish.ScoreText.color = Color.green;
            }
            else
            {
                ScoreLevelBarFish.ScoreText.color = Color.red;
            }
        }
    }
}
