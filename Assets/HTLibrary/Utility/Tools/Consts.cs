using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HTLibrary.Utility
{
    /// <summary>
    /// 存放一些常量
    /// </summary>
    public class Consts
    {
       
    }

    /// <summary>
    /// 行动条回合状态
    /// </summary>
    public enum ActionBarRoundState
    {
        Computer,
        Player,
        Enemy
    }

    /// <summary>
    /// 队伍角色标签
    /// </summary>
    public enum CharacterType_Round
    {
        Player_1,
        Player_2
    }


    /// <summary>
    /// UI Panel类型
    /// </summary>
    public enum UIPanelType
    {
      MainMenue,
    }

    /// <summary>
    /// 游玩状态
    /// </summary>
    public enum RPGPlayerState
    {
        Idle,
        Move,
        Attack,
        Death,
        TakeDamage
    }


}
