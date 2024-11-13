using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bovendeur : MonoBehaviour
{   
    void OnTriggerEnter() {
        SceneManager.LoadScene("Boven 2", LoadSceneMode.Single);
    }
}
