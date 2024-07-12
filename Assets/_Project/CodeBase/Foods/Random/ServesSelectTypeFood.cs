using UnityEngine;

public class ServesSelectTypeFood
{
    private FoodStaticData _countFoodData;

    private int _yellowFood = 0;
    private int _redFood = 0;
    private int _blueFood = 0;
    private int _orangeFood = 0;
    private int _grayFood = 0;
    private int _pinkFood = 0;
    private int _purpleFood = 0;
    private int _greenFood = 0;

    public ServesSelectTypeFood(ConfigFood configFish) =>
        _countFoodData = configFish.FoodStaticData;

    public TypeFood SpawnFoods()
    {
        TypeFood typeFood;

        while (true)
        {
            if (_purpleFood < _countFoodData.MaxCountPurpleFood)
            {
                _purpleFood++;
                return typeFood = TypeFood.Purple;
            }

            if (_greenFood < _countFoodData.MaxCountGreenFood)
            {
                _greenFood++;
                return typeFood = TypeFood.Green;
            }

            if (_yellowFood < _countFoodData.MaxCountYellowFood)
            {
                _yellowFood++;
                return typeFood = TypeFood.Yellow;
            }

            if (_blueFood < _countFoodData.MaxCountBlueFood)
            {
                _blueFood++;
                return typeFood = TypeFood.Blue;
            }

            if (_grayFood < _countFoodData.MaxCountGrayFood)
            {
                _grayFood++;
                return typeFood = TypeFood.Gray;
            }

            if (_pinkFood < _countFoodData.MaxCountPinkFood)
            {
                _pinkFood++;
                return typeFood = TypeFood.Pink;
            }

            if (_redFood < _countFoodData.MaxCountRedFood)
            {
                _redFood++;
                return typeFood = TypeFood.Red;
            }

            if (_orangeFood < _countFoodData.MaxCountOrangeFood)
            {
                _orangeFood++;
                return typeFood = TypeFood.Orange;
            }
        }
    }

    public void RemoveFood(Food food)
    {
        TypeFood foodType = food.TypeFood;

        switch (foodType)
        {
            case TypeFood.Yellow:
                _yellowFood--;
                break;
            case TypeFood.Red:
                _redFood--;
                break;
            case TypeFood.Blue:
                _blueFood--;
                break;
            case TypeFood.Orange:
                _orangeFood--;
                break;
            case TypeFood.Gray:
                _grayFood--;
                break;
            case TypeFood.Pink:
                _pinkFood--;
                break;
            case TypeFood.Purple:
                _purpleFood--;
                break;
            case TypeFood.Green:
                _greenFood--;
                break;
        }
    }
}
