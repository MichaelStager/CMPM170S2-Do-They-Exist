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
}
