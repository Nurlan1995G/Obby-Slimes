using System.Collections.Generic;
using UnityEngine;

public class SpawnScoreLevelBar : MonoBehaviour
{
    private Fish _fish;

    [SerializeField] private List<ScoreLevelBarFish> _scores = new List<ScoreLevelBarFish>();

    public void Construct(Fish fish)
    {
        _fish = fish;
    }


}
