using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public abstract class Shark : MonoBehaviour
{
    [field: SerializeField] protected ScoreLevelBar ScoreLevelBar;
    [SerializeField] protected NickName NickName;
    [SerializeField] private float _localScaleX = 0.2f;
    [SerializeField] private GameObject _crown;
    [SerializeField] protected GameObject SharkSkin;
    [SerializeField] protected BoxCollider BoxCollider;

    private TopSharksManager _topSharkManager;

    protected int Score = 1;
    protected int ParametrRaising = 10;
    protected int ScoreCount;

    private float _centerZ = -0.35f;
    private float _sizeX = 0.8f;
    private float _sizeZ = 1.5f;

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
        _centerZ = -0.35f;
        _sizeX = 0.8f;
        _sizeZ = 1.5f;

        BoxCollider.center = new Vector3(0, 0, _centerZ);
        BoxCollider.size = new Vector3(_sizeX, 0.3f, _sizeZ);
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
        _centerZ -= 0.3f;
        _sizeX += 0.5f;
        _sizeZ += 1f;

        BoxCollider.center = new Vector3(0, 0, _centerZ);
        BoxCollider.size = new Vector3(_sizeX, 0.5f, _sizeZ);
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
