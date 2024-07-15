using Assets._Project.CodeBase.Foods.Interface;
using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

public class PlayerTrigger : Interactable
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private EffectCoin _canvasCoinEffect;

    protected override void Interact(Collider other)
    {
        if(other.TryGetComponent(out IDestroyFood fish))
        {
            if (_playerView.ScoreLevel >= fish.ScoreLevel)
            {
                _playerView.AddScore(fish.ScoreLevel);
                fish.Destroy();
                ShowCoinEffect();
            }
        }

        if (other.TryGetComponent(out SlimeModel sharkModel))
        {
            if (_playerView.ScoreLevel > sharkModel.ScoreLevel && sharkModel.ScoreLevel > 1)
            {
                _playerView.AddScore(sharkModel.ScoreLevel);
                sharkModel.Destroy();
                ShowCoinEffect();
            }
        }
    }

    private void ShowCoinEffect()
    {
        _canvasCoinEffect.ActivateCoin();
    }
}