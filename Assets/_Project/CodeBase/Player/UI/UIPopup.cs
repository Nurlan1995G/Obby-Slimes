using Assets.Project.CodeBase.Player.Respawn;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Project.CodeBase.Player.UI
{
    public class UIPopup : MonoBehaviour
    {
        [SerializeField] private Button respawnButton;
        [SerializeField] private Button revengeButton;
        [SerializeField] private ADTimer _adTimer;

        private RespawnShark _respawnPlayer;

        public void Initialize(RespawnShark respawnPlayer) =>
            _respawnPlayer = respawnPlayer;

        private void OnEnable()
        {
            respawnButton.onClick.AddListener(OnRespawn);
            revengeButton.onClick.AddListener(SetRewardOnRevenge);
        }

        private void OnDisable()
        {
            respawnButton.onClick.RemoveListener(OnRespawn);
            revengeButton.onClick.RemoveListener(SetRewardOnRevenge);
        }

        private void OnRespawn()
        {
            _respawnPlayer.Respawn();
            gameObject.SetActive(false);
        }

        private void SetRewardOnRevenge() =>
            YandexSDK.Instance.ShowVideoAd(OnRevenge);

        private void OnRevenge()
        {
            _respawnPlayer.Revenge();
            gameObject.SetActive(false);
        }
    }
}
