using System.Collections.Generic;
using UnityEngine;

public class SpawnerFish : MonoBehaviour
{
    [SerializeField] private List<Fish> _fishes = new List<Fish>();

    private FishFactory _fishFactory;
    private ServesSelectTypeFish _random;
    private PlayerView _playerView;
    private SpawnerFishData _spawnerFishData;

    private float _nextSpawnTime;

    public List<Fish> Fishes => _fishes;

    private void Start() =>
        _nextSpawnTime = Time.time + _spawnerFishData.SpawnCooldown;

    private void Update()
    {
        if (Time.time >= _nextSpawnTime && _fishes.Count < _spawnerFishData.MaxCountFish)
        {
            _nextSpawnTime = Time.time + _spawnerFishData.SpawnCooldown;
            SpawnFishAtRandomPoint();
        }
    }
    
    public void Construct(FishFactory fishFactory, ServesSelectTypeFish random, PlayerView playerView, ConfigFish configFish)
    {
        _fishFactory = fishFactory;
        _random = random;
        _playerView = playerView;
        _spawnerFishData = configFish.SpawnerFishData;
    }

    private void SpawnFishAtRandomPoint()
    {
        float positionX = Random.Range(-33, 260);
        float positionZ = Random.Range(-80, 215);

        Vector3 spawnPosition = new Vector3(positionX, 0, positionZ);

        Fish fish = _fishFactory.GetFish(_random.SpawnFishes(), spawnPosition);
        fish.transform.SetParent(this.transform);

        AddFish(fish);

        fish.Construct(_playerView);
    }

    private void AddFish(Fish fish)
    {
        fish.FishDied += OnFishDied;
        _fishes.Add(fish);
    }

    private void OnFishDied(Fish fish)
    {
        fish.FishDied -= OnFishDied;
        _fishes.Remove(fish);
        _random.RemoveFish(fish);
    }
}
