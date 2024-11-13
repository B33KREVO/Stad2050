using UnityEngine;
using TMPro;

public class DisplayMessage : MonoBehaviour
{
    public GameObject messageBox;               // UI background image
    public TextMeshProUGUI messageText;         // TextMeshPro text component
    public float interactionRange = 5f;         // Range within which player can interact
    private Transform playerTransform;
    private string currentMessage;
    private bool canDisplayMessage = false;

    private void Start()
    {
        playerTransform = transform;           // Reference to the player's transform
        messageBox.SetActive(false);           // Hide the message box initially
    }

    private void Update()
    {
        // Check for interaction if within range and 'E' key is pressed
        if (canDisplayMessage && Input.GetKeyDown(KeyCode.E))
        {
            messageBox.SetActive(true);        // Show message box
            messageText.text = currentMessage;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            // Check if the interactable object is within the interaction range
            if (Vector3.Distance(playerTransform.position, other.transform.position) <= interactionRange)
            {
                canDisplayMessage = true;
                MessageTrigger messageTrigger = other.GetComponent<MessageTrigger>();

                if (messageTrigger != null)
                {
                    currentMessage = messageTrigger.message;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            canDisplayMessage = false;
            messageBox.SetActive(false);      // Hide the message box when out of range
        }
    }
}
