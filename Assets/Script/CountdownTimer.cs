using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Impostazioni Timer")]
    [SerializeField] private float tempoIniziale = 60f;

    [Header("Riferimenti UI")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Colori")]
    [SerializeField] private Color coloreNormale = Color.white;
    [SerializeField] private Color coloreUrgente = Color.red;

    private float tempoRimanente;
    private bool timerAttivo = true;

    void Start()
    {
        tempoRimanente = tempoIniziale;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!timerAttivo) return;

        tempoRimanente -= Time.deltaTime;

        if (tempoRimanente <= 0f)
        {
            tempoRimanente = 0f;
            timerAttivo = false;
            MostraGameOver();
        }

        AggiornaDisplay();
    }

    void AggiornaDisplay()
    {
        if (timerText == null) return;

        if (tempoRimanente <= 5f)
        {
            // Ultimi 5 secondi: rosso con decimali
            timerText.color = coloreUrgente;
            timerText.text = tempoRimanente.ToString("F2");
        }
        else
        {
            // Tempo normale: bianco, solo interi
            timerText.color = coloreNormale;
            timerText.text = Mathf.CeilToInt(tempoRimanente).ToString();
        }
    }

    void MostraGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (timerText != null)
            timerText.text = "0.00";
    }

    // Metodi pubblici per controllo esterno
    public void RiavviaTimer()
    {
        tempoRimanente = tempoIniziale;
        timerAttivo = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void PausaTimer()
    {
        timerAttivo = false;
    }

    public void RiprendiTimer()
    {
        if (tempoRimanente > 0f)
            timerAttivo = true;
    }

    public void ImpostaTempo(float nuovoTempo)
    {
        tempoIniziale = nuovoTempo;
        tempoRimanente = nuovoTempo;
    }
}