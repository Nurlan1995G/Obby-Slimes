﻿namespace Assets.Project.CodeBase.SharkEnemy
{
    public class SlimeModel : Slime
    {
        private string _nickName;

        public void SetNickName(string name)
        {
            _nickName = name;
            NickName.NickNameText.text = _nickName;
        }

        public override string GetSharkName()
        {
            return _nickName ?? "Unknown Shark";
        }

        public void Destroy() => 
            Destroy(gameObject);
    }
}
