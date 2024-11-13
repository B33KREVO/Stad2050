using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MissionDisplay : MonoBehaviour
{
    public GameObject missionBox;              // Assign your UI background image here
    public TextMeshProUGUI missionText;         // Assign your TextMeshPro component here
    public Image crosshair;                     // Crosshair image in the UI
    public Sprite defaultCrosshair;             // Default crosshair sprite
    public Sprite hoverCrosshair;               // Hover crosshair sprite for when near mission object

    private bool isNearMissionTrigger = false;
    private string currentMissionText;

    private void Start()
    {
        // Set the crosshair to the default sprite at the start
        crosshair.sprite = defaultCrosshair;
        missionBox.SetActive(false);           // Hide the mission box initially
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mission"))
        {
            isNearMissionTrigger = true;
            crosshair.sprite = hoverCrosshair; // Change to hover crosshair when near a mission object

            MissionTrigger missionTrigger = other.GetComponent<MissionTrigger>();
            if (missionTrigger != null)
            {
                currentMissionText = missionTrigger.missionDescription;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Mission"))
        {
            isNearMissionTrigger = false;
            crosshair.sprite = defaultCrosshair; // Reset to default crosshair when leaving mission object
            missionBox.SetActive(false);         // Hide mission box when out of range
        }
    }

    private void Update()
    {
        // Display mission text if near a mission trigger and 'E' is pressed
        if (isNearMissionTrigger && Input.GetKeyDown(KeyCode.E))
        {
            missionBox.SetActive(true);         // Show the mission box
            missionText.text = currentMissionText;
        }
    }
}
