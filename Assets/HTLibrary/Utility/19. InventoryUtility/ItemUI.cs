using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTLibrary.Framework;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace HTLibrary.Utility
{
    /// <summary>
    /// 物品UI
    /// </summary>
    public class ItemUI : MonoBehaviour
    {
        #region Data
        public Item Item { get; private set; }
        public int Amount { get; private set; }
        #endregion

        #region UI Component
        public Image itemImage;
        public Text amountText;
        #endregion

        public bool IsUseConfigure = false;

        public void SetItem(Item item, int amount = 1)
        {
            transform.localScale = Vector3.one;
            this.Item = item;
            this.Amount = amount;

            // update ui 
            if(IsUseConfigure)
            {
                itemImage.sprite = item.itemSprite;
            }
            else
            {
                AddressableUtility.Instance.LoadAddressableObject<Sprite>(item.itemSpriteAddress, FinishedSpriteLoad);
            }

            if (Item.itemCapacity> 1)
                amountText.text = Amount.ToString();
            else
                amountText.text = "";
        }

        void FinishedSpriteLoad(AsyncOperationHandle<Sprite> result)
        {
            this.itemImage.sprite = result.Result;
        }

        public void AddAmount(int amount = 1)
        {
            transform.localScale = Vector3.one;
            this.Amount += amount;
            //update ui 
            if (Item.itemCapacity> 1)
                amountText.text = Amount.ToString();
            else
                amountText.text = "";
        }

        public void ReduceAmount(int amount = 1)
        {
            transform.localScale = Vector3.one;
            this.Amount -= amount;
            //update ui 
            if (Item.itemCapacity > 1)
                amountText.text = Amount.ToString();
            else
                amountText.text = "";
        }

        public void SetAmount(int amount)
        {
            transform.localScale = Vector3.one;
            this.Amount = amount;
            //update ui 
            if (Item.itemCapacity> 1)
                amountText.text = Amount.ToString();
            else
                amountText.text = "";
        }


        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public string GetItemEffectTxt()
        {
            string text = "";
          

            return text;
        }

    }

}
