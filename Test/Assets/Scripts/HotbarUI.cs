using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    public Inventory inventory;  // Reference to the Inventory
    public Image[] hotbarSlotImages;  // Array of Image components for hotbar slots

    void Start()
    {
        // You might need to call this initially to populate the hotbar with icons
        UpdateHotbarUI();
    }

    void Update()
    {
        // Update the hotbar UI every frame
        UpdateHotbarUI();
    }

    public void UpdateHotbarUI()
    {
        if (inventory == null || hotbarSlotImages == null || hotbarSlotImages.Length != inventory.hotbarSlots.Length)
        {
            Debug.LogError("Hotbar UI or Inventory is not properly set up.");
            return;
        }

        // Loop through each hotbar slot
        for (int i = 0; i < hotbarSlotImages.Length; i++)
        {
            // If there's no item in the current slot
            if (inventory.hotbarIcons[i] == null)
            {
                hotbarSlotImages[i].sprite = null;  // No sprite for this slot
                hotbarSlotImages[i].color = new Color(0, 0, 0, 0);  // Make the slot transparent
            }
            else
            {
                // Set the sprite to the corresponding icon from the inventory
                hotbarSlotImages[i].sprite = inventory.hotbarIcons[i];
                hotbarSlotImages[i].color = new Color(100, 100, 100, 100);  // Make the slot visible
            }
        }
    }
}
