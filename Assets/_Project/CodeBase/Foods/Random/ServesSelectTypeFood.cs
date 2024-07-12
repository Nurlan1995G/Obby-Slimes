using System.Collections.Generic;
using System;

public class ServesSelectTypeFood
{
    private FoodStaticData _countFoodData;

    private Dictionary<TypeFood, int> _foodCounts;
    private Dictionary<TypeFood, int> _maxFoodCounts;

    private List<TypeFood> _availableTypes;

    public ServesSelectTypeFood(ConfigFood configFish)
    {
        _countFoodData = configFish.FoodStaticData;

        _foodCounts = new Dictionary<TypeFood, int>
        {
            { TypeFood.Yellow, 0 },
            { TypeFood.Red, 0 },
            { TypeFood.Blue, 0 },
            { TypeFood.Orange, 0 },
            { TypeFood.Gray, 0 },
            { TypeFood.Pink, 0 },
            { TypeFood.Purple, 0 },
            { TypeFood.Green, 0 }
        };

        _maxFoodCounts = new Dictionary<TypeFood, int>
        {
            { TypeFood.Yellow, _countFoodData.MaxCountYellowFood },
            { TypeFood.Red, _countFoodData.MaxCountRedFood },
            { TypeFood.Blue, _countFoodData.MaxCountBlueFood },
            { TypeFood.Orange, _countFoodData.MaxCountOrangeFood },
            { TypeFood.Gray, _countFoodData.MaxCountGrayFood },
            { TypeFood.Pink, _countFoodData.MaxCountPinkFood },
            { TypeFood.Purple, _countFoodData.MaxCountPurpleFood },
            { TypeFood.Green, _countFoodData.MaxCountGreenFood }
        };

        _availableTypes = new List<TypeFood>(_foodCounts.Keys);
    }

    public TypeFood SpawnFoods()
    {
        if (_availableTypes.Count == 0)
        {
            throw new InvalidOperationException("No available food types to spawn.");
        }

        TypeFood selectedType = _availableTypes[UnityEngine.Random.Range(0, _availableTypes.Count)];
        _foodCounts[selectedType]++;

        if (_foodCounts[selectedType] >= _maxFoodCounts[selectedType])
        {
            _availableTypes.Remove(selectedType);
        }

        return selectedType;
    }

    public void RemoveFood(Food food)
    {
        TypeFood foodType = food.TypeFood;

        _foodCounts[foodType]--;

        if (_foodCounts[foodType] < _maxFoodCounts[foodType] && !_availableTypes.Contains(foodType))
        {
            _availableTypes.Add(foodType);
        }
    }
}