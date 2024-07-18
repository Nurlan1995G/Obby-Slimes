using Assets._Project.CodeBase.Slime.Interface;
using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

public class TriggerSlimeEnemy : MonoBehaviour
{
    [SerializeField] private SlimeModel _sharkModel;
 
    private void OnTriggerEnter(Collider other) 
    {
        if (other.TryGetComponent(out Food fish))
        {
            if (_sharkModel.ScoreLevel >= fish.ScoreLevel)
            {
                _sharkModel.AddScore(fish.ScoreLevel);
                fish.Destroy();
            }
        }

         if(other.TryGetComponent(out IDestroyableSlime playerView))
         {
            if(_sharkModel.ScoreLevel > playerView.ScoreLevel && playerView.ScoreLevel > 1)
            {
                _sharkModel.AddScore(playerView.ScoreLevel);
                playerView.Destroy();
            }
         }

        if (other.TryGetComponent(out IDestroyableSlime targetSharkModel))
        {
            if (_sharkModel.ScoreLevel > targetSharkModel.ScoreLevel && _sharkModel != targetSharkModel
                && targetSharkModel.ScoreLevel > 1)
            {
                _sharkModel.AddScore(targetSharkModel.ScoreLevel);
                targetSharkModel.Destroy();
            }
        }
    }
}
