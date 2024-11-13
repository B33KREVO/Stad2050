using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatiepomp : MonoBehaviour
{
    AudioSource audio;
    public AudioClip opblazen;
    Animator animator;
    public Animator bootAnimator;
    
    public doekweg doekje; // Verwijzing naar doekweg
    public bool aantalPompjes = false;
        public Speler speler;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void interactie() {
        // Controleer of doekje bestaat en doekIsWeg is true
        if (doekje.doekIsWeg == true) {
            animator.SetTrigger("pomp1");
            bootAnimator.SetTrigger("lucht");
            audio.PlayOneShot(opblazen);
            aantalPompjes = true;
        } else {
            Debug.Log("kut is false"); 
        }
    }
}
