using UnityEngine;

public class TriggerCamera : MonoBehaviour
{
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

    void Win()
    {
        Debug.Log("Hai vinto!");
    }

    void Lose()
    {
        Debug.Log("Hai perso!");
    }
}
