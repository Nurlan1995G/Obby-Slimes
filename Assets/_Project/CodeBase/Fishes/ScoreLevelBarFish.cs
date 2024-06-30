using TMPro;
using UnityEngine;

public class ScoreLevelBarFish : MonoBehaviour
{
    [field: SerializeField] public TextMeshProUGUI ScoreText;

    private Fish _fish;
    //private Vector3 _offset = new Vector3(0f,2f,0f);

    public void Construct(Fish fish)
    {
        //_fish = fish;
        //_fish.FishDied += OnFishDied;
        //UpdateScore();
        //PositionObject();
    }

    /*public Fish GetFish() =>
        _fish;*/

   /* private void PositionObject() =>
        transform.position = _fish.transform.position + _offset;*/

    /*private void UpdateScore()
    {
        if (ScoreText != null && _fish != null)
        {
            ScoreText.text = _fish.ScoreLevel.ToString();
        }
    }*/

    /*private void OnFishDied(Fish fish)
    {
        _fish.FishDied -= OnFishDied;
        Destroy(gameObject);
    }*/
}
