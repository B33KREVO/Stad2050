using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class escape : MonoBehaviour
{
    public animatiepomp pomp;
    public Speler speler;
    public TMP_Text text; 

    void Start()
    {
    
    }

    // Update is called once per frame
    public void Ontsnap() 
    {

        text.text = "Congratulations you succesfully evacuated!";
        text.enabled = true;
    }
}
