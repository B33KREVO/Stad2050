using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void naarBoven() {
        SceneManager.LoadScene("Boven", LoadSceneMode.Single);
    }
}
