using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        SceneManager.LoadScene("SchermataWin");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("SchermataLose");
    }
}
