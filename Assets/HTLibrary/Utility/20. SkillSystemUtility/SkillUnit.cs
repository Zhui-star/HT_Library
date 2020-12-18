using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using System;
namespace HTLibrary.Utility
{
    /// <summary>
    /// 技能属性
    /// </summary>
    [Serializable]
    public class SkillUnit
    {
        public string skillName;

        public int skillID;

        public string skillDescription;

        public SkillType skillType;

        public SkillProperty skillProperty;

        public int skillValue;

        public int costMana;

        public int skillLevel;//适用等级

        public ReleaseType releaseType;

        public int releaseDistance;

        public AssetReference iconRef;

        public AssetReference skillEffectRef;
    }

}
