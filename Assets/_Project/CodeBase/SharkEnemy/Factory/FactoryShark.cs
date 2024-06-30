using Assets.Project.AssetProviders;
using System;
using UnityEngine;

namespace Assets.Project.CodeBase.SharkEnemy.Factory
{
    public class FactoryShark
    {
        private readonly AssetProvider _assetProviser;

        public FactoryShark(AssetProvider assetProvider)
        {
            _assetProviser = assetProvider ?? throw new ArgumentNullException(nameof(assetProvider));
        }

        public BotSharkView CreateSharkEnemy(string sharkEnemy, Vector3 position)
        {
            BotSharkView shark = _assetProviser.Instantiate(sharkEnemy, position, 
                Quaternion.Euler(0,GetRandomRotation(),0));

            return shark;
        }

        private float GetRandomRotation()
        {
            float rotation = 0;

            rotation = UnityEngine.Random.Range(0, 360);

            return rotation;
        }
    }
}
