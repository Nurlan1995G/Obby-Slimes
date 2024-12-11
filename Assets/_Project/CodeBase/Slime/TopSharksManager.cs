using System.Collections.Generic;
using System.Linq;

public class TopSharksManager
{
    private List<Slime> _sharks = new List<Slime>();
    private TopSlimeUI _topSharksUI;

    public void RegisterShark(Slime shark)
    {
        if (!_sharks.Contains(shark))
        {
            _sharks.Add(shark);
            shark.OnScoreChanged += UpdateTopSharks;
        }
    }

    public void UnregisterShark(Slime shark)
    {
        if (_sharks.Contains(shark))
        {
            _sharks.Remove(shark);
            shark.OnScoreChanged -= UpdateTopSharks;
        }
    }

    public void SetUI(TopSlimeUI topSharksUI)
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
