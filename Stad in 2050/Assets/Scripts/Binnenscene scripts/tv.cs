using UnityEngine;
using UnityEngine.Video;

public class tv : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Stop();
    }
}
