using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Project.CodeBase.Player.UI
{
    public class BoostButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private PlayerMover _playerMover;

        public void Initialize(PlayerMover playerMover) =>
            _playerMover = playerMover;

        public void OnPointerDown(PointerEventData eventData) => 
            _playerMover.OnBoostStarted();

        public void OnPointerUp(PointerEventData eventData) => 
            _playerMover.OnBoostCanceled();
    }
}
