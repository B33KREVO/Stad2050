using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pomp : MonoBehaviour
{
    
    Animator animator;
    public Animator bootAnimator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void interactie() {
    {
        animator.SetTrigger("pomp1");
        bootAnimator.SetTrigger("lucht");
    }
}
}