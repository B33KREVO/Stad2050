using UnityEngine;
using System.Collections.Generic;

public class CharacterController : MonoBehaviour
{
    public Inventory inventory;  // Reference to the Inventory
    public Transform handTransform;  // Reference to where the item is held (hand position)
    
    private List<GameObject> currentItems = new List<GameObject>();  // List to track picked-up items

    void Update()
    {
        // Picking up items with the E key
        if (Input.GetKeyDown(KeyCode.E))  
        {
            TryPickUpItem();
        }

        // Dropping the last picked item with the Q key
        if (Input.GetKeyDown(KeyCode.Q))  
        {
            DropItem();
        }
    }

    // Tries to pick up an item from the scene
    void TryPickUpItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))  // 5f is the raycast distance
        {
            GameObject item = hit.collider.gameObject;

            // Check if the item has the "Item" tag
            if (item.CompareTag("Item"))
            {
                // Add the item to the inventory and hotbar
                AddItemToHotbar(item);

                // Add the item to the list of picked-up items
                currentItems.Add(item);

                // Make the item invisible once picked up
                item.SetActive(false);
            }
        }
    }

    // Add item to hotbar and inventory
    void AddItemToHotbar(GameObject item)
    {
        // Loop through the hotbar slots and find the first empty slot
        for (int i = 0; i < inventory.hotbarSlots.Length; i++)
        {
            if (inventory.hotbarSlots[i] == null)
            {
                // Store the item in the slot
                inventory.hotbarSlots[i] = item;

                // Get the item icon and store it in the hotbar icon array
                Item itemScript = item.GetComponent<Item>();
                if (itemScript != null)
                {
                    inventory.hotbarIcons[i] = itemScript.icon;  // Store the icon for this slot
                }
                break;
            }
        }
    }

    // Drop the last picked-up item
    void DropItem()
    {
        if (currentItems.Count > 0)
        {
            // Get the last picked-up item (most recent item)
            GameObject itemToDrop = currentItems[currentItems.Count - 1];

            // Drop position is in front of the player (2 units forward)
            Vector3 dropPosition = transform.position + transform.forward * 2f;
            itemToDrop.transform.position = dropPosition;

            // Make the item visible again
            itemToDrop.SetActive(true);

            // Remove the item from the hotbar and inventory
            RemoveItemFromHotbar(itemToDrop);

            // Remove the item from the list
            currentItems.RemoveAt(currentItems.Count - 1);
        }
    }

    // Remove item from hotbar
    void RemoveItemFromHotbar(GameObject item)
    {
        for (int i = 0; i < inventory.hotbarSlots.Length; i++)
        {
            if (inventory.hotbarSlots[i] == item)
            {
                inventory.hotbarSlots[i] = null;
                inventory.hotbarIcons[i] = null;
                break;
            }
        }
    }
}
