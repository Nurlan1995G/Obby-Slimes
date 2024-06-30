using UnityEngine;

[CreateAssetMenu(fileName = "PositionLevel")]
public class PositionStaticData : ScriptableObject
{
    [Header("Sharks position")]
    [field: SerializeField] public Vector3 InitSharkOnePosition;
    [field: SerializeField] public Vector3 InitSharkTwoPosition;
    [field: SerializeField] public Vector3 InitSharkThreePosition;
    [field: SerializeField] public Vector3 InitSharkFourPosition;
    [field: SerializeField] public Vector3 InitSharkFivePosition;
    [field: SerializeField] public Vector3 InitSharkSixPosition;
    [field: SerializeField] public Vector3 InitSharkSevenPosition;
    [Header("Player position")]
    [field: SerializeField] public Vector3 InitPlayerPosition;
}
