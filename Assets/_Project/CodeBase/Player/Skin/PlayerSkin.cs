using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.CodeBase.Player.Skin
{
    public class PlayerSkin : MonoBehaviour
    {
        [field: SerializeField] public ItemInfo ItemInfo;
        [field: SerializeField] public List<RewardModel> SkinHats;

        public void ChangeState(bool state) => gameObject.SetActive(state);
    }
}
