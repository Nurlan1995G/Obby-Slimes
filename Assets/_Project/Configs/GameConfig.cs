using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameConfig", menuName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    public PlayerData PlayerData;
    public SlimeBotData SharkBotData;
    public CameraRotateData CameraRotateData;
}

[Serializable]
public class PlayerData
{
    public float MoveSpeed;
    public float RotateSpeed;
    public float Gravity;
    public float BoostMultiplier;
    public float BoostDuration;
    public float BoostRecoveryTime;
}

[Serializable]
public class SlimeBotData
{
    public float MoveSpeed;
    public float RotateSpeed;
    public float MinimalDistanceToObject;
    public float StoppingTimeChase;
}

[Serializable]
public class CameraRotateData
{
    public float RotateSpeed;
    public float MinZoomDistance;
    public float MaxZoomDistance;
    public float ZoomStep;
}
