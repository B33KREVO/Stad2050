using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class afstandbediening : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void tvaan()
    {
        videoPlayer.Play();
    }
}
