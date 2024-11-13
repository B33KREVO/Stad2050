using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class afstandbediening : MonoBehaviour
{
    AudioSource audio;
    public tv tv;
    public VideoPlayer videoPlayer;
    public AudioClip tvgeluid;
    public AudioClip televisie;
    public AudioClip alarm;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        videoPlayer = tv.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    public void tvaan()
    {
        videoPlayer.Play();
        audio.PlayOneShot(tvgeluid);
        audio.PlayOneShot(televisie);
        audio.PlayOneShot(alarm);
    }
}
