using UnityEngine;
using UnityEngine.Video;

public class tv : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    AudioSource audio;
    public AudioClip televisie;


    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Stop();
        audio = GetComponent<AudioSource>();
    }
}
