using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zandzak2 : MonoBehaviour
{
    AudioSource AudioSource;

    AudioClip zandzak;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void oppakken()
    {
         gameObject.SetActive(false);
    }
}
