using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doekweg : MonoBehaviour
{
    public animatiepomp animatiePompScript;
    public bool doekIsWeg = false; // Zorg dat doekIsWeg hier gedefinieerd is
    public BoxCollider boxcollider;
    public MeshRenderer meshrenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void doekGone() {
        boxcollider.enabled = false;
        meshrenderer.enabled = false;
        doekIsWeg = true; // Zet doekIsWeg op true
    }
}
