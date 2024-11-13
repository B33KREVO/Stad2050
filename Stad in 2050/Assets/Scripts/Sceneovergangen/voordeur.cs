using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class voordeur : MonoBehaviour
{   
    AudioSource audio;
    public AudioClip voordeurgeluid;
        
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void open() {
        audio.PlayOneShot(voordeurgeluid);
        StartCoroutine(LoadSceneAfterDelay(voordeurgeluid.length));
        
   }
   IEnumerator LoadSceneAfterDelay(float delay) {
    yield return new WaitForSeconds(delay);  // Wacht tot het geluid is afgelopen
    SceneManager.LoadScene("Binnen", LoadSceneMode.Single);
}

}
