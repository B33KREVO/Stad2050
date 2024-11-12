using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zandzakken : MonoBehaviour
{
    AudioSource AudioSource;

    AudioClip magnetronOpenGeluid;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void oppakken()
    {
         gameObject.SetActive(false);
    }
}