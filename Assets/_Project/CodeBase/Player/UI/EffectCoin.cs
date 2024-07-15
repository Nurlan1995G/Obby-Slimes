using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project.CodeBase.Player.UI
{
    public class EffectCoin : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _fadeSpeed = 5f;
        [SerializeField] private float _value = 0.1f;

        [SerializeField] private List<CanvasGroup> _canvasGroup;

        private Vector3 _initialPosition;
        private bool _isFadingOut = false;
        private float _positionY = 0.8f;

        private void OnEnable()
        {
            _canvasGroup.alpha = 1f;
            _initialPosition.y = _positionY;
            transform.localPosition = _initialPosition;
        }

        private void Start()
        {
            _initialPosition = transform.localPosition;
        }

        void Update()
        {
            transform.localPosition += Vector3.up * _moveSpeed * Time.deltaTime;

            if (_isFadingOut)
            {
                _canvasGroup.alpha -= _fadeSpeed * Time.deltaTime;

                if (_canvasGroup.alpha <= 0f)
                {
                    _canvasGroup.alpha = 0f;
                    gameObject.SetActive(false);
                    _isFadingOut = false;
                    transform.localPosition = _initialPosition;
                }
            }
        }

        public bool SetToFadingOut(bool isFading) =>
            _isFadingOut = isFading;

        public void SetNewInitPosition()
        {
            _positionY += _value;

            _initialPosition = new Vector3(0, _positionY, 0);
        }
    }
}
