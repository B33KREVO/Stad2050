using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deur : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void testen()
    {
        SceneManager.LoadScene("Binnen", LoadSceneMode.Single);
    }
}
