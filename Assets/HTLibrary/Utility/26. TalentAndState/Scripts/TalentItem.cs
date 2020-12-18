using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace HTLibrary.Utility
{
    [Serializable]
    /// <summary>
    /// 天赋学习消耗
    /// </summary>
    public struct TalentCost
    {
        public int level;
        public int cost;
    }

    public enum TalentType
    {
            None,
            AddAttack
    }

    /// <summary>
    /// 天赋属性
    /// </summary>

    [Serializable]
    public class TalentItem
    {
        public string Name;

        public int ID;

        public int[] BindIDs;

        public Sprite TalentIcon;

        public List<TalentCost> talenCosts;

        public TalentType talentType;

        public string[] Descritions;

         
    }

}
