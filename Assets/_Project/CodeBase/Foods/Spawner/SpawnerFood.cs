using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFood : MonoBehaviour
{
    [SerializeField] private List<Food> _foods = new List<Food>();

    private FoodFactory _foodFactory;
    private ServesSelectTypeFood _random;
    private PlayerView _playerView;
    private SpawnerFoodData _spawnerFoodData;

    private float _nextSpawnTime;
    private Coroutine _spawnCoroutine;

    public List<Food> Foods => _foods;

    private void Start()
    {
        _nextSpawnTime = Time.time + _spawnerFoodData.SpawnCooldown;
        Debug.Log(_spawnerFoodData.MaxCountFood + " - MaxCountFood");

        _spawnCoroutine = StartCoroutine(SpawnFoodCoroutine());
    }

    private void Update()
    {
        Debug.Log(_foods.Count + " - Foods");

        if (_foods.Count >= _spawnerFoodData.MaxCountFood && _spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            Debug.Log("StopCoroutine");
            _spawnerFoodData.SpawnCooldown = 0.1f;
           _spawnCoroutine = null;
        }
        else if (_foods.Count < _spawnerFoodData.MaxCountFood && _spawnCoroutine == null)
        {
            Debug.Log("StartCoroutine");
            _spawnCoroutine = StartCoroutine(SpawnFoodCoroutine());
        }
    }

    public void Construct(FoodFactory fishFactory, ServesSelectTypeFood random, PlayerView playerView, ConfigFood configFish)
    {
        _foodFactory = fishFactory;
        _random = random;
        _playerView = playerView;
        _spawnerFoodData = configFish.SpawnerFoodData;
    }

    private IEnumerator SpawnFoodCoroutine()
    {
        while (_foods.Count < _spawnerFoodData.MaxCountFood)
        {
            if ( Time.time >= _nextSpawnTime)
            {
                Debug.Log("SapwnFoodCoroutine");

                _nextSpawnTime = Time.time + _spawnerFoodData.SpawnCooldown;
                SpawnFoodAtRandomPoint();
            }

            yield return null;
        }
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

        if (_foods.Count < _spawnerFoodData.MaxCountFood && _spawnCoroutine == null)
        {
            _spawnCoroutine = StartCoroutine(SpawnFoodCoroutine());
        }
    }
}