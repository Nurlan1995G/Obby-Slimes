using UnityEngine;

public class ServesSelectTypeFish
{
    private FishStaticData _countFishData;

    private int _lunaFish = 0;
    private int _napoleonFish = 0;
    private int _parrotFish = 0;
    private int _picassoFish = 0;
    private int _belugaFish = 0;
    private int _angelFish = 0;
    private int _hedgehogFish = 0;
    private int _blueSergeon = 0;
    private int _clounFish = 0;

    public ServesSelectTypeFish(ConfigFish configFish) =>
        _countFishData = configFish.FishStaticData;

    public TypeFish SpawnFishes()
    {
        TypeFish typeFish;

        while (true)
        {
            if (_blueSergeon < _countFishData.MaxCountBlueSergeonFish)
            {
                _blueSergeon++;
                return typeFish = TypeFish.BlueSergeon;
            }

            if (_clounFish < _countFishData.MaxCountClounFish)
            {
                _clounFish++;
                return typeFish = TypeFish.Cloun;
            }

            if (_parrotFish < _countFishData.MaxCountParrotFish)
            {
                _parrotFish++;
                return typeFish = TypeFish.Parrot;
            }

            if (_belugaFish < _countFishData.MaxCountBelugaFish)
            {
                _belugaFish++;
                return typeFish = TypeFish.Beluga;
            }

            if (_hedgehogFish < _countFishData.MaxCountHedgehogFish)
            {
                _hedgehogFish++;
                return typeFish = TypeFish.Hedgehog;
            }

            if (_angelFish < _countFishData.MaxCountAngelFish)
            {
                _angelFish++;
                return typeFish = TypeFish.Angel;
            }

            if (_napoleonFish < _countFishData.MaxCountNapoleonFish)
            {
                _napoleonFish++;
                return typeFish = TypeFish.Napoleon;
            }

            if (_picassoFish < _countFishData.MaxCountPicassoFish)
            {
                _picassoFish++;
                return typeFish = TypeFish.Picasso;
            }

            if (_lunaFish < _countFishData.MaxCountLunaFish)
            {
                _lunaFish++;
                return typeFish = TypeFish.Luna;
            }
        }
    }

    public void RemoveFish(Fish fish)
    {
        TypeFish fishType;

         if (fish is BlueSergeonFish)
            fishType = TypeFish.BlueSergeon;
        else if (fish is ClounFish)
            fishType = TypeFish.Cloun;
        else if (fish is ParrotFish)
            fishType = TypeFish.Parrot;
        else if (fish is BelugaFish)
            fishType = TypeFish.Beluga;
        else if (fish is HedgehogFish)
            fishType = TypeFish.Hedgehog;
        else if (fish is AngelFish)
            fishType = TypeFish.Angel;
        else if (fish is NapoleonFish)
            fishType = TypeFish.Napoleon;
        else if (fish is PicassoFish)
            fishType = TypeFish.Picasso;
        else if (fish is LunaFish)
            fishType = TypeFish.Luna;
        else
        {
            Debug.LogWarning("Неизвестный вид рыбы!");
            return;
        }

        switch (fishType)
        {
            case TypeFish.Luna:
                _lunaFish--;
                break;
            case TypeFish.Picasso:
                _picassoFish--;
                break;
            case TypeFish.Napoleon:
                _napoleonFish--;
                break;
            case TypeFish.Angel:
                _angelFish--;
                break;
            case TypeFish.Hedgehog:
                _hedgehogFish--;
                break;
            case TypeFish.Beluga:
                _belugaFish--;
                break;
            case TypeFish.Parrot:
                _parrotFish--;
                break;
            case TypeFish.Cloun:
                _clounFish--;
                break;
            case TypeFish.BlueSergeon:
                _blueSergeon--;
                break;
        }
    }
}
