using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTLibrary.Utility
{
    /// <summary>
    /// 攻击力增幅状态
    /// </summary>
    public class CharacterAddAttackState : CharacterState
    {
        public CharacterAddAttackState(int level):base(level)
        {

        }
        public override void OnEnter()
        {
            //TODO 

            Debug.Log("AddAttackState Enter");
        }

        public override void OnExit()
        {
            Debug.Log("AddAttackState Exit");
        }

        public override void Process()
        {
            base.Process();
            Debug.Log("AddAttackState Process");
        }
    }

}
