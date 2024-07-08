using System.Collections.Generic;
using UnityEngine;

public class SpawnerFood : MonoBehaviour
{
    [SerializeField] private List<Food> _foods = new List<Food>();

    private FoodFactory _foodFactory;
    private ServesSelectTypeFood _random;
    private PlayerView _playerView;
    private SpawnerFoodData _spawnerFishData;

    private float _nextSpawnTime;

    public List<Food> Foods => _foods;

    private void Start() =>
        _nextSpawnTime = Time.time + _spawnerFishData.SpawnCooldown;

    private void Update()
    {
        if (Time.time >= _nextSpawnTime && _foods.Count < _spawnerFishData.MaxCountFood)
        {
            _nextSpawnTime = Time.time + _spawnerFishData.SpawnCooldown;
            SpawnFoodAtRandomPoint();
        }
    }
    
    public void Construct(FoodFactory fishFactory, ServesSelectTypeFood random, PlayerView playerView, ConfigFood configFish)
    {
        _foodFactory = fishFactory;
        _random = random;
        _playerView = playerView;
        _spawnerFishData = configFish.SpawnerFishData;
    }

    private void SpawnFoodAtRandomPoint()
    {
        float positionX = Random.Range(-33, 260);
        float positionZ = Random.Range(-80, 215);

        Vector3 spawnPosition = new Vector3(positionX, 0, positionZ);

        Food food = _foodFactory.GetFish(_random.SpawnFoods(), spawnPosition);
        food.transform.SetParent(this.transform);

        AddFood(food);

        food.Construct(_playerView);
    }

    private void AddFood(Food food)
    {
        food.FoodDied += OnFoodDied;
        _foods.Add(food);
    }

    private void OnFoodDied(Food food)
    {
        food.FoodDied -= OnFoodDied;
        _foods.Remove(food);
        _random.RemoveFood(food);
    }
}
