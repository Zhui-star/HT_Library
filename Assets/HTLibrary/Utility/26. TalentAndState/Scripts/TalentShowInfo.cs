using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HTLibrary.Utility
{
    /// <summary>
    /// 显示天赋信息
    /// </summary>
    public class TalentShowInfo : MonoBehaviour
    {
        public Image itemIcon;

        public Text levelTxt;

        public Text costTxt;

        public Text descriptionTxt;

        public GameObject studyBtnGo;

        public Text spiritualSourceTxt;

        private void Start()
        {
            UpdateUI(1);
            TalentSystemManager.Instance.PickedTalentEvent += UpdateUI;
            TalentSystemManager.Instance.UpdateStudyUIEvent += UpdateUI;
        }

        private void OnDestroy()
        {
            TalentSystemManager.Instance.PickedTalentEvent -= UpdateUI;
            TalentSystemManager.Instance.UpdateStudyUIEvent -= UpdateUI;
        }

        /// <summary>
        /// 初始化更新UI
        /// </summary>
        /// <param name="id"></param>
        void UpdateUI(int id)
        {
            TalentItem item = TalentSystemManager.Instance.talentItemDicts.TryGet<int, TalentItem>(id);
            UpdateUI(item);
        }

        /// <summary>
        /// 事件监听更新UI
        /// </summary>
        /// <param name="item"></param>

        void UpdateUI(TalentItem item)
        {
            itemIcon.sprite = item.TalentIcon;
            int level = TalentSystemManager.Instance.ReturnTalentLevel(item.ID);
            levelTxt.text = level+"/"+item.talenCosts.Count.ToString();

            int cost = TalentSystemManager.Instance.ReturnLearnCost(item, level);
            costTxt.text = cost == 0 ? "Max level" : cost.ToString();

            descriptionTxt.text = "";

            foreach (var temp in item.Descritions)
            {
                descriptionTxt.text += temp;
                descriptionTxt.text += "\n";
            }

            studyBtnGo.SetActive(TalentSystemManager.Instance.CanStudyTalent(item.ID));
            spiritualSourceTxt.text = TalentSystemManager.Instance.spiritualSource.ToString();
        }

        /// <summary>
        /// 更新UI
        /// </summary>
        void UpdateUI()
        {
            UpdateUI(TalentSystemManager.Instance.Pickeditem);
        }
        /// <summary>
        /// 学习天赋点击
        /// </summary>
        public void StudyTalentClick()
        {
            TalentSystemManager.Instance.StudyTalent(TalentSystemManager.Instance.Pickeditem.ID);
        }
    }
}

