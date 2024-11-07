using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class afstandbediening : MonoBehaviour
{
    public tv tv;
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = tv.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    public void tvaan()
    {
        videoPlayer.Play();
    }
}
