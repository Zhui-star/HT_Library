using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
using HTLibrary.Framework;

public class InventoryTest : MonoBehaviour
{
    public void GenerateItemClick()
    {
        Knapsack.Instance.StoreItem(Random.Range(1,3));
    }
}
