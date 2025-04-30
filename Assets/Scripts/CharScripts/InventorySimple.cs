using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySimple : MonoBehaviour
{
    [Header("Picked up items")]
    public bool rune1 = false;
    public bool rune2 = false;
    public bool rune3 = false;
    public bool rune4 = false;
    public bool rune5 = false;
    public bool axe = false;
    public bool tinderBox = false;
    public bool shovel = false;
    public bool rope = false;
    public bool crowbar = false;

    [Header("Teleport locations order")]
    public List<int> TeleportLocationsOrder;

    [Header("Judgement activation")]
    public List<GameObject> judgementObjects;

    public void Start()
    {
        //Debug.Log("rune1 found " + this.GetType().GetField(StringOfVarName).GetValue(this));
    }

    public void AddItem(string itemName)
    {
        switch (itemName)
        {
            case "rune1":
                rune1 = true;
                break;
            case "rune2":
                rune2 = true;
                break;
            case "rune3":
                rune3 = true;
                break;
            case "rune4":
                rune4 = true;
                break;
            case "rune5":
                rune5 = true;
                break;
            case "axe":
                axe = true;
                break;
            case "tinderBox":
                tinderBox = true;
                break;
            case "shovel":
                shovel = true;
                break;
            case "rope":
                rope = true;
                break;
            case "crowbar":
                crowbar = true;
                break;
            default:
                Debug.Log("Item not recognized: " + itemName);
                break;
        }
    }

    public void RemoveItem(string itemName)
    {
        switch (itemName)
        {
            case "rune1":
                rune1 = false;
                break;
            case "rune2":
                rune2 = false;
                break;
            case "rune3":
                rune3 = false;
                break;
            case "rune4":
                rune4 = false;
                break;
            case "rune5":
                rune5 = false;
                break;
            case "axe":
                axe = false;
                break;
            case "tinderBox":
                tinderBox = false;
                break;
            case "shovel":
                shovel = false;
                break;
            case "rope":
                rope = false;
                break;
            case "crowbar":
                crowbar = false;
                break;
            default:
                Debug.Log("Item not recognized: " + itemName);
                break;
        }
    }

    public void Judgement()
    { 
        foreach(GameObject judgeObject in judgementObjects)
        {
            judgeObject.SetActive(true);
        }
    }
}
