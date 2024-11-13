using System.Collections;
using System.Collections.Generic;  // Fixed typo
using UnityEngine;
using UnityEngine.SceneManagement;

public class bovenscene : MonoBehaviour
{   
    void OnTriggerEnter(Collider other)  // Added Collider parameter to detect specific object collision
    {
        SceneManager.LoadScene("boven2", LoadSceneMode.Single);  // Fixed method name
    }
}
