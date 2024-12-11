using Assets.Project.CodeBase.SharkEnemy;
using Assets.Project.CodeBase.SharkEnemy.StateMashine;
using UnityEngine;
using UnityEngine.AI;

public class BotSlimeView : MonoBehaviour   
{   
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private SlimeModel _sharkModel;
        
    private SpawnerFood _spawner;
    private SlimeBotData _sharkBotData;
    private PlayerView _player;
    private SlimeBotStateMachine _stateMashine;

    private void Start() =>
        _stateMashine = new SlimeBotStateMachine(_agent, _sharkModel, _sharkBotData, _player, _spawner);

    private void Update() =>
        _stateMashine?.Update();

    public void Construct(SpawnerFood spawner, SlimeBotData sharkBotData, PlayerView player, TopSharksManager topSharksManager)
    {
        _spawner = spawner;
        _sharkBotData = sharkBotData;
        _player = player;
        _sharkModel.Init(topSharksManager);
    }

    public void SetNickname(string nickName) =>
        _sharkModel.SetNickName(nickName);
}
