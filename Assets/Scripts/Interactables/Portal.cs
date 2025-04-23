using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Portal : Interactable
{
    public Transform teleport;
    public override void Interact(InventorySimple inventory)
    {
        if (inventory.TeleportLocationsOrder.Count > 0)
        {
            Debug.Log("Teleport created to " + inventory.TeleportLocationsOrder[0]);
            teleport.GetComponent<Teleporter>().teleportIndex = inventory.TeleportLocationsOrder[0];
            teleport.gameObject.SetActive(true); // Activate the teleport object
            inventory.TeleportLocationsOrder.RemoveAt(0); // Remove the first teleport location after using it
            this.enabled = false; // Disable this script to prevent re-using the portal
        }
        else
        {
            Debug.Log("No teleport locations available.");
        }
    }
}
