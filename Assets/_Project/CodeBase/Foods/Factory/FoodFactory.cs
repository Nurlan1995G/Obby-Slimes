using Assets.Project.AssetProviders;
using System;
using UnityEngine;

public class FoodFactory
{
    private readonly FoodStaticData _foodStaticData;
    private readonly AssetProvider _assetProvider;

    public FoodFactory(ConfigFood configFish, AssetProvider assetProvider)
    {
        _foodStaticData = configFish.FoodStaticData
            ?? throw new ArgumentNullException(nameof(configFish));
        _assetProvider = assetProvider ?? throw new ArgumentNullException(nameof(assetProvider));
    }

    public Food GetFish(TypeFood foodType, Vector3 whereToSpawn)
    {
        Food food;

        switch (foodType)
        {
            case TypeFood.Yellow:
                food = _assetProvider.Instantiate(_foodStaticData.YellowFoodPrefab, whereToSpawn, Quaternion.identity);
                food.FoodScale.transform.localScale = _foodStaticData.ScalePrefabYellow;
                return food;

            case TypeFood.Red:
                food = _assetProvider.Instantiate(_foodStaticData.RedFoodPrefab, whereToSpawn
                        , Quaternion.identity);
                food.FoodScale.transform.localScale = _foodStaticData.ScalePrefabRed;
                return food;

            case TypeFood.Blue:
                food = _assetProvider.Instantiate(_foodStaticData.BlueFoodPrefab, whereToSpawn, Quaternion.identity);
                food.FoodScale.transform.localScale = _foodStaticData.ScalePrefabBlue;
                return food;

            case TypeFood.Orange:
                food = _assetProvider.Instantiate(_foodStaticData.OrangeFoodPrefab, whereToSpawn, Quaternion.identity);
                food.FoodScale.transform.localScale = _foodStaticData.ScalePrefabOrange;
                return food;

            case TypeFood.Gray:
                food = _assetProvider.Instantiate(_foodStaticData.GrayFoodPrefab, whereToSpawn, Quaternion.identity);
                food.FoodScale.transform.localScale = _foodStaticData.ScalePrefabGray;
                return food;

            case TypeFood.Pink:
                food = _assetProvider.Instantiate(_foodStaticData.PinkFoodPrefab, whereToSpawn, Quaternion.identity);
                food.FoodScale.transform.localScale = _foodStaticData.ScalePrefabPink;
                return food;

            case TypeFood.Purple:
                food = _assetProvider.Instantiate(_foodStaticData.PurpleFoodPrefab, whereToSpawn, Quaternion.identity);
                food.FoodScale.transform.localScale = _foodStaticData.ScalePrefabPurple;
                return food;

            case TypeFood.Green:
                food = _assetProvider.Instantiate(_foodStaticData.GreenFoodPrefab, whereToSpawn, Quaternion.identity);
                food.FoodScale.transform.localScale = _foodStaticData.ScalePrefabGreen;
                return food;

            default:
                    throw new InvalidOperationException(nameof(foodType));
        }
    }
}
