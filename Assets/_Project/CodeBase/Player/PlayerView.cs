using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Player.Respawn;
using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public class PlayerView : Slime
{
    [SerializeField] private EffectCoin _effectCoin;

    private UIPopup _uiPopup;
    private RespawnSlime _respawn;
    private PositionStaticData _positionStaticData;
    private SoundHandler _soundhandler;

    public Action<PlayerView> PlayerDied;
    private Language _language;

    public void Construct(PositionStaticData positionStaticData,GameConfig gameConfig, UIPopup uiPopup
        , BoostButtonUI boostButtonUI, SoundHandler soundHandler, RespawnSlime respawnSlime, PlayerInput playerInput, Language language)
    {
        _respawn = respawnSlime;
        _positionStaticData = positionStaticData ?? throw new ArgumentNullException(nameof(positionStaticData));
        _uiPopup = uiPopup ?? throw new ArgumentNullException(nameof(uiPopup));
        _soundhandler = soundHandler ?? throw new ArgumentNullException(nameof(soundHandler));
        _language = language;
    }

    public override void Destroyable()
    {
        PlayerDied?.Invoke(this);
        _soundhandler.PlayLose();
        SetInitialSizeBox();
        gameObject.SetActive(false);
        ScoreLevelBar.SetInitialPositionY();

        _respawn.SelectAction();
    }

    public void Teleport()
    {
        transform.position = _positionStaticData.InitPlayerPosition;
        SharkSkin.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        Score = 1;
        ScoreLevelBar.SetScore(Score);
        ScoreCount = 0;
        ParametrRaising = 10;
        gameObject.SetActive(true);
        _soundhandler.PlayWin();
    }

    public override void SetPlayerViewWallet()
    {
        base.SetPlayerViewWallet();

        Wallet.Add(5);
    }

    public override void SetPlayerViewHeightCoins()
    {
        base.SetPlayerViewHeightCoins();

        _effectCoin.SetNewInitPosition();
    }

    public override string GetSharkName()
    {
        if (_language == Language.Russian)
        {
            NickName.NickNameText.text = AssetAdress.NickPlayerRu;
            return AssetAdress.NickPlayerRu;
        }
        else if (_language == Language.English)
        {
            NickName.NickNameText.text = AssetAdress.NickPlayerEn;
            return AssetAdress.NickPlayerEn;
        }

        return null;
    }
}
