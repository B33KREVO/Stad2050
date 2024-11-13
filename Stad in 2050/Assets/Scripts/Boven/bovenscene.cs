using System.Collections;
using System.Collections.Genereic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bovenscene : MonoBehaviour
{   
    void OnTriggerEnter() {
        SceneManager.Loadscene("boven2", LoadSceneMode.Single);
    }
}
