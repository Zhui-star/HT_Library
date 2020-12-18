using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  HTLibrary.Framework;
using UnityEngine.EventSystems;

namespace HTLibrary.Utility
{
    public class EquipSlot :Slot
    {
        public ItemType itemType;

        public bool IsRightItem(Item item)
        {
            if (item.itemType==itemType)
            {
                return true;
            }

            return false;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            image.color = clickColor;
            ItemUI itemUI = GetItemUI();

            if (itemUI == null) return;
            InventoryManager.Instance.itemPickedItem = itemUI.Item;
            InventoryManager.Instance.PickedSlot = this;


            if (eventData.button == PointerEventData.InputButton.Right)
            {
                UseItem(1);
                EquipPanel.Instance.PutOff(itemUI.Item);
            }

        }

        public override void UseItem(int num = 1)
        {
            GetItemUI().ReduceAmount(num);
            if (GetItemUI().Amount <= 0)
            {
                DestroyImmediate(GetItemUI().gameObject);
            }
        }

    }


}
