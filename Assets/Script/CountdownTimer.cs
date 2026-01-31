using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Impostazioni Timer")]
    [SerializeField] private float tempoIniziale = 100f;

    [Header("Riferimenti UI")]
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Colori")]
    [SerializeField] private Color coloreNormale = Color.white;
    [SerializeField] private Color coloreUrgente = Color.red;

    private float tempoRimanente;
    private bool timerAttivo = true;
    public TriggerCamera triggerCamera;

    void Start()
    {
        tempoRimanente = tempoIniziale;
    }

    void Update()
    {
        if (!timerAttivo) return;

        tempoRimanente -= Time.deltaTime;

        if (tempoRimanente <= 0f)
        {
            tempoRimanente = 0f;
            timerAttivo = false;
            triggerCamera.Lose();
        }

        AggiornaDisplay();
    }

    void AggiornaDisplay()
    {
        if (timerText == null) return;

        if (tempoRimanente <= 10f)
        {
            timerText.color = coloreUrgente;
            timerText.text = tempoRimanente.ToString("F2");
        }
        else
        {
            timerText.color = coloreNormale;
            timerText.text = Mathf.CeilToInt(tempoRimanente).ToString();
        }
    }

    public void RiavviaTimer()
    {
        tempoRimanente = tempoIniziale;
        timerAttivo = true;
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

    public void PenalitaTempo()
    {
        tempoRimanente = tempoRimanente - 5f;
    }
}