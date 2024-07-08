using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Food", menuName = "ConfigFood")]
public class ConfigFood : ScriptableObject
{
    public SpawnerFoodData SpawnerFishData;
    public FoodStaticData FoodStaticData;
}

[Serializable]
public class SpawnerFoodData
{
    public float SpawnCooldown = 0.1f;
    public int MaxCountFood = 150;
}

[Serializable]
public class FoodStaticData
{
    [Header("PurpleFoodPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public PurpleFood PurpleFoodPrefab;
    public Vector3 ScalePrefabPurple;
    public int MaxCountPurpleFood = 15;
    public int ScoreLevelPurple = 1;

    [Header("GreenFoodPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public GreenFood GreenFoodPrefab;
    public Vector3 ScalePrefabGreen;
    public int MaxCountGreenFood = 34;
    public int ScoreLevelGreen = 2;

    [Header("BlueFoodPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public BlueFood BlueFoodPrefab;
    public Vector3 ScalePrefabBlue;
    public int MaxCountBlueFood = 34;
    public int ScoreLevelBlue = 3;

    [Header("RedFoodPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public RedFood RedFoodPrefab;
    public Vector3 ScalePrefabRed;
    public int MaxCountRedFood = 34;
    public int ScoreLevelRed = 4;

    [Header("YellowFoodPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public YellowFood YellowFoodPrefab;
    public Vector3 ScalePrefabYellow;
    public int MaxCountYellowFood = 34;
    public int ScoreLevelYellow = 5;

    [Header("PinkFoodPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public PinkFood PinkFoodPrefab;
    public Vector3 ScalePrefabPink;
    public int MaxCountPinkFood = 34;
    public int ScoreLevelPink = 6;

    [Header("GrayFoodPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public GrayFood GrayFoodPrefab;
    public Vector3 ScalePrefabGray;
    public int MaxCountGrayFood = 34;
    public int ScoreLevelGray = 7;

    [Header("OrangeFoodPrefab и максимальное кол-во рыбок")]
    [field: SerializeField] public OrangeFood OrangeFoodPrefab;
    public Vector3 ScalePrefabOrange;
    public int MaxCountOrangeFood = 34;
    public int ScoreLevelOrange = 8;
}
