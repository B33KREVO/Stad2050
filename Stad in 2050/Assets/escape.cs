using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class escape : MonoBehaviour
{
    public animatiepomp pomp;
    public TextMeshProUGUI textescape;  // Using TextMeshProUGUI type for UI text

    void Start()
    {
    
    }

    // Update is called once per frame
    public void Ontsnap() 
    {
        if (pomp.aantalPompjes) {
            textescape.gameObject.SetActive(true);  // Set the text escape UI element active
        }
    }
}
