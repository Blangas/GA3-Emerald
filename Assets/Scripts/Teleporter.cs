using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script from Creating a Portal System in Unity https://medium.com/@tmaurodot/creating-a-portal-system-in-unity-f25954537c00

public class Teleporter : MonoBehaviour
{
    public Transform[] teleportLocations;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " entered the teleporter trigger");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().enabled = false; // Disable player controls
            // Teleport the player to the target location
            other.transform.position = teleportLocations[0].position;
            other.transform.rotation = teleportLocations[0].rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " exited the teleporter trigger");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().enabled = true; // Enable player controls
        }
    }
}
