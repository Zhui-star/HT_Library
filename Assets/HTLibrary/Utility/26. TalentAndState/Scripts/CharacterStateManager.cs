using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace HTLibrary.Utility
{
    [Serializable]
    public class StateUtility
    {
        public TalentType talentType;
        public int level;
    }
    /// <summary>
    /// 角色状态管理 增益属性 BUFF DEBUFF
    /// </summary>
    public class CharacterStateManager : MonoBehaviour
    {
        private List<CharacterState> stateLists = new List<CharacterState>();

        [Header("初始化状态列表")]
        public List<StateUtility> stateUtilityList = new List<StateUtility>();

        private void OnEnable()
        {
            if(this.gameObject.tag==Tags.Player)
            {
                TalentSystemManager.Instance.StudyTalentEvent += GetState;
            }
           
        }
        private void OnDisable()
        {
            if (this.gameObject.tag == Tags.Player)
            {
                TalentSystemManager.Instance.StudyTalentEvent -= GetState;
            }

            foreach (var temp in stateLists)
            {
                temp.OnExit();
            }
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        private void Start()
        {
            foreach(var temp in stateUtilityList)
            {
                GetState(temp.talentType, temp.level);
            }
        }

        /// <summary>
        /// 状态应用
        /// </summary>
        /// <param name="type"></param>
        /// <param name="level"></param>
        void GetState(TalentType type,int level)
        {
            CharacterState state = null;
            switch (type)
            {
                case TalentType.None:
                    break;
                case TalentType.AddAttack:
                     state = new CharacterAddAttackState(level);
                    stateLists.Add(state);
                    break;

                default:
                    break;
            }

            if(state!=null)
            {
                state.OnEnter();
            }
        }

        private void Update()
        {
            foreach(var temp in stateLists)
            {
                temp.Process();
            }
        }

      
    }

}
