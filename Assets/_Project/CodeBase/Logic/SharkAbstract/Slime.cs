using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public abstract class Slime : MonoBehaviour
{
    [field: SerializeField] protected ScoreLevelBar ScoreLevelBar;
    [SerializeField] protected GameObject SharkSkin;
    [SerializeField] protected NickName NickName;
    [SerializeField] protected CapsuleCollider CapsuleCollider;
    [SerializeField] private float _localScaleX = 0.2f;
    [SerializeField] private GameObject _crown;

    private TopSharksManager _topSharkManager;

    protected int Score = 1;
    protected int ParametrRaising = 10;
    protected int ScoreCount;

    private float _radius = 1.3f;

    public int ScoreLevel => Score;
    public event Action OnScoreChanged;

    private void Awake()
    {
        SetInitialSizeBox();
    }

    private void Start() =>
        _topSharkManager.RegisterShark(this);

    private void Update() =>
        IncreaseSize();

    private void OnDestroy() =>
        _topSharkManager.UnregisterShark(this);

    public void Init(TopSharksManager topSharksManager) =>
        _topSharkManager = topSharksManager;

    public void SetInitialSizeBox()
    {
        _radius = 1.3f;

        CapsuleCollider.radius = _radius;
    }

    public abstract string GetSharkName();

    public void SetCrown(bool isActive) => 
        _crown.SetActive(isActive);

    public void AddScore(int score)
    {
        Score += score;
        ScoreLevelBar.SetScore(Score);
        SetPlayerViewWallet();
        OnScoreChanged?.Invoke();
    }

    public virtual void SetPlayerViewWallet() { }
    public virtual void SetPlayerViewHeightCoins() { }

    public void SetBoxCollider() 
    {
        _radius += 0.5f; 

        CapsuleCollider.radius =_radius;
    }
    
    private void IncreaseSize()
    {
        int increase = Score;
        ScoreCount = increase / ParametrRaising;

        if (ScoreCount >= 2)
        {
            SharkSkin.transform.localScale += new Vector3(_localScaleX, _localScaleX, _localScaleX);
            ParametrRaising *= 3;
            ScoreLevelBar.IncreasePositionY();
            SetBoxCollider();
            SetPlayerViewHeightCoins();
        }
    }
}
