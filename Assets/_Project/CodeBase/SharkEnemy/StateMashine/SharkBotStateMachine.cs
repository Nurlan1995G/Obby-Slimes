﻿using Assets.Project.CodeBase.SharkEnemy.StateMashine.Interface;
using Assets.Project.CodeBase.SharkEnemy.StateMashine.State;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Project.CodeBase.SharkEnemy.StateMashine
{
    public class SharkBotStateMachine 
    {
        private List<IState> _states;
        private IState _currentState;

        public SharkBotStateMachine(NavMeshAgent agent, SharkModel sharkModel, SharkBotData sharkBotConfig, PlayerView playerView, SpawnerFish spawnerFish)
        {
            _states = new List<IState>
            {
                new AgentMoveState(agent,sharkModel, sharkBotConfig, spawnerFish),
            };

            _currentState = _states[0];
        }

        public void Update() => _currentState.Update();
    }
}
