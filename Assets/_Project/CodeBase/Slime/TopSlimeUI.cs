using Assets.Project.AssetProviders;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopSlimeUI : MonoBehaviour
{
    [SerializeField] private Transform _contentPanel;
    [SerializeField] private List<TextMeshProUGUI> _sharkTexts;

    private TopSharksManager _topSharksManager;

    public void Construct(TopSharksManager topSharksManager)
    {
        _topSharksManager = topSharksManager;
        _topSharksManager.SetUI(this);
    }

    public void UpdateSharkList(List<Slime> sharks)
    {
        foreach (var sharkText in _sharkTexts)
        {
            sharkText.text = string.Empty;
        }

        for (int i = 0; i < sharks.Count && i < _sharkTexts.Count; i++)
        {
            _sharkTexts[i].text = $"{sharks[i].GetSharkName()} - {sharks[i].ScoreLevel}";

            if (sharks[i].GetSharkName() == AssetAdress.NickPlayerRu)
            {
                _sharkTexts[i].color = new Color(130 / 255f, 0, 0, 1); 
            }
            else
            {
                _sharkTexts[i].color = Color.white;
            }
        }
    }
}
