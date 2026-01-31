using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
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
            Lose(); 
        }
    }

    public void Win()
    {
        Debug.Log("Hai vinto!");
    }

    public void Lose()
    {
        countdownTimer.PenalitaTempo();
        Debug.Log("Hai perso!");
    }
}
