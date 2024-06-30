using Assets.Project.AssetProviders;
using System;
using UnityEngine;

public class FishFactory
{
    private readonly FishStaticData _fishStaticData;
    private readonly AssetProvider _assetProvider;

    public FishFactory(ConfigFish configFish, AssetProvider assetProvider)
    {
        _fishStaticData = configFish.FishStaticData
            ?? throw new ArgumentNullException(nameof(configFish));
        _assetProvider = assetProvider ?? throw new ArgumentNullException(nameof(assetProvider));
    }

    public Fish GetFish(TypeFish fishType, Vector3 whereToSpawn)
    {
        Fish fish;

        switch (fishType)
        {
            case TypeFish.Hedgehog:
                fish = _assetProvider.Instantiate(_fishStaticData.HedgehogPrefab, whereToSpawn, Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabHedgehog;
                return fish;

            case TypeFish.BlueSergeon:
                fish = _assetProvider.Instantiate(_fishStaticData.BlueSergeonPrefab, whereToSpawn
                        , Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabBlue;
                return fish;

            case TypeFish.Cloun:
                fish = _assetProvider.Instantiate(_fishStaticData.ClounPrefab, whereToSpawn, Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabCloun;
                return fish;

            case TypeFish.Angel:
                fish = _assetProvider.Instantiate(_fishStaticData.AngelFishPrefab, whereToSpawn, Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabAngel;
                return fish;

            case TypeFish.Beluga:
                fish = _assetProvider.Instantiate(_fishStaticData.BelugaFishPrefab, whereToSpawn, Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabBeluga;
                return fish;

            case TypeFish.Picasso:
                fish = _assetProvider.Instantiate(_fishStaticData.PicassoFishPrefab, whereToSpawn, Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabPicasso;
                return fish;

            case TypeFish.Parrot:
                fish = _assetProvider.Instantiate(_fishStaticData.ParrotFishPrefab, whereToSpawn, Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabParrot;
                return fish;

            case TypeFish.Napoleon:
                fish = _assetProvider.Instantiate(_fishStaticData.NapoleonFishPrefab, whereToSpawn, Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabNapoleon;
                return fish;

            case TypeFish.Luna:
                fish = _assetProvider.Instantiate(_fishStaticData.LunaFishPrefab, whereToSpawn, Quaternion.identity);
                fish.FishScale.transform.localScale = _fishStaticData.ScalePreefabLuna;
                return fish;

            default:
                    throw new InvalidOperationException(nameof(fishType));
        }
    }
}
