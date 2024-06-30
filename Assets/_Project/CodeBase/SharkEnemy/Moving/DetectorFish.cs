using Assets.Project.CodeBase.SharkEnemy;
using Assets.Project.CodeBase.SharkEnemy.StateMashine.State;
using UnityEngine;
using UnityEngine.AI;

public class DetectorFish
{
    private SharkModel _sharkView;
    private readonly AgentMoveState _agentMoveState;

    public DetectorFish( SharkModel sharkView, AgentMoveState agentMoveState)
    {
        _sharkView = sharkView;
        _agentMoveState = agentMoveState;
    }

    public void FindToFish(SpawnerFish spawner, Transform transform, NavMeshAgent agent)
    {
        if (spawner == null || spawner.Fishes.Count == 0)
            return;

        Transform closestFish = null;
        float closestDistance = Mathf.Infinity;

        SelectToFish(spawner, transform, ref closestFish, ref closestDistance);

        if (closestFish != null)
        {
            agent.SetDestination(closestFish.position);
        }
    }

    private void SelectToFish(SpawnerFish spawner, Transform transform, ref Transform closestFish, ref float closestDistance)
    {
        foreach (Fish fish in spawner.Fishes)
        {
            float distance = Vector3.Distance(transform.position, fish.transform.position);

            if (distance < closestDistance && _sharkView.ScoreLevel >= fish.ScoreLevel)
            {
                closestFish = fish.transform;
                closestDistance = distance;

                _agentMoveState.MoveTo(closestFish.position, transform);
            }
        }
    }
}
