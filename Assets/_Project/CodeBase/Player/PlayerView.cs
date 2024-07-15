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

    public void Construct(PositionStaticData positionStaticData,GameConfig gameConfig, UIPopup uiPopup
        , BoostButtonUI boostButtonUI, SoundHandler soundHandler, RespawnSlime respawnSlime, PlayerInput playerInput)
    {
        _respawn = respawnSlime;
        _positionStaticData = positionStaticData ?? throw new ArgumentNullException(nameof(positionStaticData));
        _uiPopup = uiPopup ?? throw new ArgumentNullException(nameof(uiPopup));
        _soundhandler = soundHandler ?? throw new ArgumentNullException(nameof(soundHandler));
    }

    public void Destroy(SlimeModel killerShark = null)
    {
        PlayerDied?.Invoke(this);
        _soundhandler.PlayLose();
        SetInitialSizeBox();
        gameObject.SetActive(false);
        ScoreLevelBar.SetInitialPositionY();

        if (killerShark != null)
            _respawn.SetKillerShark(killerShark, this, _uiPopup);

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

        Wallet.Add(15);
    }

    public override void SetPlayerViewHeightCoins()
    {
        base.SetPlayerViewHeightCoins();

        _effectCoin.SetNewInitPosition();
    }

    public override string GetSharkName()
    {
        NickName.NickNameText.text = AssetAdress.NickPlayer;
        return AssetAdress.NickPlayer;
    }
}
