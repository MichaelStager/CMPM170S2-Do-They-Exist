using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Easy Level");
    }

}
