using System;
using UnityEngine;

namespace Assets.Project.CodeBase.SharkEnemy
{
    public class SharkModel : Shark
    {
        [SerializeField] private TriggerSharkEnemy _triggerSharkEnemy;
        
        private string _nickName;

        public void Destroys() =>
            Destroy(gameObject);

        public void SetNickName(string name)
        {
            _nickName = name;
            NickName.NickNameText.text = _nickName;
        }

        public override string GetSharkName()
        {
            return _nickName ?? "Unknown Shark";
        }
    }
}
