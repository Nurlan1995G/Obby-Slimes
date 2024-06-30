using System.Collections.Generic;
using UnityEngine;

public class SpawnerFish : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
    [SerializeField] private List<Fish> _fishes = new List<Fish>();
    //[SerializeField] private List<ScoreLevelBarFish> _scoreLevelBars = new List<ScoreLevelBarFish>();

    //[SerializeField] private ScoreLevelBarFish _container;

    private FishFactory _fishFactory;
    private ServesSelectTypeFish _random;
    private PlayerView _playerView;
    private SpawnerFishData _spawnerFishData;

    private float _nextSpawnTime;

    public List<Fish> Fishes => _fishes;

    private void Start()
    {
        _nextSpawnTime = Time.time + _spawnerFishData.SpawnCooldown;
    }

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
        List<SpawnPoint> availablePoints = _spawnPoints.FindAll(point => !point.IsBusy);

        if (availablePoints.Count == 0)
            return;

        SpawnPoint spawnPoint = availablePoints[UnityEngine.Random.Range(0, availablePoints.Count)];
        spawnPoint.IsBusy = true;

        Vector3 spawnPosition = spawnPoint.transform.position;

        Fish fish = _fishFactory.GetFish(_random.SpawnFishes(), spawnPosition);
        fish.transform.SetParent(this.transform);

        AddFish(fish);

        //ScoreLevelBarFish scoreBarObject = Instantiate(_container, transform);
        //scoreBarObject.Construct(fish);
        fish.Construct(_playerView);
       //_scoreLevelBars.Add(scoreBarObject);
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

        SpawnPoint spawnPoint = _spawnPoints.Find(point => point.transform.position == fish.transform.position);
        
        if (spawnPoint != null)
        {
            spawnPoint.IsBusy = false;
        }

       /* ScoreLevelBarFish scoreBar = _scoreLevelBars.Find(bar => bar.GetFish() == fish);
        
        if (scoreBar != null)
        {
            _scoreLevelBars.Remove(scoreBar);
            Destroy(scoreBar.gameObject);
        }*/
    }
}
