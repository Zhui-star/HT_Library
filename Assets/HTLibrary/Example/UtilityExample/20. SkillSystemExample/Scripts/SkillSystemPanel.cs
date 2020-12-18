using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
using HTLibrary.Framework;
public class SkillSystemPanel : MonoBehaviour
{
    public SkillUnitList skillUnitList;
    public GameObject skillSpawnerGo;

    int skillIndex;
    public void LearnSkillClick()
    {
        SkillSystemPlayer.Instance.learnSkillList.Clear();
         skillIndex = Random.Range(0, skillUnitList.skillList.Count);
        for (int i=0;i<2;i++)
        {       
            if(skillIndex==3)
            {
                skillIndex = 0;
            }

            SkillSystemPlayer.Instance.LearnSkill(skillIndex+1);
            skillIndex++;
        }

        if(SkillSystemPlayer.Instance.learnSkillList.Count!=0)
        {
            Debug.Log("技能学习成功");
        }
    }

    public void GenrateSkillClick()
    {
        
        foreach (int tempSkill in SkillSystemPlayer.Instance.learnSkillList)
        {
            SkillSpawner.Instance.StoreSkillUnit(tempSkill);
        }
    }

    public void CloseSpanerGo()
    {
        SkillSpawner.Instance.ClearSkillSpawner();
    }
}
