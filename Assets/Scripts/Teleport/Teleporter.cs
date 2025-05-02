using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script from Creating a Portal System in Unity https://medium.com/@tmaurodot/creating-a-portal-system-in-unity-f25954537c00

public class Teleporter : MonoBehaviour
{
    public Transform[] teleportLocations;
    public int teleportIndex = 0; // Index of the teleport location to use

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " entered the teleporter trigger");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().enabled = false; // Disable player controls
            // Teleport the player to the target location
            other.transform.position = teleportLocations[teleportIndex].position;
            other.transform.rotation = teleportLocations[teleportIndex].rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " exited the teleporter trigger");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().enabled = true; // Enable player controls
            this.gameObject.SetActive(false); // Removes used

            if (other.GetComponent<InventorySimple>().judgementOn)
            {
                other.GetComponent<InventorySimple>().Judgement();
            }
        }
    }
}
