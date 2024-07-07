using System.Collections.Generic;
using UnityEngine;

public class SpawnScoreLevelBar : MonoBehaviour
{
    private Food _fish;

    [SerializeField] private List<ScoreLevelBarFood> _scores = new List<ScoreLevelBarFood>();

    public void Construct(Food fish)
    {
        _fish = fish;
    }


}
