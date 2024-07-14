using Assets.CodeBase.CameraLogic;
using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Player.Respawn;
using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private SpawnerFood _spawner;
    [SerializeField] private PositionStaticData _positionStaticData;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private List<SpawnPointEnemyBot> _spawnPoints;
    [SerializeField] private CameraRotator _cameraRotater;
    [SerializeField] private ConfigFood _configFood;
    [SerializeField] private UIPopup _uiPopup;
    [SerializeField] private BoostButtonUI _boostButtonUI;
    [SerializeField] private TopSharksUI _topSharksUI;
    [SerializeField] private SoundHandler _soundHandler;

    private void Awake()
    {
        AssetProvider assetProvider = new AssetProvider();
        ServesSelectTypeFood random = new ServesSelectTypeFood(_configFood);
        TopSharksManager topSharksManager = new TopSharksManager();
        FactoryShark factoryShark = new FactoryShark(assetProvider);
        RespawnSlime respawnSlime = new RespawnSlime();
        PlayerInput playerInput = new PlayerInput();

        InitSpawner(assetProvider, random);
        WriteSpawnPoint(factoryShark, topSharksManager);
        InitPlayer(topSharksManager, respawnSlime, playerInput);
        InitCamera();
        InitUI(topSharksManager);
        InitBoostUI();
    }

    private void InitSpawner(AssetProvider assetProvider, ServesSelectTypeFood random) =>
        _spawner.Construct(new FoodFactory(_configFood, assetProvider), random, _playerView, _configFood);

    private void InitCamera() =>
        _cameraRotater.Construct(_gameConfig);

    private void InitPlayer(TopSharksManager topSharksManager, RespawnSlime respawnSlime,
        PlayerInput playerInput)
    {
        _playerView.Construct(_positionStaticData, _gameConfig, _uiPopup, _boostButtonUI, _soundHandler, respawnSlime, playerInput);
        _playerView.Init(topSharksManager);
    }

    private void InitUI(TopSharksManager topSharksManager) =>
        _topSharksUI.Construct(topSharksManager);

    private void WriteSpawnPoint(FactoryShark factoryShark, TopSharksManager topSharksManager)
    {
        foreach (SpawnPointEnemyBot spawnPoint in _spawnPoints)
            spawnPoint.Construct(factoryShark, _positionStaticData, _playerView, _spawner, _gameConfig, topSharksManager);
    }

    private void InitBoostUI()
    {
        if (Application.isMobilePlatform)
            _boostButtonUI.SetMobilePlatform();
    }
}
