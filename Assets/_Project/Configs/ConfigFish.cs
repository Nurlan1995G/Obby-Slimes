using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Fish", menuName = "ConfigFish")]
public class ConfigFish : ScriptableObject
{
    public SpawnerFishData SpawnerFishData;
    public FishStaticData FishStaticData;
}

[Serializable]
public class SpawnerFishData
{
    public float SpawnCooldown = 0.1f;
    public int MaxCountFish = 150;
}

[Serializable]
public class FishStaticData
{
    [Header("HedgehogPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public HedgehogFish HedgehogPrefab;
    public Vector3 ScalePreefabHedgehog;
    public int MaxCountHedgehogFish = 15;

    [Header("BlueSergeonPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public BlueSergeonFish BlueSergeonPrefab;
    public Vector3 ScalePreefabBlue;
    public int MaxCountBlueSergeonFish = 34;

    [Header("ClounPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public ClounFish ClounPrefab;
    public Vector3 ScalePreefabCloun;
    public int MaxCountClounFish = 30;

    [Header("AngelFishPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public AngelFish AngelFishPrefab;
    public Vector3 ScalePreefabAngel;
    public int MaxCountAngelFish = 12;

    [Header("BelugaFishPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public BelugaFish BelugaFishPrefab;
    public Vector3 ScalePreefabBeluga;
    public int MaxCountBelugaFish = 20;

    [Header("PicassoFishPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public PicassoFish PicassoFishPrefab;
    public Vector3 ScalePreefabPicasso;
    public int MaxCountPicassoFish = 5;

    [Header("ParrotFishPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public ParrotFish ParrotFishPrefab;
    public Vector3 ScalePreefabParrot;
    public int MaxCountParrotFish = 24;

    [Header("NapoleonFishPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public NapoleonFish NapoleonFishPrefab;
    public Vector3 ScalePreefabNapoleon;
    public int MaxCountNapoleonFish = 8;

    [Header("LunaFishPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public LunaFish LunaFishPrefab;
    public Vector3 ScalePreefabLuna;
    public int MaxCountLunaFish = 2;
}
