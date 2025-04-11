using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code example from https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/ 

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
}
