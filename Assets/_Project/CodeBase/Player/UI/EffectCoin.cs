using UnityEngine;

namespace Assets.Project.CodeBase.Player.UI
{
    public class EffectCoin : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _fadeSpeed = 5f;
        [SerializeField] private float _value = 0.1f;

        [field: SerializeField] public CanvasGroup CanvasGroup;

        public bool IsFadingOut = false;

        private Vector3 _initialPosition;
        private float _positionY = 0.8f;

        private void Start()
        {
            _initialPosition = transform.localPosition;
        }

        private void OnEnable()
        {
            CanvasGroup.alpha = 1f;
            _initialPosition.y = _positionY;
            transform.localPosition = _initialPosition;
        }

        void Update()
        {
            transform.localPosition += Vector3.up * _moveSpeed * Time.deltaTime;

            if (IsFadingOut)
            {
                CanvasGroup.alpha -= _fadeSpeed * Time.deltaTime;

                if (CanvasGroup.alpha <= 0f)
                {
                    CanvasGroup.alpha = 0f;
                    gameObject.SetActive(false);
                    IsFadingOut = false;
                    transform.localPosition = _initialPosition;
                }
            }
        }

        public void SetNewInitPosition()
        {
            _positionY += _value;

            _initialPosition = new Vector3(0, _positionY, 0);
        }
    }
}
