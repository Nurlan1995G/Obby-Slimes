using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private EffectCoin _canvasCoinEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fish fish))
        {
            if (_playerView.ScoreLevel >= fish.ScoreLevel)
            {
                _playerView.AddScore(fish.ScoreLevel);
                fish.Destroys();
                ShowCoinEffect();   
            }
        }

        if(other.TryGetComponent(out SharkModel sharkModel))
        {
            if(_playerView.ScoreLevel > sharkModel.ScoreLevel && sharkModel.ScoreLevel > 1)
            {
                _playerView.AddScore(sharkModel.ScoreLevel);
                sharkModel.Destroys();
                ShowCoinEffect();
            }
        }
    }

    private void ShowCoinEffect()
    {
        _canvasCoinEffect.gameObject.SetActive(true);
        _canvasCoinEffect.IsFadingOut = true;
    }
}