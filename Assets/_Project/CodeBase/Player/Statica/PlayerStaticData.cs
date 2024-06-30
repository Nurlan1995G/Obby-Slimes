using UnityEngine;

namespace Assets.Project.CodeBase.Player.Statica
{
    [CreateAssetMenu(fileName = "Shark")]
    public class PlayerStaticData : ScriptableObject
    {
        [field: SerializeField, Range(1,10)] public float SpeedMove;
        [field: SerializeField, Range(1,100)] public float RotateSpeed;


    }
}
