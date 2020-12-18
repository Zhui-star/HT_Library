using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using HTLibrary.Utility;
public class SkillSystemPlayer : MonoSingleton<SkillSystemPlayer>
{
    [HideInInspector]
    public List<int> learnSkillList = new List<int>();

    public void LearnSkill(int id)
    {
        learnSkillList.Add(id);
    }


}
