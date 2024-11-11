using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] hotbarSlots = new GameObject[3];  // Hotbar slots to hold items
    public Sprite[] hotbarIcons = new Sprite[3];  // Array to store icons for each hotbar slot

    // Adds an item to the first available hotbar slot
    public void AddItemToHotbar(GameObject item)
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (hotbarSlots[i] == null)  // If the slot is empty
            {
                hotbarSlots[i] = item;  // Place item in hotbar slot
                Debug.Log($"Item {item.name} added to hotbar slot {i}");
                break;
            }
        }
    }

    // Removes an item from the hotbar, setting the slot to null
    public void RemoveItemFromHotbar(GameObject item)
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (hotbarSlots[i] == item)  // If the item is found in the hotbar
            {
                hotbarSlots[i] = null;  // Remove the item by setting the slot to null
                Debug.Log($"Item {item.name} removed from hotbar slot {i}");
                break;
            }
        }
    }
}
