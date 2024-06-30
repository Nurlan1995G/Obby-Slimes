using UnityEngine;

public class FollowScoreBarToPlayer : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = _playerView.transform.position + _offset * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, _offset.y, transform.position.z);
    }
}