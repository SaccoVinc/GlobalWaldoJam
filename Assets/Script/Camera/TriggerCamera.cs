using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
    public GameManager manager;
    public CountdownTimer countdownTimer;
    private bool targetInside = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Waldo"))
        {
            targetInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Waldo"))
        {
            targetInside = false;
        }
    }

    public void Scatto()
    {
        if (targetInside)
        {
            Win();
        }
        else 
        { 
            Sbagliato(); 
        }
    }

    public void Win()
    {
        Debug.Log("Hai vinto!");
        manager.WinGame();

    }

    public void Sbagliato()
    {
        countdownTimer.PenalitaTempo();
        Debug.Log("Hai perso!");
     
    }

    public void Lose()
    {
        Debug.Log("Hai perso!");
        manager.LoseGame();
    }
}
