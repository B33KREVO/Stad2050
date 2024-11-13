using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    public string objectName;
    public Sprite cursor;
    public UnityEvent interactFunction;
    public Speler speler; // Ensure this is assigned in the Inspector or via code

    public void OnInteract()
    {
        Debug.Log("Interacted with " + objectName);

        if (interactFunction != null)
        {
            interactFunction.Invoke();
        }

        // Ensure speler is not null before changing its state
        if (speler != null)
        {
            speler.hasKey = true;
            Debug.Log("Speler hasKey set to true");
        }
        else
        {
            Debug.LogError("Speler reference is missing!");
        }
    }
}
