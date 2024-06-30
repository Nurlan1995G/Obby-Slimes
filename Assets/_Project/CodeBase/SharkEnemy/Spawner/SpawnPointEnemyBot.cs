using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using UnityEngine;

public class SpawnPointEnemyBot : MonoBehaviour
{
    private FactoryShark _factoryShark;
    private PositionStaticData _sharkPositionStaticData;
    private PlayerView _playerView;
    private SpawnerFish _spawnerFish;
    private SharkBotData _sharkBotData;
    private TopSharksManager _topSharkManager;

    public void Construct(FactoryShark factoryShark, PositionStaticData sharkPositionStaticData,
        PlayerView playerView, SpawnerFish spawnerFish, GameConfig gameConfig, TopSharksManager topSharksManager)
    { 
        _factoryShark = factoryShark;
        _sharkPositionStaticData = sharkPositionStaticData;
        _playerView = playerView;
        _spawnerFish = spawnerFish;
        _sharkBotData = gameConfig.SharkBotData;
        _topSharkManager = topSharksManager;
    }

    private void Update()
    {
        FindMissingSharks();
    }

    private void FindMissingSharks()
    {
        foreach (var sharkTag in AssetAdress.SharkBotsTag)
        {
            GameObject shark = StaticClassLogic.FindObject(sharkTag);

            if (shark == null)
                RespawnBotShark(sharkTag);
        }
    }

    private void RespawnBotShark(string sharkTag)
    {
        Vector3 position;
        string sharkEnemy;
        string nickName;

        if (sharkTag == "Shark1")
        {
            position = _sharkPositionStaticData.InitSharkOnePosition;
            sharkEnemy = AssetAdress.SharkEnemy1;
            nickName = AssetAdress.NickBot1;
        }
        else if (sharkTag == "Shark2")
        {
            position = _sharkPositionStaticData.InitSharkTwoPosition;
            sharkEnemy = AssetAdress.SharkEnemy2;
            nickName = AssetAdress.NickBot2;
        }
        else if (sharkTag == "Shark3")
        {
            position = _sharkPositionStaticData.InitSharkThreePosition;
            sharkEnemy = AssetAdress.SharkEnemy3;
            nickName = AssetAdress.NickBot3;
        }
        else if (sharkTag == "Shark4")
        {
            position = _sharkPositionStaticData.InitSharkFourPosition;
            sharkEnemy = AssetAdress.SharkEnemy4;
            nickName = AssetAdress.NickBot4;
        }
        else if (sharkTag == "Shark5")
        {
            position = _sharkPositionStaticData.InitSharkFivePosition;
            sharkEnemy = AssetAdress.SharkEnemy5;
            nickName = AssetAdress.NickBot5;
        }
        else if (sharkTag == "Shark6")
        {
            position = _sharkPositionStaticData.InitSharkSixPosition;
            sharkEnemy = AssetAdress.SharkEnemy6;
            nickName = AssetAdress.NickBot6;
        }
        else if (sharkTag == "Shark7")
        {
            position = _sharkPositionStaticData.InitSharkSevenPosition;
            sharkEnemy = AssetAdress.SharkEnemy7;
            nickName = AssetAdress.NickBot7;
        }
        else
            return;

        BotSharkView botShark = CreateSharkScene(position, sharkEnemy);
        botShark.Construct(_spawnerFish, _sharkBotData, _playerView, _topSharkManager);
        botShark.SetNickname(nickName);
    }

    private BotSharkView CreateSharkScene(Vector3 positionShark, string sharkEnemy)
    {
        BotSharkView botShark = _factoryShark.CreateSharkEnemy(sharkEnemy, positionShark);
        return botShark;
    }
}
