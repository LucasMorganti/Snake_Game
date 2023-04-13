using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Main_Game");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
