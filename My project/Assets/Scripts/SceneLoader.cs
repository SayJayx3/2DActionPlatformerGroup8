using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void SceneLoadLoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
