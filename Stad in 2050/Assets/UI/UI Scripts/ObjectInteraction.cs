using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class ObjectInteraction : MonoBehaviour
{
    public float interactionRange = 5f;
    private List<GameObject> inventory = new List<GameObject>();


    private int maxWeight = 3;
    private int currentWeight = 0;


    public Image[] hotbarSlots = new Image[3];
    public Image inventoryStatusImage;
    public Sprite emptyInventoryImage;
    public Sprite oneItemImage;
    public Sprite twoItemsImage;
    public Sprite threeItemsImage;
    public Sprite fullInventoryImage;


    public Image crosshairImage;
    public Sprite defaultCrosshair;
    public Sprite hoverCrosshair;


    public TMP_Text pickupMessageText;  // TextMeshPro for the pickup message text
    public float messageDisplayDuration = 2f;
    public Image pickupMessageBackground;  // Background for the pickup message text
    private Coroutine fullInventoryCoroutine;
    private Coroutine messageCoroutine;
    private int selectedItemIndex = 0;


    void Update()
    {
        UpdateCrosshair();


        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupObject();
        }


        if (Input.GetKeyDown(KeyCode.Q) && inventory.Count > 0)
        {
            DropSelectedItem();
        }


        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2) && inventory.Count > 1) SelectItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3) && inventory.Count > 2) SelectItem(2);


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f) SelectItem((selectedItemIndex + 1) % inventory.Count);
        else if (scroll < 0f) SelectItem((selectedItemIndex - 1 + inventory.Count) % inventory.Count);
    }


    void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionRange))
        {
            if (hit.collider.CompareTag("Pickable"))
            {
                GameObject obj = hit.collider.gameObject;
                PickupObject(obj);
            }
        }
    }


    void PickupObject(GameObject obj)
    {
        if (!obj.TryGetComponent<ItemData>(out ItemData itemData))
        {
            Debug.LogError("ItemData component missing on picked-up object.");
            return;
        }


        if (currentWeight + itemData.weight > maxWeight)
        {
            ShowFullInventoryImageTemporarily();
            return;
        }


        inventory.Add(obj);
        currentWeight += itemData.weight;
        obj.SetActive(false);


        UpdateHotbarUI();
        UpdateInventoryStatusImage();
        SelectItem(inventory.Count - 1);


        // Display the pickup message if it exists
        if (!string.IsNullOrEmpty(itemData.pickupMessage))
        {
            DisplayPickupMessage(itemData.pickupMessage);
        }
    }


    void DropSelectedItem()
    {
        GameObject itemToDrop = inventory[selectedItemIndex];
        if (itemToDrop.TryGetComponent(out ItemData itemData))
        {
            currentWeight -= itemData.weight;
        }


        itemToDrop.SetActive(true);
        itemToDrop.transform.position = transform.position + transform.forward * 1f;
        inventory.Remove(itemToDrop);


        UpdateHotbarUI();
        UpdateInventoryStatusImage();


        if (inventory.Count > 0)
        {
            selectedItemIndex %= inventory.Count;
        }
        else
        {
            selectedItemIndex = 0;
        }
    }


    void SelectItem(int index)
    {
        selectedItemIndex = index;
        UpdateHotbarSelectionUI();
    }


    void UpdateHotbarUI()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i].sprite = null;
            hotbarSlots[i].enabled = false;
        }


        for (int i = 0; i < inventory.Count && i < hotbarSlots.Length; i++)
        {
            if (inventory[i].TryGetComponent(out ItemData itemData))
            {
                hotbarSlots[i].sprite = itemData.itemIcon;
                hotbarSlots[i].enabled = true;
            }
        }
       
        UpdateHotbarSelectionUI();
    }


    void UpdateHotbarSelectionUI()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i].rectTransform.localScale = (i == selectedItemIndex) ? new Vector3(0.6f, 0.6f, 0.6f) : new Vector3(0.5f, 0.5f, 0.5f);
        }
    }


    void UpdateInventoryStatusImage()
    {
        inventoryStatusImage.enabled = true;


        switch (currentWeight)
        {
            case 0:
                inventoryStatusImage.enabled = false;
                break;
            case 1:
                inventoryStatusImage.sprite = oneItemImage;
                break;
            case 2:
                inventoryStatusImage.sprite = twoItemsImage;
                break;
            case 3:
                inventoryStatusImage.sprite = threeItemsImage;
                break;
            default:
                inventoryStatusImage.enabled = false;
                break;
        }
    }


    void ShowFullInventoryImageTemporarily()
    {
        if (fullInventoryCoroutine != null)
        {
            StopCoroutine(fullInventoryCoroutine);
        }


        fullInventoryCoroutine = StartCoroutine(DisplayFullInventoryImage());
    }


    IEnumerator DisplayFullInventoryImage()
    {
        inventoryStatusImage.sprite = fullInventoryImage;
        inventoryStatusImage.enabled = true;


        yield return new WaitForSeconds(2f);


        UpdateInventoryStatusImage();
        fullInventoryCoroutine = null;
    }


    void UpdateCrosshair()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionRange))
        {
            if (hit.collider.CompareTag("Pickable"))
            {
                crosshairImage.sprite = hoverCrosshair;
                return;
            }
        }


        crosshairImage.sprite = defaultCrosshair;
    }


    void DisplayPickupMessage(string message)
    {
        // If message is empty, don't display the box or text
        if (string.IsNullOrEmpty(message)) return;


        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }


        pickupMessageText.text = message;
        pickupMessageText.enabled = true;
        pickupMessageBackground.enabled = true;


        messageCoroutine = StartCoroutine(HidePickupMessageAfterDelay());
    }


    IEnumerator HidePickupMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayDuration);
        pickupMessageText.enabled = false;
        pickupMessageBackground.enabled = false;
    }
}
