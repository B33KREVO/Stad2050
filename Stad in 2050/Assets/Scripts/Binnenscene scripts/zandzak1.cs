using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zandzak1 : MonoBehaviour
{
    AudioSource audio;

    public AudioClip pickup;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void oppakken()
    {
         gameObject.SetActive(false);
         audio.playOneShot(pickup);
    }
}
