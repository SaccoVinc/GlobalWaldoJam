using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject Buttons;
    public void PlayGame()
    {
        SceneManager.LoadScene("Livello1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WinGame()
    {
        WinPanel.SetActive(true);
        Buttons.SetActive(true);
    }

    public void LoseGame()
    {
        LosePanel.SetActive(true);
        Buttons.SetActive(true);
    }
}
