using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joke : MonoBehaviour
{
    public Image afbeelding; // Verander Text naar Image

    void Start()
    {
        afbeelding.enabled = false; // Zorg dat de afbeelding niet meteen zichtbaar is
    }

    public void Lezen()
    {
        afbeelding.enabled = true; // Toon de afbeelding
    }
}

