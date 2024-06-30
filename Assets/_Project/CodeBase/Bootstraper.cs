using Assets.CodeBase.CameraLogic;
using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private SpawnerFish _spawner;
    [SerializeField] private FishStaticData _fishStaticData;
    [SerializeField] private PositionStaticData _positionStaticData;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private List<SpawnPointEnemyBot> _spawnPoints;
    [SerializeField] private CameraRotater _cameraRotater;
    [SerializeField] private ConfigFish _configFish;
    [SerializeField] private UIPopup _uiPopup;
    [SerializeField] private BoostButtonUI _boostButtonUI;
    [SerializeField] private TopSharksUI _topSharksUI;
    [SerializeField] private SoundHandler _soundHandler;

    private void Awake()
    {
        AssetProvider assetProvider = new AssetProvider();
        ServesSelectTypeFish random = new ServesSelectTypeFish(_configFish);
        TopSharksManager topSharksManager = new TopSharksManager();

        _spawner.Construct(new FishFactory(_configFish, assetProvider), random, _playerView, _configFish);

        FactoryShark factoryShark = new FactoryShark(assetProvider);
        
        WriteSpawnPoint(factoryShark, topSharksManager);

        _playerView.Construct(_positionStaticData, _gameConfig, _uiPopup, _boostButtonUI, _soundHandler);
        _playerView.Init(topSharksManager);

        _cameraRotater.Construct(_gameConfig);

        _topSharksUI.Construct(topSharksManager);
    }

    private void WriteSpawnPoint(FactoryShark factoryShark, TopSharksManager topSharksManager)
    {
        foreach (SpawnPointEnemyBot spawnPoint in _spawnPoints)
            spawnPoint.Construct(factoryShark, _positionStaticData, _playerView, _spawner, _gameConfig, topSharksManager);
    }
}
