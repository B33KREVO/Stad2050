using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.seceneManagement;

public class bovenscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter() {
        SceneManager.loadscene("boven2", LoadSceneMode.Single);
    }
}
