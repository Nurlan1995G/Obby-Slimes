using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Project.CodeBase.Player.UI
{
    public class EffectCoin : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _fadeSpeed = 5f;
        [SerializeField] private float _value = 0.1f;
        [SerializeField] private List<Coin> _coins;

        private Vector3 _initialPosition;
        private bool _isFadingOut = false;
        private float _positionY = 0.8f;

        private void OnEnable()
        {
            ResetCoin(_coins[0]);
        }

        private void Start()
        {
            _initialPosition = transform.localPosition;
        }

        void Update()
        {
            foreach (var coin in _coins)
            {
                if (coin.gameObject.activeSelf)
                {
                    coin.transform.localPosition += Vector3.up * _moveSpeed * Time.deltaTime;

                    if (_isFadingOut)
                    {
                        coin.CanvasGroup.alpha -= _fadeSpeed * Time.deltaTime;

                        if (coin.CanvasGroup.alpha <= 0f)
                        {
                            ResetCoin(coin);
                        }
                    }
                }
            }
        }

        private void ResetCoin(Coin coin)
        {
            coin.CanvasGroup.alpha = 1f;
            coin.transform.localPosition = _initialPosition;
            coin.gameObject.SetActive(false);
        }

        public void ActivateCoin()
        {
            Coin availableCoin = _coins.FirstOrDefault(c => !c.gameObject.activeSelf);

            if (availableCoin != null)
            {
                availableCoin.transform.localPosition = _initialPosition;
                availableCoin.gameObject.SetActive(true);
                _isFadingOut = true;
            }
        }

        public void SetNewInitPosition()
        {
            _positionY += _value;
            _initialPosition = new Vector3(0, _positionY, 0);
        }
    }
}
