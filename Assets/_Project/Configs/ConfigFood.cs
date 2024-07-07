using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Food", menuName = "ConfigFood")]
public class ConfigFood : ScriptableObject
{
    public SpawnerFoodData SpawnerFishData;
    public SlimeFoodData FishStaticData;
}

[Serializable]
public class SpawnerFoodData
{
    public float SpawnCooldown = 0.1f;
    public int MaxCountFood = 150;
}

[Serializable]
public class SlimeFoodData
{
    [Header("HedgehogPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public HedgehogFish HedgehogPrefab;
    public Vector3 ScalePrefabHedgehog;
    public int MaxCountHedgehogFish = 15;

    [Header("BlueSergeonPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public BlueSergeonFish BlueSergeonPrefab;
    public Vector3 ScalePrefabBlue;
    public int MaxCountBlueSergeonFish = 34;
}
