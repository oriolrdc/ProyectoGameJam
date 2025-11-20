using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Room1");
    }

    public void Chau()
    {
        Application.Quit();
    }
}
