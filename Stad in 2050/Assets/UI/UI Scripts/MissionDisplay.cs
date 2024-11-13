using UnityEngine;
using TMPro;

public class MissionDisplay : MonoBehaviour
{
    public GameObject missionBox;          // Assign your UI background image here
    public TextMeshProUGUI missionText;     // Assign your TextMeshPro component here
    private bool isNearMissionTrigger = false;
    private string currentMissionText;

    // Detect when the player enters a collider with a specific tag
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mission"))
        {
            isNearMissionTrigger = true;
            MissionTrigger missionTrigger = other.GetComponent<MissionTrigger>();

            if (missionTrigger != null)
            {
                currentMissionText = missionTrigger.missionDescription;
            }
        }
    }

    // Detect when the player leaves the collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mission"))
        {
            isNearMissionTrigger = false;
            missionBox.SetActive(false);   // Hide the mission box when not in range
        }
    }

    private void Update()
    {
        // Display mission text if near a mission trigger and 'E' is pressed
        if (isNearMissionTrigger && Input.GetKeyDown(KeyCode.E))
        {
            missionBox.SetActive(true);    // Show the mission box
            missionText.text = currentMissionText;
        }
    }
}
