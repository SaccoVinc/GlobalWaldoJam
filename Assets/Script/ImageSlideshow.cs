using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSlideshow : MonoBehaviour
{
    [Header("Immagini")]
    [SerializeField] private Sprite[] immagini;

    [Header("Riferimenti UI")]
    [SerializeField] private Image immagineCorrente;
    [SerializeField] private Image immagineSuccessiva;

    [Header("Impostazioni")]
    [SerializeField] private float tempoVisualizzazione = 3f;
    [SerializeField] private float durataDissolvenza = 1f;
    [SerializeField] private bool loop = true;
    [SerializeField] private bool avvioAutomatico = true;

    private int indiceCorrente = 0;
    private bool inEsecuzione = false;

    void Start()
    {
        if (immagini == null || immagini.Length == 0)
        {
            Debug.LogWarning("Nessuna immagine assegnata allo slideshow!");
            return;
        }

        // Inizializza le immagini
        immagineCorrente.sprite = immagini[0];
        immagineCorrente.color = Color.white;
        immagineSuccessiva.color = new Color(1f, 1f, 1f, 0f);

        if (avvioAutomatico)
            Avvia();
    }

    public void Avvia()
    {
        if (!inEsecuzione && immagini.Length > 1)
        {
            inEsecuzione = true;
            StartCoroutine(EseguiSlideshow());
        }
    }

    public void Ferma()
    {
        inEsecuzione = false;
        StopAllCoroutines();
    }

    public void VaiAImmagine(int indice)
    {
        if (indice < 0 || indice >= immagini.Length) return;

        StopAllCoroutines();
        indiceCorrente = indice;
        immagineCorrente.sprite = immagini[indiceCorrente];
        immagineCorrente.color = Color.white;
        immagineSuccessiva.color = new Color(1f, 1f, 1f, 0f);

        if (inEsecuzione)
            StartCoroutine(EseguiSlideshow());
    }

    public void Successiva()
    {
        int prossimoIndice = (indiceCorrente + 1) % immagini.Length;
        StartCoroutine(Dissolvenza(prossimoIndice));
    }

    public void Precedente()
    {
        int indicePrec = indiceCorrente - 1;
        if (indicePrec < 0) indicePrec = immagini.Length - 1;
        StartCoroutine(Dissolvenza(indicePrec));
    }

    IEnumerator EseguiSlideshow()
    {
        while (inEsecuzione)
        {
            yield return new WaitForSeconds(tempoVisualizzazione);

            int prossimoIndice = (indiceCorrente + 1) % immagini.Length;

            if (!loop && prossimoIndice == 0)
            {
                inEsecuzione = false;
                yield break;
            }

            yield return StartCoroutine(Dissolvenza(prossimoIndice));
        }
    }

    IEnumerator Dissolvenza(int nuovoIndice)
    {
        // Prepara l'immagine successiva
        immagineSuccessiva.sprite = immagini[nuovoIndice];

        float tempo = 0f;

        while (tempo < durataDissolvenza)
        {
            tempo += Time.deltaTime;
            float alpha = tempo / durataDissolvenza;

            // Dissolvenza incrociata
            immagineCorrente.color = new Color(1f, 1f, 1f, 1f - alpha);
            immagineSuccessiva.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        // Scambia le immagini
        immagineCorrente.sprite = immagini[nuovoIndice];
        immagineCorrente.color = Color.white;
        immagineSuccessiva.color = new Color(1f, 1f, 1f, 0f);

        indiceCorrente = nuovoIndice;
    }
}