using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using UnityEngine.UI;

public class afstandbediening : MonoBehaviour
{
    AudioSource audio;
    public tv tv;
    public VideoPlayer videoPlayer;
    public AudioClip tvgeluid;
    public AudioClip televisie;
    public AudioClip alarm;
    public TMP_Text text;
    public Text news;

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
        text.text = "Gather what's important to you and go upstairs";
        text.enabled = true;
        news.text = "BREAKING NEWS: The small town of Doeveren is being flooded. If you live there make sure to gather essentials and evacuate to a safe environment!";
        news.enabled = true;
    }
}
