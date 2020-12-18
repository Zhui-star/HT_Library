using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTLibrary.Framework
{
    public class AutoHide : MonoBehaviour
    {
        public bool canDestroy = false;
        public float time = 1.5f;

        private void OnEnable()
        {
            Invoke("Hide", time);
        }

        void Hide()
        {
            if(canDestroy)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            CancelInvoke("Hide");
        }
    }

}
