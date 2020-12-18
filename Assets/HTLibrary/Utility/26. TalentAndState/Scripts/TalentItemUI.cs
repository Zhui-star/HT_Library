using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace HTLibrary.Utility
{
    /// <summary>
    /// 天赋显示的UI
    /// </summary>
    public class TalentItemUI : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler,IPointerExitHandler
    {
        public int itemID;

        public Image talentImg;

        public GameObject unlockMask;

        public GameObject enterImg;

        public Text levelTxt;


        void Start()
        {
            UpdateUI();

            TalentSystemManager.Instance.UpdateStudyUIEvent += UpdateUI;
        }

        void OnDestroy()
        {
            TalentSystemManager.Instance.UpdateStudyUIEvent -= UpdateUI;
        }

        /// <summary>
        /// 更新UI
        /// </summary>
        public void UpdateUI()
        {
            TalentItem item = TalentSystemManager.Instance.talentItemDicts.TryGet<int, TalentItem>(itemID);

            talentImg.sprite = item.TalentIcon;

            if (TalentSystemManager.Instance.IsLearnTalent(itemID))
            {
                unlockMask.SetActive(false);

                int level = TalentSystemManager.Instance.ReturnTalentLevel(itemID);

                talentImg.color = Color.white;

                ShowLevelTxt(level,item);
            }
            else if (TalentSystemManager.Instance.IsUnlockTalent(itemID))
            {
                talentImg.color = Color.grey;
                unlockMask.SetActive(false);

                ShowLevelTxt(0,item);
            }
            else
            {
                unlockMask.SetActive(true);
                talentImg.color = Color.red;

                ShowLevelTxt(0,item);
            }
        }

        /// <summary>
        /// 显示天赋文本
        /// </summary>
        /// <param name="level"></param>
        void ShowLevelTxt(int level,TalentItem item)
        {
            levelTxt.text = (level +"/" +item.talenCosts.Count).ToString();
        }

   
        public void OnPointerDown(PointerEventData eventData)
        {
            //TODO 反馈
        }

        /// <summary>
        /// 显示该天赋信息
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(TalentSystemManager.Instance.enterImg!=null)
            {
                TalentSystemManager.Instance.enterImg.SetActive(false);
            }

            TalentItem talentItem= TalentSystemManager.Instance.talentItemDicts.TryGet<int, TalentItem>(itemID);
            TalentSystemManager.Instance.Pickeditem = talentItem;
            enterImg.SetActive(true);
            TalentSystemManager.Instance.enterImg = enterImg;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }

}
