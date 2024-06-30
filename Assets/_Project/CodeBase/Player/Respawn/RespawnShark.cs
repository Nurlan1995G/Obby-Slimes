using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy;

namespace Assets.Project.CodeBase.Player.Respawn
{
    public class RespawnShark
    {
        private UIPopup _uiPopup;
        private PositionStaticData _positionPlayer;
        private SharkModel _killerShark;
        private PlayerView _playerView;

        public void SetKillerShark(SharkModel sharkModel, PlayerView sharkPlayer, UIPopup uIPopup)
        {
            _killerShark = sharkModel;
            _playerView = sharkPlayer;
            _uiPopup = uIPopup;
        }

        public void SelectAction()
        {
            _uiPopup.Initialize(this);
            _uiPopup.gameObject.SetActive(true);
        }

        public void Respawn() =>
            _playerView.Teleport();

        public void Revenge()
        {
            if (_killerShark != null)
                _killerShark.Destroys();

            Respawn();
        }
    }
}
