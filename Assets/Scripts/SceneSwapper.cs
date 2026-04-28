using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour
{
    public void swapToScene(int goToIndex)
    {
        SceneManager.LoadScene(goToIndex);
    }
    public void quitApp()
    {
        Application.Quit();
    }

    public static void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
