using Assets.Project.CodeBase.SharkEnemy;
using Assets.Project.CodeBase.SharkEnemy.StateMashine.State;
using UnityEngine;
using UnityEngine.AI;

public class DetectorFood
{
    private SlimeModel _sharkView;
    private readonly AgentMoveState _agentMoveState;

    public DetectorFood( SlimeModel sharkView, AgentMoveState agentMoveState)
    {
        _sharkView = sharkView;
        _agentMoveState = agentMoveState;
    }

    public void FindToFish(SpawnerFood spawner, Transform transform, NavMeshAgent agent)
    {
        if (spawner == null || spawner.Foods.Count == 0)
            return;

        Transform closestFood = null;
        float closestDistance = Mathf.Infinity;

        SelectToFood(spawner, transform, ref closestFood, ref closestDistance);

        if (closestFood != null)
        {
            agent.SetDestination(closestFood.position);
        }
    }

    private void SelectToFood(SpawnerFood spawner, Transform transform, ref Transform closestFish, ref float closestDistance)
    {
        foreach (Food fish in spawner.Foods)
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
