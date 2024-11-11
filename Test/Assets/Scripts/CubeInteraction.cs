using UnityEngine;
using UnityEngine.UI;
using System.Collections;  // For using coroutines

public class CubeInteraction : MonoBehaviour
{
    // Reference to the UI Image you want to show
    public Image missionImage;

    // Optional: Player interaction distance (for a trigger range)
    public float interactionRange = 5f;

    // Timer delay in seconds before the image disappears
    public float hideAfterSeconds = 5f;

    // Update is called once per frame
    void Update()
    {
        // Check for interaction with the first object (e.g., the cube)
        if (Input.GetKeyDown(KeyCode.E)) // 'E' key to interact
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionRange))
            {
                if (hit.collider.gameObject == gameObject) // If it's the first cube
                {
                    ShowMissionImage();
                    StartCoroutine(HideMissionImageAfterDelay(hideAfterSeconds)); // Start the timer to hide after delay
                }
            }
        }
    }

    // Method to make the UI Image visible
    void ShowMissionImage()
    {
        if (missionImage != null)
        {
            missionImage.enabled = true; // Enable the image to show it
        }
    }

    // Coroutine to hide the image after a delay
    IEnumerator HideMissionImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified amount of time
        if (missionImage != null)
        {
            missionImage.enabled = false; // Hide the image after the delay
        }
    }
}


// or like this with another object

// using UnityEngine;
// using UnityEngine.UI;

// public class CubeInteraction : MonoBehaviour
// {
//     // Reference to the UI Image you want to show
//     public Image missionImage;

//     // Optional: Player interaction distance (for a trigger range)
//     public float interactionRange = 5f;

//     // A reference to the second object that will make the image disappear
//     public GameObject secondObject;

//     // Update is called once per frame
//     void Update()
//     {
//         // Check for the first interaction (for example, player pressing a key or being close)
//         if (Input.GetKeyDown(KeyCode.E)) // 'E' key to interact
//         {
//             RaycastHit hit;
//             if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionRange))
//             {
//                 if (hit.collider.gameObject == gameObject) // If it's the first cube
//                 {
//                     ShowMissionImage();
//                 }
//                 else if (hit.collider.gameObject == secondObject) // If it's the second object
//                 {
//                     HideMissionImage();
//                 }
//             }
//         }
//     }

//     // Method to make the UI Image visible
//     void ShowMissionImage()
//     {
//         if (missionImage != null)
//         {
//             missionImage.enabled = true; // Enable the image to show it
//         }
//     }

//     // Method to hide the UI Image
//     void HideMissionImage()
//     {
//         if (missionImage != null)
//         {
//             missionImage.enabled = false; // Disable the image to hide it
//         }
//     }
// }
