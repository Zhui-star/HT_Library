using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using System;
namespace HTLibrary.Utility
{
    public class LearnedTalent
    {
        public int ID;
        public int Level;
    }

    /// <summary>
    /// 天赋管理器
    /// </summary>
    public class TalentSystemManager :MonoSingleton<TalentSystemManager>
    {

        // 当前选择的TalentItem
        private TalentItem pickedItem;
        public event Action<TalentItem> PickedTalentEvent;
        public event Action<TalentType,int> StudyTalentEvent;
        public event Action UpdateStudyUIEvent;
        public TalentItem Pickeditem
        {
            get
            {
                return pickedItem;
            }
            set
            {
                if(PickedTalentEvent!=null)
                {
                    PickedTalentEvent(value);
                }

                pickedItem = value;
            }
        }

        //当前获得的天赋ID
        public List<LearnedTalent> learnTalents = new List<LearnedTalent>();

        public TalentItemConfigure talentConfigure;

        public Dictionary<int, TalentItem> talentItemDicts = new Dictionary<int, TalentItem>();

        //Test 用来充当灵源 （灵源用来点天赋)
        public int spiritualSource = 0;

        [HideInInspector]
        public GameObject enterImg;
        
        private void Awake()
        {
            
            InitialTalentDicts();
        }

        /// <summary>
        /// 初始化天赋字典
        /// </summary>
        void InitialTalentDicts()
        {
            if (talentConfigure == null) return;

            List<TalentItem> talentList = talentConfigure.talentItems;

            foreach(var temp in talentList)
            {
                if(!talentItemDicts.ContainsKey(temp.ID))
                {
                    talentItemDicts.Add(temp.ID, temp);
                }
            }
        }

        /// <summary>
        /// 天赋 id 是否已经学会
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsLearnTalent(int id)
        {
            foreach(var temp in learnTalents)
            {
               if(temp.ID==id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 返回指定ID 的天赋 等级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public int ReturnTalentLevel(int id)
        {
            foreach (var temp in learnTalents)
            {
                if (temp.ID == id)
                {
                    return temp.Level;
                }
            }
            return 0;
        }

        /// <summary>
        /// 是否解锁这个天赋
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool IsUnlockTalent(int id)
        {
            if (id == 1)
                return true;

            List<int> learnedIDs = new List<int>();

            foreach(var temp in learnTalents)
            {
                learnedIDs.Add(temp.ID);
            }

            foreach(var temp in learnedIDs)
            {
               TalentItem  talentItem= talentItemDicts.TryGet<int, TalentItem>(temp);
                foreach(var temp2 in talentItem.BindIDs )
                {
                    if(temp2==id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 当前天赋ID 是否已经学满
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ISMaxLevel(int id)
        {
            int level= ReturnTalentLevel(id);
            TalentItem talentItem = talentItemDicts.TryGet<int, TalentItem>(id);
            if(talentItem.talenCosts.Count>level)
            {
                return false;
            }

            return true;
        }

        void AddTalentLevel(int id)
        {
            foreach (var temp in learnTalents)
            {
                if (temp.ID == id)
                {
                    temp.Level++;
                    break;
                }
            }
        }

        /// <summary>
        /// 返回当前学习天赋的消耗
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int ReturnLearnCost(TalentItem item, int level)
        {
            List<TalentCost> talentCostList = item.talenCosts;
            int costs = 0;
            foreach (var temp in talentCostList)
            {
                if (temp.level == level+1)
                {
                    costs = temp.cost;
                    return costs;
                }
            }
            return costs;
        }

        /// <summary>
        /// 是否能够学习天赋
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CanStudyTalent(int id)
        {

            TalentItem item = talentItemDicts.TryGet<int, TalentItem>(id);
            if (ReturnLearnCost(item, ReturnTalentLevel(id)) > spiritualSource)
                return false;

            if (ISMaxLevel(id))
                return false;

            if (!IsLearnTalent(id) && IsUnlockTalent(id))
                return true;

            if (IsLearnTalent(id))
                return true;

            return false;

        }
        /// <summary>
        /// 学习天赋
        /// </summary>
        /// <param name="id"></param>
        public bool StudyTalent(int id)
        {
            TalentItem item = talentItemDicts.TryGet<int, TalentItem>(id);

            if (IsLearnTalent(id))
            {
                AddTalentLevel(id);

                spiritualSource -= ReturnLearnCost(item, ReturnTalentLevel(id));
                StudyTalentEvent?.Invoke(item.talentType, ReturnTalentLevel(id));
                UpdateStudyUIEvent?.Invoke();
                return true;
            }

            if (!IsLearnTalent(id)&& IsUnlockTalent(id))
            {
                LearnedTalent talent = new LearnedTalent();
                talent.ID = id;
                spiritualSource -= ReturnLearnCost(item, ReturnTalentLevel(id));
              
                learnTalents.Add(talent);

                AddTalentLevel(id);

                StudyTalentEvent?.Invoke(item.talentType, ReturnTalentLevel(id));
                UpdateStudyUIEvent?.Invoke();
                return true;
            }
            

            return false;
        }

    }

}
