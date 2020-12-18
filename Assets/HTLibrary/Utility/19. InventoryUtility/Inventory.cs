using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
namespace HTLibrary.Utility
{
    /// <summary>
    /// 背包
    /// </summary>
    public class Inventory : MonoBehaviour
    {
 
        public List<Slot> slotList = new List<Slot>();
        public GameObject slot;
        public Transform slotParent;
        [Header("组件")]
        public ToolTips toolTips;


        public bool StoreItem(int id)
        {
            Item item = InventoryManager.Instance.GetItemById(id);
            return StoreItem(item);
        }

        public bool StoreItem(Item item)
        {
            if (item == null)
            {
                Debug.LogWarning("要存储的物品的id不存在");
                return false;
            }
            if (item.itemCapacity == 1)
            {
                Slot slot = FindEmptySlot();
                if (slot == null)
                {
                    Debug.LogWarning("没有空的物品槽");
                    return false;
                }
                else
                {
                    slot.StoreItem(item);//把物品存储到这个空的物品槽里面
                }
            }
            else
            {
                Slot slot = FindSameIdSlot(item);
                if (slot != null)
                {
                    slot.StoreItem(item);
                }
                else
                {
                    Slot emptySlot = FindEmptySlot();
                    slotList.Add(emptySlot);

                    if (emptySlot != null)
                    {
                        emptySlot.StoreItem(item);
                    }
                    else
                    {
                        Debug.LogWarning("没有空的物品槽");
                        return false;
                    }
                }
            }
            return true;
        }


        /// <summary>
        /// 这个方法用来找到一个空的物品槽(生成一个空的物品槽）
        /// </summary>
        /// <returns></returns>
        private Slot FindEmptySlot()
        {
            GameObject slot = GameObject.Instantiate(this.slot, slotParent);        
            return slot.GetComponent<Slot>();
        }

        private Slot FindSameIdSlot(Item item)
        {
            foreach (Slot slot in slotList)
            {
                if (slot.transform.childCount >= 1 && slot.GetItemId() == item.itemID && slot.IsFilled() == false)
                {
                    return slot;
                }
            }
            return null;
        }
    }

}
