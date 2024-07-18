using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.CameraLogic
{
    public class ScoreLevelBarFoodManager
    {
        private List<Food> _foods;
        private float _hideDistance;
        private Transform _cameraTransform;
        private SpawnerFood _spawnerFood;

        public ScoreLevelBarFoodManager(float hideDistance, Transform cameraTransform, 
            SpawnerFood spawnerFood)
        {
            _foods = new List<Food>();

            _hideDistance = hideDistance;
            _cameraTransform = cameraTransform;
            _spawnerFood = spawnerFood;

            OnEnable();
        }

        public void OnEnable() => 
            _spawnerFood.FoodSpawned += OnFoodSpawned;

        public void OnDisable() =>
            _spawnerFood.FoodSpawned -= OnFoodSpawned;
        
        public void CheckScoreLevelBarFoodDistances()
        {
            _foods.RemoveAll(food => food.ScoreLevelBarFood == null);

            foreach (var food in _foods)
            {
                float distance = Vector3.Distance(_cameraTransform.position, food.ScoreLevelBarFood.transform.position);
                food.ScoreLevelBarFood.gameObject.SetActive(distance <= _hideDistance);
            }
        }

        private void OnFoodSpawned(Food food) => 
            _foods.Add(food);
    }
}
