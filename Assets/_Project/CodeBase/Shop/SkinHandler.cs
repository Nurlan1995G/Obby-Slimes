using Assets._Project.CodeBase.Player.Skin;
using System.Collections.Generic;
using UnityEngine;

public class SkinHandler : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private List<PlayerSkin> _playerSkins;

    private void OnEnable()
    {
        _shop.SkinCangedInShop += LoadSkins;
    }

    private void Start() =>
        LoadSkins();

    private void OnDisable()
    {
        _shop.SkinCangedInShop -= LoadSkins;
    }

    private void LoadSkins()
    {
        int selectedSkin = YandexSDK.Instance.Data.SelectedSkin;
        int selectedObject = YandexSDK.Instance.Data.SelectedObject;

        Load(selectedSkin,selectedObject, _playerSkins);
        //Load(selectedObject, _hatSkins);
    }

    private void Load(int idSkinPlayer, int idHat, List<PlayerSkin> skins)
    {
        foreach (var skin in skins)
        {
            if (idSkinPlayer == skin.ItemInfo.Id)
            {
                skin.ChangeState(true);

                foreach (var skinHat in skin.SkinHats)
                {
                    if (idHat == skinHat.ItemInfo.Id)
                        skinHat.ChangeState(true);
                    else
                        skinHat.ChangeState(false);
                }
            }
            else
                skin.ChangeState(false);
        }
    }
}