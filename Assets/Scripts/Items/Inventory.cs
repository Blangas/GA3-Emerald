using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new();

    public void AddItem(ItemData item)
    {
        items.Add(item);
    }
    public void RemoveItem(ItemData item)
    {
        items.Remove(item);
    }
}
