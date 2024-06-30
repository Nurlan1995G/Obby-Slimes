using Assets.Project.CodeBase.SharkEnemy.StateMashine.State;
using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;
using Assets.Project.AssetProviders;

public class DetecterToObject
{
    private readonly AgentMoveState _agentMoveState;
    private readonly SharkModel _sharkModel;
    private readonly SharkBotData _sharkBotData;

    private float _timeLastDetected;
    private float _cooldownTimer;
    private bool _isChasing = true;

    public DetecterToObject( AgentMoveState agentMoveState,  SharkModel sharkModel, SharkBotData sharkBotData)
    {
        _agentMoveState = agentMoveState;
        _sharkModel = sharkModel;
        _sharkBotData = sharkBotData;
    }

    public void DetectObject(Transform transform)
    {
        GameObject targetPlayer = StaticClassLogic.FindObject(AssetAdress.PlayerTag);

        FindMissingShark(transform, targetPlayer);

        if (targetPlayer != null)
        {
            if (_agentMoveState.IsObjectNotReached(targetPlayer, transform) && targetPlayer.CompareTag(AssetAdress.PlayerTag))
            {
                if (_isChasing)
                {
                    if (targetPlayer.GetComponent<PlayerView>().ScoreLevel > _sharkModel.ScoreLevel)
                        FleeFromObject(targetPlayer, transform);
                    else
                        PositionPlayerObject(targetPlayer, transform);
                }
            }
        }

        GetDelayTime();
    }

    private void GetDelayTime()
    {
        if (!_isChasing && _cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;

            if (_cooldownTimer < 0)
                _isChasing = true;
        }
    }

    private void FindMissingShark(Transform transform, GameObject targetPlayer)
    {
        foreach (var sharkTag in AssetAdress.SharkBotsTag)
        {
            GameObject targetShark = StaticClassLogic.FindObject(sharkTag);

            if(targetShark != null)
            {
                SharkModel sharkModel = targetShark.GetComponent<SharkModel>(); 
                
                if (sharkModel != _sharkModel)
                {
                    if (_agentMoveState.IsObjectNotReached(sharkModel.gameObject, transform) 
                    && !_agentMoveState.IsObjectNotReached(targetPlayer, transform))
                    {
                        if (_isChasing)
                        {
                            if (sharkModel.ScoreLevel > _sharkModel.ScoreLevel
                                && _sharkModel.ScoreLevel > 1)
                                FleeFromObject(sharkModel.gameObject, transform);
                            else
                                PositionSharkObject(sharkModel.gameObject, transform);
                        }
                    }
                }
            }
        }
    }

    private void FleeFromObject(GameObject targetPlayer, Transform transform)
    {
        Vector3 fleeDirection = transform.position - targetPlayer.transform.position;
        Vector3 targetDirection = transform.position + fleeDirection;

        _agentMoveState.MoveTo(targetDirection, transform);
    }

    private void PositionSharkObject(GameObject positionShark, Transform transform)
    {
        if (_isChasing)
        {
            if (positionShark.GetComponent<SharkModel>().ScoreLevel < _sharkModel.ScoreLevel
                && positionShark.GetComponent<SharkModel>().ScoreLevel > 1)
            {
                if (_timeLastDetected < _sharkBotData.StoppingTimeChase)
                {
                    _agentMoveState.MoveTo(positionShark.transform.position, transform);

                    _timeLastDetected += Time.deltaTime;
                }
                else
                    ResetTimePursuit();
            }
        }
    }

    private void PositionPlayerObject(GameObject positionTarget, Transform transform)
    {
        if (_isChasing)
        {
            if (positionTarget.GetComponent<PlayerView>().ScoreLevel < _sharkModel.ScoreLevel
                && positionTarget.GetComponent<PlayerView>().ScoreLevel > 1)
            {
                if (_timeLastDetected < _sharkBotData.StoppingTimeChase)
                {
                    _agentMoveState.MoveTo(positionTarget.transform.position, transform);

                    _timeLastDetected += Time.deltaTime;
                }
                else
                    ResetTimePursuit();
            }
        }
    }

    private void ResetTimePursuit()
    {
        _timeLastDetected = 0;
        _isChasing = false;
        _cooldownTimer = _sharkBotData.StoppingTimeChase / 2;
    }
}