using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatiepomp : MonoBehaviour
{
    Animator animator;
    public Animator bootAnimator;
    public doekweg doekje; // Verwijzing naar doekweg
    public int aantalPompjes = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void interactie() {
        // Controleer of doekje bestaat en doekIsWeg is true
        if (doekje.doekIsWeg == true) {
            animator.SetTrigger("pomp1");
            bootAnimator.SetTrigger("lucht");
            aantalPompjes++;
        } else {
            Debug.Log("kut is false"); 
        }
    }
}
