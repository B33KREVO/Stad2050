using UnityEngine;

public class ElfController : MonoBehaviour
{
    // Variabelen voor animatie
    public float animationDuration = 2f;
    private bool isAnimating = true;
    private Vector3 initialScale;
    private Vector3 targetScale;

    // Variabelen voor slepen
    private bool isDragging = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Initialiseer de schaal van de elf en de doel schaal voor animatie
        initialScale = transform.localScale;
        targetScale = initialScale * 1.5f;  // Maak de elf groter als animatie
        StartCoroutine(AnimateElf());
    }

    // Update is called once per frame
    void Update()
    {
        // Start het slepen als de muisknop ingedrukt wordt
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePosition))
            {
                isDragging = true;
                offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, 0f);
            }
        }

        // Stop het slepen als de muisknop wordt losgelaten
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Sleep de elf wanneer de muis beweegt
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f) + offset;
        }
    }

    // Coroutine voor het animeren van de elf
    private System.Collections.IEnumerator AnimateElf()
    {
        float elapsedTime = 0f;

        // Schaal de elf langzaam op naar de target scale
        while (elapsedTime < animationDuration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Zet de elf op de uiteindelijke schaal
        transform.localScale = targetScale;

        // Zet animatie uit als het klaar is
        isAnimating = false;
    }
}
