using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class raam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void naarBuiten() {
        SceneManager.LoadScene("Terrain2", LoadSceneMode.Single);
    }
}
