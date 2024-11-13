using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doekweg : MonoBehaviour
{
    public animatiepomp animatiePompScript;
    public bool doekIsWeg = false; // Zorg dat doekIsWeg hier gedefinieerd is

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void doekGone() {
        gameObject.SetActive(false);
        doekIsWeg = true; // Zet doekIsWeg op true
    }
}
