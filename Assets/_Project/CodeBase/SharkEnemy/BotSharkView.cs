using Assets.Project.CodeBase.SharkEnemy;
using Assets.Project.CodeBase.SharkEnemy.StateMashine;
using UnityEngine;
using UnityEngine.AI;

public class BotSharkView : MonoBehaviour   
{   
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private SharkModel _sharkModel;
        
    private SpawnerFish _spawner;
    private SharkBotData _sharkBotData;
    private PlayerView _player;
    private SharkBotStateMachine _stateMashine;

    private void Start() =>
        _stateMashine = new SharkBotStateMachine(_agent, _sharkModel, _sharkBotData, _player, _spawner);

    private void Update() =>
        _stateMashine?.Update();

    public void Construct(SpawnerFish spawner, SharkBotData sharkBotData, PlayerView player, TopSharksManager topSharksManager)
    {
        _spawner = spawner;
        _sharkBotData = sharkBotData;
        _player = player;
        _sharkModel.Init(topSharksManager);
    }

    public void SetNickname(string nickName) =>
        _sharkModel.SetNickName(nickName);
}
