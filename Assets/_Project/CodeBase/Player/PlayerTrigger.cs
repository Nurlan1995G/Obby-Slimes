using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fish fish))
        {
            if (_playerView.ScoreLevel >= fish.ScoreLevel)
            {
                _playerView.AddScore(fish.ScoreLevel);
                fish.Destroys();
            }
        }

        if(other.TryGetComponent(out SharkModel sharkModel))
        {
            if(_playerView.ScoreLevel > sharkModel.ScoreLevel && sharkModel.ScoreLevel > 1)
            {
                _playerView.AddScore(sharkModel.ScoreLevel);
                Debug.Log("Соприкосновение с ботом");
                sharkModel.Destroys();
            }
        }
    }
}