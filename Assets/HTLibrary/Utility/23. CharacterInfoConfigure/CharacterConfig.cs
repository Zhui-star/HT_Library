using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HTLibrary.Utility
{
    [Serializable]
    public class CharacterConfig : ScriptableObject
    {
        public float characterHP; //生命值
        public float characterLevel; //等级
        public float characterAttack; //攻击力
        public float characterExperience; //经验值
        public float characterDefence; //防御值
        public float characterCritRank; //暴击率
        public float characterCritMultiple; //暴击倍数
        public float characterDodge; //闪避
        public float characterMoveSpeed; //移动速度
        public float characterAttachSpeed; //攻击速度
        public float characterAddtiveAttackSpeed;

        public delegate void UpdatePropertyDele(float hp, float attack, float defence, float crit, float dodge);

        public event UpdatePropertyDele UpdatePropertyEvent;

        public void ChangeProperty(float hp, float characterAttack, float characterDefence, float characterCritRank,
            float characterDodge, float characterMoveSpeed,float characterAddtiveAttackSpeed)
        {
            this.characterHP += hp;
            this.characterAttack+= characterAttack;
            this.characterDefence += characterDefence;
            this.characterCritRank += characterCritRank;
            this.characterDodge += characterDodge;
            this.characterMoveSpeed += characterMoveSpeed;
            this.characterAddtiveAttackSpeed += characterAddtiveAttackSpeed;

            UpdatePropertyEvent?.Invoke(this.characterHP,this.characterAttack,this.characterDefence,this.characterCritRank,this.characterDodge);
        }

    }

}
