using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Portal : Interactable
{
    public bool canBeUsed = true;
    public Transform teleport;
    public Transform[] teleporterImages;

    // used to set correct look-at-player-from point to correct camera
    public Transform lookingAtPlayer;
    public Transform[] teleportCameras;


    public override void Interact(InventorySimple inventory)
    {
        // If there is any teleport location in the list, activates first and removes it from the list
        if (inventory.TeleportLocationsOrder.Count > 0 && canBeUsed)
        {
            canBeUsed = false;
            Debug.Log("Teleport created to " + inventory.TeleportLocationsOrder[0]);
            teleport.GetComponent<Teleporter>().teleportIndex = inventory.TeleportLocationsOrder[0]; // sets teleport indext to first from a list
            teleport.gameObject.SetActive(true); // Activate the teleport object
            teleporterImages[inventory.TeleportLocationsOrder[0]].gameObject.SetActive(true); // activates correct portal image
            teleportCameras[inventory.TeleportLocationsOrder[0]].GetComponent<TeleportCamera>().lookFrom = lookingAtPlayer;
            inventory.TeleportLocationsOrder.RemoveAt(0); // Remove the first teleport location after using it
            //this.enabled = false; // Disable this script to prevent re-using the portal
        }
        else if (canBeUsed)
        {
            canBeUsed = false;
            Debug.Log("No teleport locations list is empty. Teleporting to start.");
            //teleport.GetComponent<Teleporter>().teleportIndex = 0;
            teleport.gameObject.SetActive(true); // Activate the teleport object
            teleporterImages[0].gameObject.SetActive(true); // activates correct portal image
            teleportCameras[0].GetComponent<TeleportCamera>().lookFrom = lookingAtPlayer;

            inventory.judgementOn = true;
        }
    }
}
