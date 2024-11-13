using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;


public class InteractionMessage : MonoBehaviour
{
    public string interactionMessage = "You interacted with an object!"; // Message to display
    public float interactionRange = 5f;                                  // Interaction range
    public float messageDisplayDuration = 2f;                            // Duration to show the message


    public TMP_Text messageText;                                         // TextMeshPro text for displaying the message
    public Image messageBackground;                                      // Background image for the message


    private Coroutine messageCoroutine;


    void Update()
    {
        // Check for interaction input (e.g., pressing 'E')
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }


    void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionRange))
        {
            if (hit.collider.gameObject == gameObject) // Check if the raycast hit this specific object
            {
                ShowMessage(interactionMessage);
            }
        }
    }


    void ShowMessage(string message)
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }


        // Set the message text and enable the text and background
        messageText.text = message;
        messageText.enabled = true;
        messageBackground.enabled = true;


        // Start a coroutine to hide the message after the duration
        messageCoroutine = StartCoroutine(HideMessageAfterDelay());
    }


    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayDuration);


        // Hide the text and background after the delay
        messageText.enabled = false;
        messageBackground.enabled = false;
    }
}
