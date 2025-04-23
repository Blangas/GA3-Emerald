using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Portal : Interactable
{
    public override void Interact(InventorySimple inventory)
    {
        if (inventory.TeleportLocationsOrder.Count > 0)
        {
            Debug.Log("Teleport created to " + inventory.TeleportLocationsOrder[0]);
        }
        else
        {
            Debug.Log("No teleport locations available.");
        }
    }
}
