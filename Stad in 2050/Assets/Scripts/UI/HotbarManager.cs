using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public Image[] hotbarSlots;  // UI slots for displaying item icons
    private InventoryItem[] items;  // Store picked-up items
    private int selectedItemIndex = -1;  // Track the last picked item index
    public Transform playerTransform;  // Reference to the player's Transform
    public float pickupRange = 5f;  // Pickup range set to 5 units

    // Reference to the intBuurman script
    public intBuurman buurmanScript;

    private void Start()
    {
        items = new InventoryItem[3];
    }

    private void Update()
    {
        // Picking up items with the E key
        if (Input.GetKeyDown(KeyCode.E))  
        {
            TryPickUpItem();
            TryInteractWithBuurman();
        }

        // Dropping the last picked item with the Q key
        if (Input.GetKeyDown(KeyCode.Q))  
        {
            DropItem();
        }
    }

    public void AddItemToHotbar(InventoryItem newItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = newItem;
                hotbarSlots[i].sprite = newItem.itemIcon;
                hotbarSlots[i].enabled = true;
                selectedItemIndex = i;  // Update the selected item index
                break;
            }
        }
    }

    private void TryPickUpItem()
    {
        Collider[] hitColliders = Physics.OverlapSphere(playerTransform.position, pickupRange);
        Debug.Log("Checking for items in range...");

        foreach (Collider collider in hitColliders)
        {
            PickupItem itemToPickUp = collider.GetComponent<PickupItem>();
            if (itemToPickUp != null)
            {
                Debug.Log("Item found: " + itemToPickUp.item.itemName);
                AddItemToHotbar(itemToPickUp.item);
                Destroy(itemToPickUp.gameObject);  // Remove the item from the scene
                break;  // Only pick up one item at a time
            }
        }
    }

    private void TryInteractWithBuurman()
    {
        Collider[] hitColliders = Physics.OverlapSphere(playerTransform.position, pickupRange);
        foreach (Collider collider in hitColliders)
        {
            intBuurman buurman = collider.GetComponent<intBuurman>();
            if (buurman != null)
            {
                buurman.Read();  // Trigger the interaction method in the intBuurman script
                break;
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
