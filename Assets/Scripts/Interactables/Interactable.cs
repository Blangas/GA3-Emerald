using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Interact(InventorySimple inventory)
    {
        // Implement interaction logic here
        Debug.Log("Interacted with " + gameObject.name);
    }
}
