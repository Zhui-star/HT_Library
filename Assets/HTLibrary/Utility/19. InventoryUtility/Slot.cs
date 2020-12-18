using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HTLibrary.Utility
{
    /// <summary>
    /// 背包格子
    /// </summary>
    public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
    {
        public GameObject itemPrefab;

        protected Image image;

        [Header("属性")]
        public Color normalColor;
        public Color highlightColor;
        public Color clickColor;

        private void Start()
        {
            image = GetComponent<Image>();
        }
        /// <summary>
        /// 把item放在自身下面
        /// 如果自身下面已经有item了，amount++
        /// 如果没有 根据itemPrefab去实例化一个item，放在下面
        /// </summary>
        /// <param name="item"></param>
        public void StoreItem(Item item)
        {
            if (transform.childCount == 0)
            {
                GameObject itemGameObject = Instantiate(itemPrefab) as GameObject;
                itemGameObject.transform.SetParent(this.transform);
                itemGameObject.transform.localScale = Vector3.one;
                itemGameObject.transform.localPosition = Vector3.zero;
                itemGameObject.GetComponent<ItemUI>().SetItem(item);
            }
            else
            {
                transform.GetChild(0).GetComponent<ItemUI>().AddAmount();
            }
        }

        /// <summary>
        /// 得到当前物品槽存储的物品类型
        /// </summary>
        /// <returns></returns>
        public ItemType GetItemType()
        {
            return transform.GetChild(0).GetComponent<ItemUI>().Item.itemType;
        }
        /// <summary>
        /// 得到物品的id
        /// </summary>
        /// <returns></returns>
        public int GetItemId()
        {
            return transform.GetChild(0).GetComponent<ItemUI>().Item.itemID;
        }

        protected ItemUI GetItemUI()
        {
            if (transform.childCount < 0) return null;
            return transform.GetChild(0).GetComponent<ItemUI>();
        }

        public bool IsFilled()
        {
            ItemUI itemUI = transform.GetChild(0).GetComponent<ItemUI>();
            return itemUI.Amount >= itemUI.Item.itemCapacity;//当前的数量大于等于容量
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            if (transform.childCount <=0) return;
            image.color = highlightColor; 
            switch (Knapsack.Instance.toolTips.toolTipType)
            {
                case ToolTipType.ItemEffect:
                    Knapsack.Instance.toolTips.Show(GetItemUI().GetItemEffectTxt());
                    break;
                case ToolTipType.None:
                    Knapsack.Instance.toolTips.Show("测试#:)");
                    break;
            }
        }

        public virtual void UseItem(int num = 1)
        {
            GetItemUI().ReduceAmount(num);
            Debug.Log("物品被使用");
            if (GetItemUI().Amount <= 0)
            {
                Knapsack.Instance.slotList.Remove(this);
                Destroy(this.gameObject);
            }
        }

        public void WearEquipment()
        {

            if (transform.childCount > 0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();

                UseItem(1);
                Item currentItem = currentItemUI.Item;
                if (currentItemUI.Amount <= 0)
                {
                    DestroyImmediate(currentItemUI.gameObject);
                    Knapsack.Instance.toolTips.Hide();
                }
                EquipPanel.Instance.PutOn(currentItem);

            }

        }

        /// <summary>
        /// 放入合成材料
        /// </summary>
        public void PutItemToForge()
        {
            if(transform.childCount>0)
            {
                ItemUI currentItemUI = transform.GetChild(0).GetComponent<ItemUI>();

             
                Item currentItem = currentItemUI.Item;
                if (currentItemUI.Amount <= 0)
                {
                    DestroyImmediate(currentItemUI.gameObject);
                    Knapsack.Instance.toolTips.Hide();
                }
              
               if(ForgePanel.Instance.PutOn(currentItem))
                {
                    UseItem(1);
                }
            }
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (transform.childCount <= 0) return;
            image.color = clickColor;

            ItemUI itemUI = GetItemUI();
            
            InventoryManager.Instance.itemPickedItem = itemUI.Item;
            InventoryManager.Instance.PickedSlot = this;

            switch (itemUI.Item.itemType)
            {
                case ItemType.Consumable:
                    UseItem();
                    break;
                default:
                    if (eventData.button == PointerEventData.InputButton.Right)
                    {
                        WearEquipment();
                    }
                    else if(eventData.button == PointerEventData.InputButton.Left)
                    {
                        PutItemToForge();
                    }
                    break;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.color = normalColor;

            switch (Knapsack.Instance.toolTips.toolTipType)
            {
                case ToolTipType.ItemEffect:
                    Knapsack.Instance.toolTips.Hide();
                    break;
                case ToolTipType.None:
                    Knapsack.Instance.toolTips.Hide();
                    break;
            }
        }
    }

}
