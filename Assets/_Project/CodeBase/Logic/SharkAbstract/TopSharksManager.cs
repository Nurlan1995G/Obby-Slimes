using System.Collections.Generic;
using System.Linq;

public class TopSharksManager
{
    private List<Shark> _sharks = new List<Shark>();
    private TopSharksUI _topSharksUI;

    public void RegisterShark(Shark shark)
    {
        if (!_sharks.Contains(shark))
        {
            _sharks.Add(shark);
            shark.OnScoreChanged += UpdateTopSharks;
        }
    }

    public void UnregisterShark(Shark shark)
    {
        if (_sharks.Contains(shark))
        {
            _sharks.Remove(shark);
            shark.OnScoreChanged -= UpdateTopSharks;
        }
    }

    public void SetUI(TopSharksUI topSharksUI)
    {
        _topSharksUI = topSharksUI;
        UpdateTopSharks();
    }

    private void UpdateTopSharks()
    {
        var sortedSharks = _sharks.OrderByDescending(s => s.ScoreLevel).ToList();

        foreach (var shark in _sharks)
        {
            shark.SetCrown(shark == sortedSharks.FirstOrDefault());
        }

        _topSharksUI?.UpdateSharkList(sortedSharks);
    }
}
