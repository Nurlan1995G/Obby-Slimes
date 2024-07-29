using Assets._Project.CodeBase.Foods.Interface;
using Assets._Project.CodeBase.Slime.Interface;
using Assets.Project.CodeBase.Player.UI;
using UnityEngine;

public class PlayerTrigger : Interactable
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private EffectCoin _canvasCoinEffect;

    protected override void Interact(Collider other)
    {
        if(other.TryGetComponent(out IDestroyable fish))
        {
            if (_playerView.ScoreLevel >= fish.ScoreLevel)
            {
                _playerView.AddScore(fish.ScoreLevel);
                fish.Destroy();
                ShowCoinEffect();
            }
        }

        if (other.TryGetComponent(out IDestroyableSlime slimeModel))
        {
            if (_playerView.ScoreLevel > slimeModel.ScoreLevel && slimeModel.ScoreLevel > 1)
            {
                _playerView.AddScore(slimeModel.ScoreLevel);
                slimeModel.Destroy();
                ShowCoinEffect();
            }
        }
    }

    private void ShowCoinEffect() =>
        _canvasCoinEffect.ActivateCoin();
}