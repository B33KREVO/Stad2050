using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voetstappenbuiten : MonoBehaviour
{
    public AudioSource voetstapAudio; // Voeg een AudioSource toe

    // Start is called before the first frame update
    void Start()
    {
        // Zorg ervoor dat de AudioSource is ingesteld op het object
        if (voetstapAudio == null)
        {
            voetstapAudio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Controleer of W, A of D is ingedrukt en of de audio niet al speelt
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !voetstapAudio.isPlaying)
        {
            voetstapAudio.Play(); // Speel de voetstapgeluid af
        }
        // Stop de audio als geen van de toetsen meer wordt ingedrukt
        else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            voetstapAudio.Stop();
        }
    }
}
