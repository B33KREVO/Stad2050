using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class voordeur : MonoBehaviour
{   
    public void open() {
        SceneManager.LoadScene("Binnen", LoadSceneMode.Single);
    }
}
