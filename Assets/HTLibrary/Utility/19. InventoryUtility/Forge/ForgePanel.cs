using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace HTLibrary.Utility
{
    public class ForgePanel : Inventory
    {
        public static ForgePanel instance;
        public static ForgePanel Instance
        {
            get
            {
                return instance;
            }
        }

        public FormularConfigure configure;

        private List<Formular> formularList;

        public Text tipsTxt;

        public ResSlot resSlot;
        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            formularList = configure.formulars;

        }


        public bool  PutOn(Item item)
        {
            bool puton = false;
            foreach (Slot slot in slotList)
            {
                ForgeSlot forgeSlot = (ForgeSlot)slot;

                if (forgeSlot.transform.childCount <= 0)
                {
                    forgeSlot.StoreItem(item);
                    puton = true;
                    break;
                }
            }

            bool IsNull = false;
            foreach (Slot slot in slotList)
            {
                if (slot.transform.childCount <= 0)
                {
                    IsNull = true;
                }
            }

            if(!IsNull)
            {
                int id = CheckFormularRes();
                if(id!=-1)
                {
                    resSlot.StoreItem(InventoryManager.Instance.GetItemById(id));
                }
            }
            else
            {
                if(resSlot.transform.childCount>0)
                {
                    Destroy(resSlot.transform.GetChild(0).gameObject);
                }
            }

            return puton;
        }

        public void PutOff(Item item)
        {
            Knapsack.Instance.StoreItem(item);

            if (resSlot.transform.childCount > 0)
            {
                Destroy(resSlot.transform.GetChild(0).gameObject);
            }
        }

        public void SynthesisClick()
        {
            int id = CheckFormularRes();

            if(id!=-1)
            {
                foreach(var temp in slotList)
                {
                    DestroyImmediate(temp.transform.GetChild(0).gameObject);

                }

                Destroy(resSlot.transform.GetChild(0).gameObject);

                Knapsack.Instance.StoreItem(InventoryManager.Instance.GetItemById(id));
            }
        }

        /// <summary>
        /// 检查配方
        /// </summary>
        public int CheckFormularRes()
        {
            List<int> itemIDs = new List<int>();

            foreach (var temp in slotList)
            {
                ItemUI itemUI = temp.transform.GetChild(0).GetComponent<ItemUI>();

                if (itemUI == null)
                {
                    if (tipsTxt != null)
                    {
                        tipsTxt.text = "请放入正确材料";
                    }
                    return -1;
                }
                itemIDs.Add(itemUI.Item.itemID);
            }

            bool isMatch = false;

            foreach (var temp in formularList)
            {
                if (temp.IsMatch(itemIDs))
                {
                    isMatch = true;                   
                    tipsTxt.text = "";
                    return temp.ResID;
                }
            }

            if (!isMatch)
            {
                tipsTxt.text = "请放入正确材料";
            }

            return -1;
        }


    }

}
