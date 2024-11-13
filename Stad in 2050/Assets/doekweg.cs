using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doekweg : MonoBehaviour
{
    public bool doekIsWeg = false; 
    public MeshRenderer meshrenderer;
    public Speler speler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void doekGone() {
        meshrenderer.enabled = false;
        doekIsWeg = true; // Zet doekIsWeg op true
    }
}
