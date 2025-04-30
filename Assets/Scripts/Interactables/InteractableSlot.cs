using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSlot : Interactable
{
    [Header("Interactable Slot")]
    public GameObject slotItem; // Item to show in the slot
    public GameObject slotIcon;
    public string itemName; // Name of the item

    public override void Interact(InventorySimple inventory)
    {
        // Implement interaction logic here
        Debug.Log("Interacted with " + gameObject.name);

        // Check if the inventory has the item
        bool hasItem = (bool)inventory.GetType().GetField(itemName).GetValue(inventory);
        Debug.Log("Inventory has what needed " + inventory.GetType().GetField(itemName).GetValue(inventory));

        if (hasItem)
        {
            slotItem.SetActive(true);
            slotIcon.SetActive(false); // Hide the icon

            switch (itemName)
            {
                case "rune1":
                    inventory.TeleportLocationsOrder.Add(1);
                    break;
                case "rune2":
                    inventory.TeleportLocationsOrder.Add(2);
                    break;
                case "rune3":
                    inventory.TeleportLocationsOrder.Add(3);
                    break;
                case "rune4":
                    inventory.TeleportLocationsOrder.Add(4);
                    break;
                case "rune5":
                    inventory.TeleportLocationsOrder.Add(5);
                    break;
            }
            inventory.GetType().GetField(itemName).SetValue(inventory, false);
        }
    }
}
