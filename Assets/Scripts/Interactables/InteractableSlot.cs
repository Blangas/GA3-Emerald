using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSlot : Interactable
{
    [Header("Interactable Slot")]
    public GameObject slotItem; // Item to show in the slot

    public override void Interact()
    {
        // Implement interaction logic here
        Debug.Log("Interacted with " + gameObject.name);

        if (slotItem != null)
        {
            slotItem.SetActive(true);
        }
    }
}
