using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public Image[] hotbarSlots;  // UI slots for displaying item icons
    private InventoryItem[] items;  // Store picked-up items
    private int selectedItemIndex = -1;  // Track the last picked item index
    public Transform playerTransform;  // Reference to the player's Transform
    public float pickupRange = 5f;  // Pickup range set to 5 units

    private void Start()
    {
        items = new InventoryItem[3];

        // Zorg ervoor dat de speler-transform is toegewezen.
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
            else
            {
                Debug.LogError("Player object not found. Please ensure the player object has the 'Player' tag.");
            }
        }

        // Zorg ervoor dat hotbarSlots niet null is en dat ze correct zijn toegewezen
        if (hotbarSlots == null || hotbarSlots.Length == 0)
        {
            Debug.LogError("Hotbar slots are not assigned. Please assign the UI slots in the Inspector.");
        }
    }

    private void Update()
    {
        // Alleen interactie met items als speler en slots goed zijn ingesteld
        if (playerTransform != null && hotbarSlots.Length > 0)
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
    }

    public void AddItemToHotbar(InventoryItem newItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = newItem;

                // Zorg ervoor dat je het slot bijwerkt met het item-icoon
                if (i < hotbarSlots.Length)
                {
                    hotbarSlots[i].sprite = newItem.itemIcon;
                    hotbarSlots[i].enabled = true;
                }

                selectedItemIndex = i;  // Update the selected item index
                break;
            }
        }
    }

    private void TryPickUpItem()
    {
        // Check voor colliders in een bepaald bereik van de speler
        Collider[] hitColliders = Physics.OverlapSphere(playerTransform.position, pickupRange);
        Debug.Log("Checking for items in range...");

        foreach (Collider collider in hitColliders)
        {
            PickupItem itemToPickUp = collider.GetComponent<PickupItem>();
            if (itemToPickUp != null)
            {
                Debug.Log("Item found: " + itemToPickUp.item.itemName);
                AddItemToHotbar(itemToPickUp.item);
                Destroy(itemToPickUp.gameObject);  // Verwijder het item uit de scene
                break;  // Pick only one item at a time
            }
        }
    }

    private void DropItem()
    {
        if (selectedItemIndex >= 0 && items[selectedItemIndex] != null)
        {
            Debug.Log("Dropping item: " + items[selectedItemIndex].itemName);
            hotbarSlots[selectedItemIndex].enabled = false;
            items[selectedItemIndex] = null;
            selectedItemIndex = -1;
        }
    }
}
