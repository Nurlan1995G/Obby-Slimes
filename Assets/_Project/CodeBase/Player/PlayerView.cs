using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Player.Respawn;
using Assets.Project.CodeBase.Player.UI;
using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public class PlayerView : Shark
{
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private PlayerMover _mover;

    private UIPopup _uiPopup;
    private RespawnShark _respawn;
    private PositionStaticData _positionStaticData;
    private SoundHandler _soundhandler;

    public Action<PlayerView> PlayerDied;

    public void Construct(PositionStaticData positionStaticData,GameConfig gameConfig, UIPopup uiPopup
        , BoostButtonUI boostButtonUI, SoundHandler soundHandler)
    {
        _respawn = new RespawnShark();

        _positionStaticData = positionStaticData ?? throw new ArgumentNullException(nameof(positionStaticData));
        _uiPopup = uiPopup;
        _soundhandler = soundHandler;
        _mover.Construct(gameConfig.PlayerData, boostButtonUI);
    }

    public void Destroys(SharkModel killerShark = null)
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

    public override string GetSharkName()
    {
        NickName.NickNameText.text = AssetAdress.NickPlayer;
        return AssetAdress.NickPlayer;
    }
}
